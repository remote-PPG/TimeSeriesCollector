using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeSeriesCollector.resources;
namespace TimeSeriesCollector.recordImplement
{
    public partial class HIKVisionRecordForm : Form, IRecordable
    {
        public HIKVisionRecordForm()
        {
            InitializeComponent();
            // 初始化海康sdk
            bool m_bInitSDK = CHCNetSDK.NET_DVR_Init();
            if (m_bInitSDK == false)
            {
                MessageBox.Show("NET_DVR_Init error!");
                this.deleted = true;
                Close();
                return;
            }
            else
            {
                //保存SDK日志 To save the SDK log
                CHCNetSDK.NET_DVR_SetLogToFile(3, Path.Combine(System.IO.Directory.GetCurrentDirectory(), "SdkLog"), true);
            }
        }
        ~HIKVisionRecordForm()
        {
            CHCNetSDK.NET_DVR_Cleanup(); 
        }
        public string prefix { get; set; } = "";
        public string path { get; set; } = "";
        public int interval { get; set; } = 0;
        public bool deleted { get; set; } = false;
        public int recordTime { get; set; } = 0;
        // 生成一段时间序列作为文件名
        private string filePath;

        private CHCNetSDK.NET_DVR_USER_LOGIN_INFO struLogInfo;
        private CHCNetSDK.LOGINRESULTCALLBACK LoginCallBack = null;
        private CHCNetSDK.NET_DVR_DEVICEINFO_V40 DeviceInfo;
        private CHCNetSDK.REALDATACALLBACK RealData = null;
        private int userId = -1;
        private int realHandle = -1;
        private uint iLastErr;
        private delegate void UpdateTextStatusCallback(string strLogStatus, IntPtr lpDeviceInfo);
        public bool isReady()
        {
            return userId >= 0 && realHandle >= 0;
        }

        public void startRecord()
        {
            if (!Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);
            filePath = Path.Combine(path, string.Format("{0}-{1:yyyyMMddHHmmss}.mp4", prefix, DateTime.Now));
            //强制I帧 Make a I frame
            int lChannel = Int16.Parse(channelComboBox.Text); //通道号 Channel number
            CHCNetSDK.NET_DVR_MakeKeyFrame(userId, lChannel);
            bool isSaveStartSuccess = CHCNetSDK.NET_DVR_SaveRealData_V30(realHandle, 2, filePath);
            if (!isSaveStartSuccess)
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string str = "NET_DVR_SaveRealData failed, error code= " + iLastErr;
                MessageBox.Show(str);
                Close();
                return;
            }
        }

        public void stopRecord(bool saveOrNot)
        {
            bool isStopSuccess = CHCNetSDK.NET_DVR_StopSaveRealData(realHandle);
            //停止录像 Stop recording
            if (!isStopSuccess)
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string str = "NET_DVR_StopSaveRealData failed, error code= " + iLastErr;
                if(File.Exists(path))
                    File.Delete(filePath);
                MessageBox.Show(str);
            }
            if (isStopSuccess && !saveOrNot)
                if (File.Exists(path))
                    File.Delete(filePath);
        }
        protected override void OnClosed(EventArgs e)
        {
            deleted = true;
            base.OnClosed(e);
        }
        private void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
            if (dwBufSize > 0)
            {
                byte[] sData = new byte[dwBufSize];
                Marshal.Copy(pBuffer, sData, 0, (Int32)dwBufSize);

                string str = "实时流数据.ps";
                FileStream fs = new FileStream(str, FileMode.Create);
                int iLen = (int)dwBufSize;
                fs.Write(sData, 0, iLen);
                fs.Close();
            }
        }
        private void realPlay()
        {
            if(realHandle >= 0)
            {
                //停止预览 Stop live view 
                if (!CHCNetSDK.NET_DVR_StopRealPlay(realHandle))
                {
                    MessageBox.Show("NET_DVR_StopRealPlay failed, error code= " + CHCNetSDK.NET_DVR_GetLastError());
                    return;
                }
                realHandle = -1;
            }
            if(realHandle < 0)
            {
                CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                lpPreviewInfo.hPlayWnd = realPlayWnd.Handle;//预览窗口
                lpPreviewInfo.lChannel = Int16.Parse(channelComboBox.Text);//预te览的设备通道
                lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                lpPreviewInfo.dwLinkMode = 1;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                lpPreviewInfo.bBlocked = false; //0- 非阻塞取流，1- 阻塞取流
                lpPreviewInfo.dwDisplayBufNum = 1; //播放库播放缓冲区最大缓冲帧数
                lpPreviewInfo.byProtoType = 0;
                lpPreviewInfo.byPreviewMode = 0;
                //预览实时流回调函数
                if (RealData == null)
                {
                    RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);
                }
                IntPtr pUser = new IntPtr();
                //打开预览 Start live view 
                realHandle = CHCNetSDK.NET_DVR_RealPlay_V40(userId, ref lpPreviewInfo, null/*RealData*/, pUser);
                if (realHandle < 0)
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    string str = "NET_DVR_RealPlay_V40 failed, error code= " + iLastErr; //预览失败，输出错误号
                    MessageBox.Show(str);
                    return;
                }
            }
            else                 //测试成功
                MessageBox.Show("验证成功,如果画面没有变化,尝试关闭窗口重新添加");
        }
        private void checkButton_Click(object sender, EventArgs e)
        {
            // 需要登录
            if(userId < 0)
            {
                struLogInfo = new CHCNetSDK.NET_DVR_USER_LOGIN_INFO();
                //设备IP地址或者域名
                string ip = String.Format("{0}.{1}.{2}.{3}",
                    ip_1NumericUpDown.Value, ip_2NumericUpDown.Value,
                    ip_3NumericUpDown.Value, ip_4NumericUpDown.Value);
                byte[] byIP = System.Text.Encoding.Default.GetBytes(ip);
                struLogInfo.sDeviceAddress = new byte[129];
                byIP.CopyTo(struLogInfo.sDeviceAddress, 0);
                //设备用户名
                byte[] byUserName = System.Text.Encoding.Default.GetBytes(nameTextBox.Text);
                struLogInfo.sUserName = new byte[64];
                byUserName.CopyTo(struLogInfo.sUserName, 0);
                //设备密码
                byte[] byPassword = System.Text.Encoding.Default.GetBytes(passwdTextBox.Text);
                struLogInfo.sPassword = new byte[64];
                byPassword.CopyTo(struLogInfo.sPassword, 0);
                //设备服务端口号
                struLogInfo.wPort = ushort.Parse(portNumericUpDown.Text);
/*                if (LoginCallBack == null)
                {
                    LoginCallBack = new CHCNetSDK.LOGINRESULTCALLBACK(cbLoginCallBack);//注册回调函数                    
                }
                struLogInfo.cbLoginResult = LoginCallBack;*/
                struLogInfo.bUseAsynLogin = false; //是否异步登录：0- 否，1- 是

                DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V40();

                //登录设备 Login the device
                userId = CHCNetSDK.NET_DVR_Login_V40(ref struLogInfo, ref DeviceInfo);
                string strLoginCallBack = "登录状态：无";
                if (userId < 0)
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    string str = "NET_DVR_Login_V40 failed, error code= " + iLastErr; //登录失败，输出错误号
                    strLoginCallBack = "登录状态:失败";
                    strLoginCallBack += "，错误号:" + CHCNetSDK.NET_DVR_GetLastError();
                    MessageBox.Show(str);
                }else
                {
                    strLoginCallBack = "登录状态：成功\n登录设备，UserID：" + userId;
                }
                loginLabel.Text = strLoginCallBack;
            }
            // 已登录，预览画面
            if (userId >= 0)
                realPlay();
        }
    }
}
