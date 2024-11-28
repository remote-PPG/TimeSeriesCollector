namespace TimeSeriesCollector.recordImplement
{
    partial class USBCameraRecordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USBCameraRecordForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.label5 = new System.Windows.Forms.Label();
            this.channelBox = new System.Windows.Forms.ComboBox();
            this.setGroupBox = new System.Windows.Forms.GroupBox();
            this.encodingComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.videoQualityComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.setGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.videoSourcePlayer);
            this.groupBox2.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1028, 579);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "预览";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.Location = new System.Drawing.Point(6, 24);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(1016, 549);
            this.videoSourcePlayer.TabIndex = 0;
            this.videoSourcePlayer.Text = "videoSourcePlayer1";
            this.videoSourcePlayer.VideoSource = null;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(9, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "通道选择：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // channelBox
            // 
            this.channelBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.channelBox.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.channelBox.FormattingEnabled = true;
            this.channelBox.Location = new System.Drawing.Point(170, 29);
            this.channelBox.Name = "channelBox";
            this.channelBox.Size = new System.Drawing.Size(312, 24);
            this.channelBox.TabIndex = 14;
            this.channelBox.SelectedIndexChanged += new System.EventHandler(this.channelComboBox_SelectedIndexChanged);
            // 
            // setGroupBox
            // 
            this.setGroupBox.Controls.Add(this.encodingComboBox);
            this.setGroupBox.Controls.Add(this.label2);
            this.setGroupBox.Controls.Add(this.label1);
            this.setGroupBox.Controls.Add(this.videoQualityComboBox);
            this.setGroupBox.Controls.Add(this.label5);
            this.setGroupBox.Controls.Add(this.channelBox);
            this.setGroupBox.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.setGroupBox.Location = new System.Drawing.Point(18, 12);
            this.setGroupBox.Name = "setGroupBox";
            this.setGroupBox.Size = new System.Drawing.Size(1016, 122);
            this.setGroupBox.TabIndex = 17;
            this.setGroupBox.TabStop = false;
            this.setGroupBox.Text = "设备验证";
            // 
            // encodingComboBox
            // 
            this.encodingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.encodingComboBox.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.encodingComboBox.FormattingEnabled = true;
            this.encodingComboBox.Location = new System.Drawing.Point(650, 43);
            this.encodingComboBox.Name = "encodingComboBox";
            this.encodingComboBox.Size = new System.Drawing.Size(208, 24);
            this.encodingComboBox.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(526, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "编码格式：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "视频质量：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // videoQualityComboBox
            // 
            this.videoQualityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.videoQualityComboBox.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.videoQualityComboBox.FormattingEnabled = true;
            this.videoQualityComboBox.Location = new System.Drawing.Point(172, 74);
            this.videoQualityComboBox.Name = "videoQualityComboBox";
            this.videoQualityComboBox.Size = new System.Drawing.Size(310, 24);
            this.videoQualityComboBox.TabIndex = 15;
            this.videoQualityComboBox.SelectedIndexChanged += new System.EventHandler(this.videoQualityComboBox_SelectedIndexChanged);
            // 
            // GeneralRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 731);
            this.Controls.Add(this.setGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(704, 733);
            this.Name = "GeneralRecordForm";
            this.Text = "普通摄像头录制";
            this.groupBox2.ResumeLayout(false);
            this.setGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox channelBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox setGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox videoQualityComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox encodingComboBox;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
    }
}