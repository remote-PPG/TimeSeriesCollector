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
    public partial class CushionRecordForm : Form, IRecordable
    {
        public CushionRecordForm()
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
        public bool deleted { get; set; } = false;
        public int recordTime { get; set; } = 0;

        public CushionCOM cushionObject;
        // 生成一段时间序列作为文件名
        private string filePath;
        // 创建一个定时器记录心率波形的计时器
        private System.Windows.Forms.Timer recordTimer = new System.Windows.Forms.Timer();
        // 保存的字符串
        private StringBuilder ppgInfoSb = new StringBuilder();

        ~CushionRecordForm()
        {
            PPGCOM.Drop();
        }

        public bool isReady()
        {
            return cushionObject != null && cushionObject.isOpen();
        }

        public void startRecord()
        {
            ppgInfoSb.Clear();
            ppgInfoSb.AppendLine("time,raw,bcg,respiration_rate,heart_rate");
            if (!Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);
            filePath = Path.Combine(path, string.Format("{0}-{1:yyyyMMddHHmmss}.csv", prefix, DateTime.Now));

            cushionObject.ClearSubscribers();
            cushionObject.waveHandle += () =>
            {
                if (cushionObject == null || !cushionObject.isOpen() || deleted)
                {
                    stopRecord(false);
                    Close();
                    return;
                }
                if (cushionObject.rawQueue.Count > 0)
                {
                    cushionObject.rawQueue.TryPeek(out int raw);
                    cushionObject.bcgQueue.TryPeek(out int bcg);
                    cushionObject.respirationQueue.TryPeek(out int r);
                    int hr = cushionObject.PR;
                    ppgInfoSb.AppendLine(String.Format("{0:yyyy-MM-dd HH:mm:ss:fff},{1},{2},{3},{4}", DateTime.Now,raw , bcg, r, hr));
                }
                    
            };
        }

        public void stopRecord(bool saveOrNot)
        {
            if(cushionObject != null)
                cushionObject.ClearSubscribers();
            if (recordTimer != null)
                recordTimer.Stop();
            if (saveOrNot)
            {
                FileStream file = new FileStream(Path.Combine(filePath), FileMode.Create);
                StreamWriter fileStreamWrite = new StreamWriter(file);
                try
                {
                    fileStreamWrite.Write(ppgInfoSb.ToString());
                }
                catch (Exception e)
                {
                    MessageBox.Show("错误:" + prefix + " 保存异常," + e.Message);
                }
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
            if (cushionObject == null) return;
            if (m.Msg == 0x0219 && m.WParam.ToInt32() == 0x8004 && !cushionObject.isOpen())
            {
                this.Close();
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            stopRecord(false);
            deleted = true;
            CushionCOM.Drop();
            base.OnClosed(e);
        }



        private void plotTimer_Tick(object sender, EventArgs e)
        {
            this.plot1Panel.Invalidate();
            this.plot2Panel.Invalidate();
            this.plot3Panel.Invalidate();
            if (cushionObject == null || cushionObject.rawQueue.Count <= 0) return;
            prLabel.Text = cushionObject.PR.ToString();
        }

        private void WaveRecordForm_Load(object sender, EventArgs e)
        {

        }

        private void openSeriesButton_Click(object sender, EventArgs e)
        {
            string comName = comNameComboBox.Text;
            try
            {
                cushionObject = CushionCOM.updateCushionCOM(comName);

            }
            catch (Exception ex)
            {
                MessageBox.Show("打开失败，检查PPG传感器:" + ex.Message);
            }
        }
        private void plot1Panel_Paint(object sender, PaintEventArgs e)
        {
            int step = 3;
            int height = e.ClipRectangle.Height;
            int width = e.ClipRectangle.Width;
            if (cushionObject == null || cushionObject.rawQueue.Count <= 2 * step) return;
            Image image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            int[] data = cushionObject.rawQueue.ToArray();


            int len = data.Length / step;
            Point[] points = new Point[len];
            for (int i = 0; i < len; i += 1)
            {
                points[i] = new Point(width - (data.Length - 1 - step * i), height * 2 / 3 - (data[step * i] & (0xFF / 2)));
            }

            Pen pen = new Pen(Color.Gold, 2);
            g.DrawLines(pen, points);
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(image, 0, 0);
        }
        private void plot2Panel_Paint(object sender, PaintEventArgs e)
        {
            int step = 6;
            int height = e.ClipRectangle.Height;
            int width = e.ClipRectangle.Width;
            if (cushionObject == null || cushionObject.bcgQueue.Count <= 2 * step) return;
            Image image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            int[] data = cushionObject.bcgQueue.ToArray();

            int len = data.Length / step;
            Point[] points = new Point[len];
            for (int i = 0; i < len; i += 1)
            {
                points[i] = new Point(width - (data.Length - 1 - step * i), height * 2 / 3 - (data[step * i] & (0xFF / 2)));
            }

            Pen pen = new Pen(Color.Red, 2);
            g.DrawLines(pen, points);
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(image, 0, 0);
        }

        private void plot3Panel_Paint(object sender, PaintEventArgs e)
        {
            int step = 3;
            int height = e.ClipRectangle.Height;
            int width = e.ClipRectangle.Width;
            if (cushionObject == null || cushionObject.respirationQueue.Count <= 2 * step) return;
            Image image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            int[] data = cushionObject.respirationQueue.ToArray();

            int len = data.Length / step;
            Point[] points = new Point[len];
            for (int i = 0; i < len; i += 1)
            {
                points[i] = new Point(width - (data.Length - 1 - step * i), height * 2 / 3 - (data[step * i] & (0xFF / 2)));
            }
            Pen pen = new Pen(Color.Green, 2);
            g.DrawLines(pen, points);
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(image, 0, 0);
        }
    }
}
