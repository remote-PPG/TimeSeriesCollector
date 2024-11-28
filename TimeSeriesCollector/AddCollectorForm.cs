using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeSeriesCollector.recordImplement;

namespace TimeSeriesCollector
{
    /*
     * collectorTypeMap,collectorTypeComboBox_TextChanged添加相应的类型
    */
    public partial class AddCollectorForm : Form
    {
        
        Dictionary<string, Type> collectorTypeMap = new Dictionary<string, Type>()
        {
            {"PPG数据",typeof(PPGRecordForm) },
            {"坐垫数据", typeof(CushionRecordForm) },
            {"普通摄像头", typeof(USBCameraRecordForm)},
            {"海康摄像头", typeof(HIKVisionRecordForm)}
        };
        // 默认参数
        private void collectorTypeComboBox_TextChanged(object sender, EventArgs e)
        {
            switch (collectorTypeComboBox.Text)
            {
                case "PPG数据":
                    {
                        prefixTextBox.Text = "ppg";
                        break;
                    }
                case "坐垫数据":
                    {
                        prefixTextBox.Text = "cushion";
                        break;
                    }
                case "海康摄像头":
                    {
                        prefixTextBox.Text = "rgb";
                        break;
                    }
                case "普通摄像头":
                    {
                        prefixTextBox.Text = "usb_camera";
                        break;
                    }
                default: break;
            }
        }

        public AddCollectorForm(string path,int recordTime)
        {
            InitializeComponent();
            this.path = path;
            this.recordTime = recordTime;
            collectorTypeComboBox.Items.AddRange(collectorTypeMap.Keys.ToArray());
        }
        public IRecordable GetRecordable{ get; set; }
        public string path { get; private set; }
        public int recordTime { get; private set; }
        
        private void Create(Type t)
        {
            try
            {
                IRecordable temp = (IRecordable)Activator.CreateInstance(t);
                if (temp != null && !temp.deleted)
                {
                    GetRecordable = temp;
                }
                else
                {
                    MessageBox.Show("创建失败");
                    return;
                };
                // 赋值
                ((Form)GetRecordable).Text += " - " + prefixTextBox.Text;
                GetRecordable.prefix = prefixTextBox.Text;
                GetRecordable.path = path;
                GetRecordable.recordTime = recordTime;
                DialogResult = DialogResult.OK;
                Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show("创建错误");
            }

        }
        private void addButton_Click(object sender, EventArgs e)
        {
            // 校验collectorTypeComboBox
            if (collectorTypeComboBox.Text == null || collectorTypeComboBox.Text.Equals(""))
            {
                MessageBox.Show("添加失败:未选择收集类型");
                return;
            }
            // 校验prefixTextBox
            if (prefixTextBox.Text == null || prefixTextBox.Text.Equals(""))
            {
                MessageBox.Show("添加失败:保存文件的前缀名为空");
                return;
            }
            char[] invalidChars = System.IO.Path.GetInvalidFileNameChars();
            foreach (char c in invalidChars)
            {
                if (prefixTextBox.Text.Contains(c))
                {
                    MessageBox.Show(String.Format("添加失败:不合法的前缀字符'{0}'", c));
                    return;
                }
            }


            // 校验通过，打开相应的资源
            string flag = collectorTypeComboBox.Text;
            Type classType = null;
            if (collectorTypeMap.TryGetValue(flag, out classType))
                Create(classType);
            else
                MessageBox.Show("没有该收集器类型或创建收集器失败，请联系开发人员");

        }


    }
}
