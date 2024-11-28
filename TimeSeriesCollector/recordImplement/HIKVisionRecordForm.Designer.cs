namespace TimeSeriesCollector.recordImplement
{
    partial class HIKVisionRecordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HIKVisionRecordForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.channelComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.loginLabel = new System.Windows.Forms.Label();
            this.passwdTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.portNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ip_4NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ip_3NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ip_2NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ip_1NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.checkButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.realPlayWnd = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ip_4NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ip_3NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ip_2NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ip_1NumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.realPlayWnd)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.channelComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.loginLabel);
            this.groupBox1.Controls.Add(this.passwdTextBox);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.portNumericUpDown);
            this.groupBox1.Controls.Add(this.ip_4NumericUpDown);
            this.groupBox1.Controls.Add(this.ip_3NumericUpDown);
            this.groupBox1.Controls.Add(this.ip_2NumericUpDown);
            this.groupBox1.Controls.Add(this.ip_1NumericUpDown);
            this.groupBox1.Controls.Add(this.checkButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(661, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备验证";
            // 
            // channelComboBox
            // 
            this.channelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.channelComboBox.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.channelComboBox.FormattingEnabled = true;
            this.channelComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.channelComboBox.Location = new System.Drawing.Point(365, 71);
            this.channelComboBox.Name = "channelComboBox";
            this.channelComboBox.Size = new System.Drawing.Size(78, 26);
            this.channelComboBox.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(272, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "通道：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginLabel
            // 
            this.loginLabel.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginLabel.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.loginLabel.Location = new System.Drawing.Point(466, 27);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(188, 115);
            this.loginLabel.TabIndex = 12;
            this.loginLabel.Text = "登录状态：未登录";
            this.loginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // passwdTextBox
            // 
            this.passwdTextBox.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwdTextBox.Location = new System.Drawing.Point(89, 114);
            this.passwdTextBox.Name = "passwdTextBox";
            this.passwdTextBox.PasswordChar = '*';
            this.passwdTextBox.Size = new System.Drawing.Size(177, 28);
            this.passwdTextBox.TabIndex = 10;
            this.passwdTextBox.Text = "zxcvbnm123456";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nameTextBox.Location = new System.Drawing.Point(89, 70);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(177, 28);
            this.nameTextBox.TabIndex = 7;
            this.nameTextBox.Text = "admin";
            // 
            // portNumericUpDown
            // 
            this.portNumericUpDown.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.portNumericUpDown.Location = new System.Drawing.Point(365, 26);
            this.portNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.portNumericUpDown.Name = "portNumericUpDown";
            this.portNumericUpDown.Size = new System.Drawing.Size(78, 28);
            this.portNumericUpDown.TabIndex = 6;
            this.portNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.portNumericUpDown.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // ip_4NumericUpDown
            // 
            this.ip_4NumericUpDown.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ip_4NumericUpDown.Location = new System.Drawing.Point(281, 26);
            this.ip_4NumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ip_4NumericUpDown.Name = "ip_4NumericUpDown";
            this.ip_4NumericUpDown.Size = new System.Drawing.Size(63, 28);
            this.ip_4NumericUpDown.TabIndex = 3;
            this.ip_4NumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ip_4NumericUpDown.Value = new decimal(new int[] {
            147,
            0,
            0,
            0});
            // 
            // ip_3NumericUpDown
            // 
            this.ip_3NumericUpDown.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ip_3NumericUpDown.Location = new System.Drawing.Point(217, 26);
            this.ip_3NumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ip_3NumericUpDown.Name = "ip_3NumericUpDown";
            this.ip_3NumericUpDown.Size = new System.Drawing.Size(63, 28);
            this.ip_3NumericUpDown.TabIndex = 2;
            this.ip_3NumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ip_3NumericUpDown.Value = new decimal(new int[] {
            119,
            0,
            0,
            0});
            // 
            // ip_2NumericUpDown
            // 
            this.ip_2NumericUpDown.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ip_2NumericUpDown.Location = new System.Drawing.Point(153, 26);
            this.ip_2NumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ip_2NumericUpDown.Name = "ip_2NumericUpDown";
            this.ip_2NumericUpDown.Size = new System.Drawing.Size(63, 28);
            this.ip_2NumericUpDown.TabIndex = 1;
            this.ip_2NumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ip_2NumericUpDown.Value = new decimal(new int[] {
            254,
            0,
            0,
            0});
            // 
            // ip_1NumericUpDown
            // 
            this.ip_1NumericUpDown.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ip_1NumericUpDown.Location = new System.Drawing.Point(89, 26);
            this.ip_1NumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ip_1NumericUpDown.Name = "ip_1NumericUpDown";
            this.ip_1NumericUpDown.Size = new System.Drawing.Size(63, 28);
            this.ip_1NumericUpDown.TabIndex = 0;
            this.ip_1NumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ip_1NumericUpDown.Value = new decimal(new int[] {
            169,
            0,
            0,
            0});
            // 
            // checkButton
            // 
            this.checkButton.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkButton.ForeColor = System.Drawing.Color.Green;
            this.checkButton.Location = new System.Drawing.Point(324, 114);
            this.checkButton.Margin = new System.Windows.Forms.Padding(0);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(120, 32);
            this.checkButton.TabIndex = 11;
            this.checkButton.Text = "验证";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(3, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "密码：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(0, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "账户：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(348, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = ":";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "地址：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.realPlayWnd);
            this.groupBox2.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(13, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(661, 509);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "预览";
            // 
            // realPlayWnd
            // 
            this.realPlayWnd.Location = new System.Drawing.Point(6, 24);
            this.realPlayWnd.Name = "realPlayWnd";
            this.realPlayWnd.Size = new System.Drawing.Size(648, 474);
            this.realPlayWnd.TabIndex = 0;
            this.realPlayWnd.TabStop = false;
            // 
            // HIKVisionRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 686);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(704, 733);
            this.MinimumSize = new System.Drawing.Size(704, 733);
            this.Name = "HIKVisionRecordForm";
            this.Text = "海康视频录制";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ip_4NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ip_3NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ip_2NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ip_1NumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.realPlayWnd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ip_4NumericUpDown;
        private System.Windows.Forms.NumericUpDown ip_3NumericUpDown;
        private System.Windows.Forms.NumericUpDown ip_2NumericUpDown;
        private System.Windows.Forms.NumericUpDown ip_1NumericUpDown;
        private System.Windows.Forms.NumericUpDown portNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwdTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox realPlayWnd;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.ComboBox channelComboBox;
        private System.Windows.Forms.Label label5;
    }
}