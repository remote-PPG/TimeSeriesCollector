using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeSeriesCollector.resources;
namespace TimeSeriesCollector.recordImplement
{
    public partial class PPGRecordForm : Form, IRecordable
    {
        public PPGRecordForm()
        {
            InitializeComponent();
            var items = System.IO.Ports.SerialPort.GetPortNames();
            Array.Sort(items);
            comNameComboBox.Items.Clear();
            comNameComboBox.Items.AddRange(items);
            // 画图
            plotTimer.Start();
        }


        public string prefix { get; set; } = "";
        public string path { get; set; } = "";
        public int interval { get; set; } = 0;
        public bool deleted { get ; set ; } = false;
        public int recordTime { get; set; } = 0;

        public PPGCOM ppgObject;
        // 生成一段时间序列作为文件名
        private string filePath;
        // 创建一个定时器记录心率波形的计时器
        private System.Windows.Forms.Timer recordTimer = new System.Windows.Forms.Timer();
        // 保存的字符串
        private StringBuilder ppgInfoSb = new StringBuilder();
        // PPG color
        private bool ppgUpOrDown = false;
        ~PPGRecordForm()
        {
            Console.WriteLine("~");
            PPGCOM.Drop();
        }
        public bool isReady()
        {
            return ppgObject != null && ppgObject.isOpen();
        }

        public void startRecord()
        {
            ppgInfoSb.Clear();
            ppgInfoSb.AppendLine("time,ppg,spo2,pr,pi");
            if (!Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);
            filePath = Path.Combine(path, string.Format("{0}-{1:yyyyMMddHHmmss}.csv",prefix, DateTime.Now));

            ppgObject.ClearSubscribers();
            ppgObject.waveHandle += () =>
            {
                if (ppgObject == null || !ppgObject.isOpen() || deleted)
                {
                    stopRecord(false);
                    Close();
                    return;
                }
                if (ppgObject.waveShapeInfoQueue.Count > 0)
                    ppgInfoSb.AppendLine(String.Format("{0:yyyy-MM-dd HH:mm:ss:fff},{1},{2},{3},{4}", DateTime.Now, ppgObject.WaveQueueLast, ppgObject.SPO2, ppgObject.PR, ppgObject.PI));
            };
        }

        public void stopRecord(bool saveOrNot)
        {
            if (ppgObject != null)
                ppgObject.ClearSubscribers();
            if ( recordTimer != null)
                recordTimer.Stop();
            if (saveOrNot)
            {
                FileStream file = new FileStream(Path.Combine(filePath), FileMode.Create);
                StreamWriter fileStreamWrite = new StreamWriter(file);
                try
                {
                    fileStreamWrite.Write(ppgInfoSb.ToString());
                }
                catch (Exception e) {
                    MessageBox.Show("错误:"+prefix+" 保存异常,"+e.Message);                }
                finally
                {
                    fileStreamWrite.Flush();
                    file.Close();
                }
            }
            ppgInfoSb.Clear();

        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (ppgObject == null) return;
            if (m.Msg == 0x0219 && m.WParam.ToInt32() == 0x8004 && !ppgObject.isOpen())
            {
                this.Close();
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            stopRecord(false);
            deleted = true;
            PPGCOM.Drop();
            base.OnClosed(e);
        }

        private void plotPanel_Paint(object sender, PaintEventArgs e)
        {
            int height = e.ClipRectangle.Height;
            int width = e.ClipRectangle.Width;
            if (ppgObject == null || ppgObject.waveShapeInfoQueue.Count <= 0) return;
            Image image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            byte[] data = ppgObject.waveShapeInfoQueue.ToArray();
            // 参数错误异常
            if(data.Length < 10) return;
            Point[] points = new Point[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                points[i] = new Point(width * 2 / 3 - (data.Length - 1 - i), height * 2 / 3 - (data[i] & 0x7F));
            }
            int end_1= data[data.Length - 1],end_2= data[data.Length - 5],end_3= data[data.Length - 10];
            if (end_1 < end_2 && end_2 > end_3)
                ppgUpOrDown = !ppgUpOrDown;
            Pen pen = new Pen(ppgUpOrDown ? Color.Red: Color.Gold, 2);
            g.DrawLines(pen, points);
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(image, 0, 0);
        }

        private void plotTimer_Tick(object sender, EventArgs e)
        {
            this.plotPanel.Invalidate();
            if (ppgObject == null || ppgObject.waveShapeInfoQueue.Count <= 0) return;
            spo2Label.Text = ppgObject.SPO2.ToString();
            prLabel.Text = ppgObject.PR.ToString();
            piLabel.Text = ppgObject.PI.ToString();
        }

        private void WaveRecordForm_Load(object sender, EventArgs e)
        {

        }

        private void openSeriesButton_Click(object sender, EventArgs e)
        {
            string comName = comNameComboBox.Text;
            try
            {
                ppgObject = PPGCOM.updatePPGCOM(comName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开失败，检查PPG传感器:" + ex.Message);
            }
        }
    }
}
