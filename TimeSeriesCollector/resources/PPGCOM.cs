using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TimeSeriesCollector.resources
{
 
    public class PPGCOM
    {
        private static PPGCOM PPGCOMObject = null;
        // 单例模式
        public static PPGCOM createPPGCOM(string portName)
        {
            if (PPGCOMObject == null)
                PPGCOMObject = new PPGCOM(portName);
            return PPGCOMObject;
        }
        public static PPGCOM updatePPGCOM(string portName)
        {
            if (PPGCOMObject == null)
                PPGCOMObject = new PPGCOM(portName);
            else
            {
                PPGCOM.Drop();
                PPGCOMObject = new PPGCOM(portName);
            }
            return PPGCOMObject;
        }
        public static void Drop() { 
            if(PPGCOMObject != null)
            {
                PPGCOMObject.serialPort.Close();
            }
            PPGCOMObject = null; 
        }
        public delegate void WaveHandle();
        public event WaveHandle waveHandle;
        public System.IO.Ports.SerialPort serialPort;
        /* 校验编码 */
        private byte[] crcTable = {
            0x00, 0x5e, 0xbc, 0xe2, 0x61, 0x3f, 0xdd, 0x83, 0xc2, 0x9c, 0x7e, 0x20, 0xa3, 0xfd, 0x1f, 0x41,
            0x9d, 0xc3, 0x21, 0x7f, 0xfc, 0xa2, 0x40, 0x1e, 0x5f, 0x01, 0xe3, 0xbd, 0x3e, 0x60, 0x82, 0xdc,
            0x23, 0x7d, 0x9f, 0xc1, 0x42, 0x1c, 0xfe, 0xa0, 0xe1, 0xbf, 0x5d, 0x03, 0x80, 0xde, 0x3c, 0x62,
            0xbe, 0xe0, 0x02, 0x5c, 0xdf, 0x81, 0x63, 0x3d, 0x7c, 0x22, 0xc0, 0x9e, 0x1d, 0x43, 0xa1, 0xff,
            0x46, 0x18, 0xfa, 0xa4, 0x27, 0x79, 0x9b, 0xc5, 0x84, 0xda, 0x38, 0x66, 0xe5, 0xbb, 0x59, 0x07,
            0xdb, 0x85, 0x67, 0x39, 0xba, 0xe4, 0x06, 0x58, 0x19, 0x47, 0xa5, 0xfb, 0x78, 0x26, 0xc4, 0x9a,
            0x65, 0x3b, 0xd9, 0x87, 0x04, 0x5a, 0xb8, 0xe6, 0xa7, 0xf9, 0x1b, 0x45, 0xc6, 0x98, 0x7a, 0x24,
            0xf8, 0xa6, 0x44, 0x1a, 0x99, 0xc7, 0x25, 0x7b, 0x3a, 0x64, 0x86, 0xd8, 0x5b, 0x05, 0xe7, 0xb9,
            0x8c, 0xd2, 0x30, 0x6e, 0xed, 0xb3, 0x51, 0x0f, 0x4e, 0x10, 0xf2, 0xac, 0x2f, 0x71, 0x93, 0xcd,
            0x11, 0x4f, 0xad, 0xf3, 0x70, 0x2e, 0xcc, 0x92, 0xd3, 0x8d, 0x6f, 0x31, 0xb2, 0xec, 0x0e, 0x50,
            0xaf, 0xf1, 0x13, 0x4d, 0xce, 0x90, 0x72, 0x2c, 0x6d, 0x33, 0xd1, 0x8f, 0x0c, 0x52, 0xb0, 0xee,
            0x32, 0x6c, 0x8e, 0xd0, 0x53, 0x0d, 0xef, 0xb1, 0xf0, 0xae, 0x4c, 0x12, 0x91, 0xcf, 0x2d, 0x73,
            0xca, 0x94, 0x76, 0x28, 0xab, 0xf5, 0x17, 0x49, 0x08, 0x56, 0xb4, 0xea, 0x69, 0x37, 0xd5, 0x8b,
            0x57, 0x09, 0xeb, 0xb5, 0x36, 0x68, 0x8a, 0xd4, 0x95, 0xcb, 0x29, 0x77, 0xf4, 0xaa, 0x48, 0x16,
            0xe9, 0xb7, 0x55, 0x0b, 0x88, 0xd6, 0x34, 0x6a, 0x2b, 0x75, 0x97, 0xc9, 0x4a, 0x14, 0xf6, 0xa8,
            0x74, 0x2a, 0xc8, 0x96, 0x15, 0x4b, 0xa9, 0xf7, 0xb6, 0xe8, 0x0a, 0x54, 0xd7, 0x89, 0x6b, 0x35
        };
        /* 串口消息队列 */
        private System.Collections.Generic.Queue<byte> serialPortInfoQueue = new System.Collections.Generic.Queue<byte>() ;
        /* 波长队列 */
        public ConcurrentQueue<byte> waveShapeInfoQueue { get; } = new ConcurrentQueue<byte>();
        /* 体征信息队列 */
        public ConcurrentQueue<int[]> Spo2PrPiInfoQueue { get; } = new ConcurrentQueue<int[]>();

        public string SerialPortSataus { get;private set; }
        public string SerialPortParameter { get; private set; }
        
        public int SPO2 { get; private set; }
        public int PR { get; private set; }
        public int PI { get; private set; }
        public int WaveQueueLast { get; private set; }
        public bool Heartbeat { get; private set; }
        private bool isConnected;

        private PPGCOM(string portName)
        {
            init(portName);
        }
        public void init(string portName)
        {
            Console.WriteLine(portName);
            serialPort = new System.IO.Ports.SerialPort();
            this.serialPort.ReadTimeout = 1500;
            this.serialPort.WriteTimeout = 1500;
            serialPort.PortName = portName;
            serialPort.BaudRate = 38400; //波特率
            serialPort.DataBits = 8;  //设置数据位
            serialPort.StopBits = System.IO.Ports.StopBits.One; // 停止位
            serialPort.Parity = System.IO.Ports.Parity.None; // 无奇偶校验
            // 事件
            serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialPort_DataReceived);
            serialPort.Open();

            // 发送查询信息与设备建立连接
            byte[] bytes = new byte[]
            {
                0xAA,0x55,0x51,0x02,0x02,0x00
            };
            bytes[bytes.Length - 1] = getX2Checksums(bytes.Take(bytes.Length - 1).ToArray());
            // 按照协议，最多三次，否则通讯故障
            for (int i = 0; i < 3; i++)
            {
                DateTime sendTime = DateTime.Now;
                serialPort.Write(bytes, 0, bytes.Length);
                while ((DateTime.Now - sendTime).TotalMilliseconds < 1500 && !isConnected)
                    Thread.Sleep(20);
                if (isConnected)
                    return;
            }
            serialPort.Close();
            isConnected = false;
            throw new Exception("通讯建立失败");
        }
        ~PPGCOM()
        {
            serialPort.Close();
        }

        public void ClearSubscribers()
        {
            waveHandle = null;
        }
        public bool isOpen()
        {
            return serialPort.IsOpen;
        }
        public byte getX2Checksums(byte[] bytes)
        {
            byte crc = 0x00;
            foreach (byte b in bytes)
                crc = crcTable[crc ^ b];
            return crc;
        }
        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int len = serialPort.BytesToRead;//获取可以读取的字节数
            byte[] buff = new byte[len];//创建缓存数据数组
            serialPort.Read(buff, 0, len);//把数据读取到buff数组
            foreach (var b in buff)
            {
                // 用 while 代替 if 语句,可以用break中断块
                while (b == 0xAA && serialPortInfoQueue.Count > 0)
                {
                    byte[] responseBytes = serialPortInfoQueue.ToArray();
                    // 遇到新包头，用校验值校验栈里的信息，不匹配则退出 while 块
                    if (responseBytes[responseBytes.Length - 1] != getX2Checksums(responseBytes.Take(responseBytes.Length - 1).ToArray()))
                        break;
                    // 将一整条指令出队列
                    serialPortInfoQueue.Clear();
                    // 将一整条指令输出到控制台
                    foreach (var responseByte in responseBytes)
                    {
                        Console.Write(responseByte.ToString("X2") + " ");
                    }
                    Console.WriteLine();
                    // 取得信息后的操作
                    analysisResponse(responseBytes);
                    break;
                }
                // 无论如何都会进队列
                serialPortInfoQueue.Enqueue(b);
            }
        }


        void analysisResponse(byte[] bytes)
        {
            try
            {
                if (bytes.Length < 6) return;
                if (!Enumerable.SequenceEqual(bytes.Take(2), new byte[] { 0xAA, 0x55 })) return;
                else isConnected = true;
                // slave 状态
                if (Enumerable.SequenceEqual(bytes.Skip(2).Take(3), new byte[] { 0x51, 0x03, 0x02 }))
                {
                    
                    StringBuilder stringBuilder = new StringBuilder("获取探头状态\n");
                    // 状态，不管他，收到状态回复直接要求发送波形数据
                    int state = bytes[5];
                    bytes = new byte[]{0xAA,0x55,0x50,0x03,0x02,0x01,0x00};
                    bytes[bytes.Length - 1] = getX2Checksums(bytes.Take(bytes.Length - 1).ToArray());
                    serialPort.Write(bytes, 0, bytes.Length);

                    // }
                    int[] bitSizes = { 2, 1, 1, 1, 1, 2 };
                    string[][] infoMap = new string[][] {
                                    new string[] {"","","",""}, // 2 bit
                                    new string[] { "","探头故障或使用不当" }, // 1 bit
                                    new string[] { "手指已插入", "手指未插入"}, // 1 bit
                                    new string[] {"探头已连接","探头未连接"}, // 1 bit
                                    new string[] { "禁止主动发送", "允许主动发送"}, // 1 bit
                                    new string[] {"成人模式","新生儿模式","动物模式","未知模式" },  // 2 bit
                                };
                    for (int i = 0; i < bitSizes.Length; i++)
                    {
                        int key = state & ((int)Math.Pow(2, bitSizes[i]) - 1);
                        state = state >> bitSizes[i];
                        stringBuilder.Append(infoMap[i][key]);
                        if (i < bitSizes.Length - 1 && !infoMap[i][key].Equals("")) stringBuilder.Append("\n");
                    }
                    SerialPortSataus = stringBuilder.ToString();
                }
                // slave 参数信息
                if (Enumerable.SequenceEqual(bytes.Skip(2).Take(3), new byte[] { 0x53, 0x07, 0x01 }))
                {
                    int dataTemp = 0;
                    // 设置参数
                    int[] vs = new int[3];
                    dataTemp = vs[0] = bytes[5];
                    SPO2 = dataTemp;
                    dataTemp = vs[1] = (bytes[6] | bytes[7] << 8);
                    PR = dataTemp;
                    dataTemp = vs[2] = (bytes[8]);
                    PI = dataTemp;
                    Spo2PrPiInfoQueue.Enqueue(vs);



                    // 设置状态
                    StringBuilder stringBuilder = new StringBuilder("接收参数中\n");
                    int state = bytes[9];
                    int[] bitSizes = { 1, 1, 1, 1, 1, 1, 2 };
                    string[][] infoMap = new string[][] {
                                    new string[] { "","Prob disconnected"}, // 1 bit
                                    new string[] { "","探头脱离或手指未插入" }, // 1 bit
                                    new string[] { "", "Pulse searching"}, // 1 bit
                                    new string[] { "","探头故障或使用不当"}, // 1 bit
                                    new string[] { "", "Moction detected"}, // 1 bit
                                    new string[] { "", "低功耗"}, // 1 bit
                                    new string[] {"成人模式","新生儿模式","动物模式","未知模式" }  // 2 bit
                                };
                    for (int i = 0; i < bitSizes.Length; i++)
                    {
                        int key = state & ((int)Math.Pow(2, bitSizes[i]) - 1);
                        state = state >> bitSizes[i];
                        stringBuilder.Append(infoMap[i][key]);
                        if (i < bitSizes.Length - 1 && !infoMap[i][key].Equals("")) stringBuilder.Append("\n");
                    }
                    SerialPortParameter = stringBuilder.ToString();
                }
                // 类型01的波形数据
                if (Enumerable.SequenceEqual(bytes.Skip(2).Take(3), new byte[] { 0x52, 0x03, 0x01 }) && bytes.Length >= 6)
                {
                    if (waveShapeInfoQueue.Count >= 1000)
                        waveShapeInfoQueue.TryDequeue(out byte result);
                    byte b = (byte)(bytes[5] & 0x7f);
                    Heartbeat = (bytes[5] >> 7) == 1;
                    waveShapeInfoQueue.Enqueue(b);
                    WaveQueueLast = b;
                    if (waveHandle != null)
                    {
                        waveHandle();
                    }
                }
            }
            catch (Exception err)
            {
                SerialPortSataus = "指令解析异常:" + err.Message;
                Console.WriteLine("指令解析异常:" + err.Message);
            }

        }
    }

}
