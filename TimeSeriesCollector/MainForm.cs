using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeSeriesCollector.recordImplement;

namespace TimeSeriesCollector
{
    public partial class MainForm : Form
    {
        private List<IRecordable> records = new List<IRecordable>();
        private bool isRecording = false;
        private string path;
        private int recordTime;
        private System.Windows.Forms.Timer stopTimer;
        public delegate void Stop(bool saveOrNot);

        public MainForm()
        {
            InitializeComponent();
            // 默认保存位置
            selectLocationLabel.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "collected-data");
            Directory.CreateDirectory(selectLocationLabel.Text);


            // 定时清理records
            System.Windows.Forms.Timer recordTimer = new System.Windows.Forms.Timer();
            recordTimer.Interval = 500;
            recordTimer.Tick += (object s, EventArgs ev) =>
            {
                string collectorLabelText = "";
                for (int i = 0; i < records.Count; i++)
                    if (records[i].deleted)
                    {
                        records.RemoveAt(i);
                    }
                    else collectorLabelText += records[i].prefix + (i == records.Count-1?"":", ");
                collectorLabel.Text = collectorLabelText;
            };
            recordTimer.Start();
        }

        // 录制按钮
        private void recordButton_Click(object sender, EventArgs e)
        {
            record();
        }
        // 添加选择器按钮
        private void record() {
            Stop stop = new Stop((saveOrNot) => {
                stopTimer.Stop();
                foreach (IRecordable record in records)
                    record.stopRecord(saveOrNot);
                recordButton.Text = "开始录制";
                addCollectorButton.Enabled = true;
                recordTimeComboBox.Enabled = true;
                selectLocationLabel.Enabled = true;
                isRecording = false;
                if (saveOrNot) MessageBox.Show("录制成功");
            });
            // 中途退出
            if (isRecording)
            {
                stop(false);
                if (System.IO.Directory.Exists(path))
                    System.IO.Directory.Delete(path, true);
                return;
            }
            path = Path.Combine(selectLocationLabel.Text, string.Format("{0:yyyyMMddHHmmss}", DateTime.Now));
            recordTime = int.Parse(recordTimeComboBox.Text) + 1;
            stopTimer = new System.Windows.Forms.Timer();
            stopTimer.Interval = 100;

            if (records.Count <= 0)
            {
                MessageBox.Show("先添加录制器", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            for (int i = 0; i < records.Count; i++)
            {
                // 参数赋值
                records[i].path = path;
                records[i].recordTime = recordTime;
                if (records[i].deleted)
                {
                    records.RemoveAt(i--);
                    continue;
                }
                if (!records[i].isReady())
                {
                    for (int j = 0; j < i; j++)
                    {
                        records[j].stopRecord(false);
                    }
                    if (System.IO.Directory.Exists(path))
                        System.IO.Directory.Delete(path, true);
                    MessageBox.Show(String.Format("前缀为{0}的录制器未就绪！未完成的文件已清理。", records[i].prefix));
                    recordButton.Text = "开始录制";
                    return;
                }
                // 录制
                records[i].startRecord();
            }

            DateTime startTime = DateTime.Now;


            isRecording = true;
            addCollectorButton.Enabled = false;
            recordTimeComboBox.Enabled = false;
            selectLocationLabel.Enabled = false;
            stopTimer.Tick += (object s, EventArgs ev) => {

                double sec = (DateTime.Now - startTime).TotalSeconds;
                if (records.Count == 0)
                {
                    stop(false);
                    if (System.IO.Directory.Exists(path))
                        System.IO.Directory.Delete(path, true);
                    MessageBox.Show("至少要有一个录制器");
                    return;
                }
                if (sec < recordTime)
                {
                    recordButton.Text = string.Format("停止({0})", (int)(recordTime - sec + 1));
                    return;
                }
                else
                    stop(true);
            };
            stopTimer.Start();
        }


        private void addCollectorButton_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(selectLocationLabel.Text, string.Format("{0:yyyyMMddHHmmss}", DateTime.Now));
            var form = new AddCollectorForm(path, int.Parse(recordTimeComboBox.Text));
            if (form.ShowDialog() == DialogResult.OK)
            {
                int i = 0;
                for(; i < records.Count; i++)
                {
                    if(records[i].prefix == form.GetRecordable.prefix)
                    {
                        MessageBox.Show("文件前缀已存在");
                        break;
                    }
                }
                if(i == records.Count)
                {
                    records.Add(form.GetRecordable);
                    ((Form)form.GetRecordable).Show();
                }
                   
                    

            }
        }

        private void WaveRecordForm_Disposed(object sender, EventArgs e)
        {
            PPGRecordForm form = (PPGRecordForm)sender;
            Console.WriteLine(form);
        }

        // 选择位置
        private void selectLocationLabel_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "选择数据存放的文件夹目录";
            dlg.SelectedPath = selectLocationLabel.Text;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                selectLocationLabel.Text = dlg.SelectedPath;
            }
        }

        private void recordTimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void selectLocationLabel_TextChanged(object sender, EventArgs e)
        {
        }
        protected override void OnClosed(EventArgs e)
        {
            foreach(var record in records)
            {
                ((Form)record).Close();
            }
            base.OnClosed(e);
        }
    }
}
