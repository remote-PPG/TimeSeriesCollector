namespace TimeSeriesCollector.recordImplement
{
    partial class PPGRecordForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PPGRecordForm));
            this.plotPanel = new System.Windows.Forms.Panel();
            this.plotTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.prLabel = new System.Windows.Forms.Label();
            this.spo2Label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.piLabel = new System.Windows.Forms.Label();
            this.comNameComboBox = new System.Windows.Forms.ComboBox();
            this.openSeriesButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plotPanel
            // 
            this.plotPanel.Location = new System.Drawing.Point(13, 13);
            this.plotPanel.Name = "plotPanel";
            this.plotPanel.Size = new System.Drawing.Size(569, 326);
            this.plotPanel.TabIndex = 0;
            this.plotPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.plotPanel_Paint);
            // 
            // plotTimer
            // 
            this.plotTimer.Tick += new System.EventHandler(this.plotTimer_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.prLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.spo2Label, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.piLabel, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(598, 118);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.4F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(187, 201);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("等线", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "血氧";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prLabel
            // 
            this.prLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prLabel.Font = new System.Drawing.Font("等线", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.prLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.prLabel.Location = new System.Drawing.Point(96, 66);
            this.prLabel.Name = "prLabel";
            this.prLabel.Size = new System.Drawing.Size(88, 66);
            this.prLabel.TabIndex = 4;
            this.prLabel.Text = "-";
            this.prLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spo2Label
            // 
            this.spo2Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spo2Label.Font = new System.Drawing.Font("等线", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.spo2Label.ForeColor = System.Drawing.Color.Red;
            this.spo2Label.Location = new System.Drawing.Point(96, 0);
            this.spo2Label.Name = "spo2Label";
            this.spo2Label.Size = new System.Drawing.Size(88, 66);
            this.spo2Label.TabIndex = 3;
            this.spo2Label.Text = "-";
            this.spo2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("等线", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.LimeGreen;
            this.label2.Location = new System.Drawing.Point(3, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 66);
            this.label2.TabIndex = 1;
            this.label2.Text = "PR(bpm)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("等线", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(3, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 69);
            this.label3.TabIndex = 2;
            this.label3.Text = "PI(1/1000)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // piLabel
            // 
            this.piLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.piLabel.Font = new System.Drawing.Font("等线", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.piLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.piLabel.Location = new System.Drawing.Point(96, 132);
            this.piLabel.Name = "piLabel";
            this.piLabel.Size = new System.Drawing.Size(88, 69);
            this.piLabel.TabIndex = 5;
            this.piLabel.Text = "-";
            this.piLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comNameComboBox
            // 
            this.comNameComboBox.DropDownHeight = 200;
            this.comNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comNameComboBox.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comNameComboBox.FormattingEnabled = true;
            this.comNameComboBox.IntegralHeight = false;
            this.comNameComboBox.Location = new System.Drawing.Point(605, 19);
            this.comNameComboBox.Name = "comNameComboBox";
            this.comNameComboBox.Size = new System.Drawing.Size(165, 33);
            this.comNameComboBox.TabIndex = 3;
            // 
            // openSeriesButton
            // 
            this.openSeriesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openSeriesButton.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.openSeriesButton.Location = new System.Drawing.Point(605, 59);
            this.openSeriesButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.openSeriesButton.Name = "openSeriesButton";
            this.openSeriesButton.Size = new System.Drawing.Size(165, 38);
            this.openSeriesButton.TabIndex = 4;
            this.openSeriesButton.Text = "打开串口";
            this.openSeriesButton.UseVisualStyleBackColor = true;
            this.openSeriesButton.Click += new System.EventHandler(this.openSeriesButton_Click);
            // 
            // PPGRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 351);
            this.Controls.Add(this.openSeriesButton);
            this.Controls.Add(this.comNameComboBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.plotPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PPGRecordForm";
            this.Text = "PPG数据录制";
            this.Load += new System.EventHandler(this.WaveRecordForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plotPanel;
        private System.Windows.Forms.Timer plotTimer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label prLabel;
        private System.Windows.Forms.Label spo2Label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label piLabel;
        private System.Windows.Forms.ComboBox comNameComboBox;
        private System.Windows.Forms.Button openSeriesButton;
    }
}