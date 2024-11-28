using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TimeSeriesCollector.resources
{

    public class CushionCOM
    {
        private static CushionCOM CushionCOMObject = null;
        // 单例模式
        public static CushionCOM createCushionCOM(string portName)
        {
            if (CushionCOMObject == null)
                CushionCOMObject = new CushionCOM(portName);
            return CushionCOMObject;
        }
        public static CushionCOM updateCushionCOM(string portName)
        {
            if (CushionCOMObject == null)
                CushionCOMObject = new CushionCOM(portName);
            else
            {
                CushionCOM.Drop();
                CushionCOMObject = new CushionCOM(portName);
            }
            return CushionCOMObject;
        }
        public static void Drop()
        {
            if (CushionCOMObject != null)
            {
                CushionCOMObject.serialPort.Close();
            }
            CushionCOMObject = null;
        }
        public delegate void WaveHandle();
        public event WaveHandle waveHandle;
        public System.IO.Ports.SerialPort serialPort;
        /* 串口消息队列 */
        private System.Collections.Generic.Queue<byte> serialPortInfoQueue = new System.Collections.Generic.Queue<byte>();
        /* 原始数据队列 */
        public ConcurrentQueue<int> rawQueue { get; } = new ConcurrentQueue<int>();
        /* 体征信息队列 */
        public ConcurrentQueue<int> bcgQueue { get; } = new ConcurrentQueue<int>();
        public ConcurrentQueue<int> respirationQueue { get; } =new ConcurrentQueue<int>();
        public int PR { get; private set; }

        private CushionCOM(string portName)
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
            serialPort.BaudRate = 921600; //波特率
            serialPort.DataBits = 8;  //设置数据位
            serialPort.StopBits = System.IO.Ports.StopBits.One; // 停止位
            serialPort.Parity = System.IO.Ports.Parity.None; // 无奇偶校验
            // 事件
            serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialPort_DataReceived);
            serialPort.Open();
        }
        ~CushionCOM()
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
        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
/*            Console.WriteLine("hh");*/
            int len = serialPort.BytesToRead;//获取可以读取的字节数
            byte[] buff = new byte[len];//创建缓存数据数组
            serialPort.Read(buff, 0, len);//把数据读取到buff数组
            foreach (var b in buff)
            {
                // 用 while 代替 if 语句,可以用break中断块
                while (b == 0xFD && serialPortInfoQueue.Count > 1)
                {
                    byte[] responseBytes = serialPortInfoQueue.ToArray();
                    // 遇到新包头，用校验值校验栈里的信息，不匹配则退出 while 块
                    if (responseBytes.Length < 38 && responseBytes[1] == 0xA6)
                        break;
                    if (responseBytes.Length == 38 && responseBytes[1] == 0xA6)
                        analysisResponse(responseBytes);
                    serialPortInfoQueue.Clear();
                    break;
                }
                // 无论如何都会进队列
                serialPortInfoQueue.Enqueue(b);
            }
        }


        void analysisResponse(byte[] bytes)
        {
            PR = (bytes[11] << 8) | bytes[12];

            rawQueue.Enqueue((bytes[5] << 8) | bytes[6]);
            bcgQueue.Enqueue((bytes[7] << 8) | bytes[8]);
            respirationQueue.Enqueue((bytes[9] << 8) | bytes[10]);

            while (rawQueue.Count >= 1000)
                rawQueue.TryDequeue(out int result);
            while (bcgQueue.Count >= 1000)
                bcgQueue.TryDequeue(out int result);
            while (respirationQueue.Count >= 1000)
                respirationQueue.TryDequeue(out int result);
            if (waveHandle != null)
            {
                waveHandle();
            }
        }
    }

}
