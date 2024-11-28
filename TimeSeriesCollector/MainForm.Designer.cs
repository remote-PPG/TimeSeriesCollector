namespace TimeSeriesCollector
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.recordButton = new System.Windows.Forms.Button();
            this.addCollectorButton = new System.Windows.Forms.Button();
            this.recordTimeComboBox = new System.Windows.Forms.ComboBox();
            this.recordTimeLabel = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.selectLocationLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.collectorLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // recordButton
            // 
            this.recordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.recordButton.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recordButton.Location = new System.Drawing.Point(339, 360);
            this.recordButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(115, 35);
            this.recordButton.TabIndex = 0;
            this.recordButton.Text = "开始录制";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // addCollectorButton
            // 
            this.addCollectorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addCollectorButton.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addCollectorButton.Location = new System.Drawing.Point(209, 360);
            this.addCollectorButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.addCollectorButton.Name = "addCollectorButton";
            this.addCollectorButton.Size = new System.Drawing.Size(101, 35);
            this.addCollectorButton.TabIndex = 1;
            this.addCollectorButton.Text = "添加录制器";
            this.addCollectorButton.UseVisualStyleBackColor = true;
            this.addCollectorButton.Click += new System.EventHandler(this.addCollectorButton_Click);
            // 
            // recordTimeComboBox
            // 
            this.recordTimeComboBox.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recordTimeComboBox.FormattingEnabled = true;
            this.recordTimeComboBox.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "30",
            "40",
            "60",
            "80",
            "100",
            "120",
            "180"});
            this.recordTimeComboBox.Location = new System.Drawing.Point(109, 22);
            this.recordTimeComboBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.recordTimeComboBox.Name = "recordTimeComboBox";
            this.recordTimeComboBox.Size = new System.Drawing.Size(53, 30);
            this.recordTimeComboBox.TabIndex = 2;
            this.recordTimeComboBox.Text = "120";
            this.recordTimeComboBox.SelectedIndexChanged += new System.EventHandler(this.recordTimeComboBox_SelectedIndexChanged);
            // 
            // recordTimeLabel
            // 
            this.recordTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.recordTimeLabel.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recordTimeLabel.Location = new System.Drawing.Point(2, 16);
            this.recordTimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.recordTimeLabel.Name = "recordTimeLabel";
            this.recordTimeLabel.Size = new System.Drawing.Size(93, 29);
            this.recordTimeLabel.TabIndex = 3;
            this.recordTimeLabel.Text = "录制时长：";
            this.recordTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // locationLabel
            // 
            this.locationLabel.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.locationLabel.Location = new System.Drawing.Point(2, 18);
            this.locationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(97, 35);
            this.locationLabel.TabIndex = 4;
            this.locationLabel.Text = "存储位置：";
            this.locationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // selectLocationLabel
            // 
            this.selectLocationLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectLocationLabel.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selectLocationLabel.Location = new System.Drawing.Point(109, 11);
            this.selectLocationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selectLocationLabel.Name = "selectLocationLabel";
            this.selectLocationLabel.Size = new System.Drawing.Size(320, 106);
            this.selectLocationLabel.TabIndex = 5;
            this.selectLocationLabel.TextChanged += new System.EventHandler(this.selectLocationLabel_TextChanged);
            this.selectLocationLabel.Click += new System.EventHandler(this.selectLocationLabel_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(183, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "+1秒";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // collectorLabel
            // 
            this.collectorLabel.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.collectorLabel.Location = new System.Drawing.Point(23, 27);
            this.collectorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.collectorLabel.Name = "collectorLabel";
            this.collectorLabel.Size = new System.Drawing.Size(396, 39);
            this.collectorLabel.TabIndex = 8;
            this.collectorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.recordTimeLabel);
            this.panel1.Controls.Add(this.recordTimeComboBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(11, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 57);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.locationLabel);
            this.panel2.Controls.Add(this.selectLocationLabel);
            this.panel2.Location = new System.Drawing.Point(11, 83);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(440, 129);
            this.panel2.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.collectorLabel);
            this.groupBox2.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(13, 253);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(465, 75);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "录制器";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(13, 8);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(465, 235);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "设定";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 419);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.addCollectorButton);
            this.Controls.Add(this.recordButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximumSize = new System.Drawing.Size(777, 475);
            this.MinimumSize = new System.Drawing.Size(503, 475);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主窗口";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Button addCollectorButton;
        private System.Windows.Forms.ComboBox recordTimeComboBox;
        private System.Windows.Forms.Label recordTimeLabel;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.Label selectLocationLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label collectorLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

