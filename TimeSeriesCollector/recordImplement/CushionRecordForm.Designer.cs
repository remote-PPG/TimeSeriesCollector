namespace TimeSeriesCollector.recordImplement
{
    partial class CushionRecordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CushionRecordForm));
            this.plot1Panel = new System.Windows.Forms.Panel();
            this.plotTimer = new System.Windows.Forms.Timer(this.components);
            this.openSeriesButton = new System.Windows.Forms.Button();
            this.comNameComboBox = new System.Windows.Forms.ComboBox();
            this.plot2Panel = new System.Windows.Forms.Panel();
            this.plot3Panel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.prLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plot1Panel
            // 
            this.plot1Panel.Location = new System.Drawing.Point(9, 10);
            this.plot1Panel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plot1Panel.Name = "plot1Panel";
            this.plot1Panel.Size = new System.Drawing.Size(911, 187);
            this.plot1Panel.TabIndex = 0;
            this.plot1Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.plot1Panel_Paint);
            // 
            // plotTimer
            // 
            this.plotTimer.Tick += new System.EventHandler(this.plotTimer_Tick);
            // 
            // openSeriesButton
            // 
            this.openSeriesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openSeriesButton.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.openSeriesButton.Location = new System.Drawing.Point(960, 98);
            this.openSeriesButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.openSeriesButton.Name = "openSeriesButton";
            this.openSeriesButton.Size = new System.Drawing.Size(124, 30);
            this.openSeriesButton.TabIndex = 6;
            this.openSeriesButton.Text = "打开串口";
            this.openSeriesButton.UseVisualStyleBackColor = true;
            this.openSeriesButton.Click += new System.EventHandler(this.openSeriesButton_Click);
            // 
            // comNameComboBox
            // 
            this.comNameComboBox.DropDownHeight = 200;
            this.comNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comNameComboBox.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comNameComboBox.FormattingEnabled = true;
            this.comNameComboBox.IntegralHeight = false;
            this.comNameComboBox.Location = new System.Drawing.Point(959, 60);
            this.comNameComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comNameComboBox.Name = "comNameComboBox";
            this.comNameComboBox.Size = new System.Drawing.Size(125, 33);
            this.comNameComboBox.TabIndex = 5;
            // 
            // plot2Panel
            // 
            this.plot2Panel.Location = new System.Drawing.Point(9, 202);
            this.plot2Panel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plot2Panel.Name = "plot2Panel";
            this.plot2Panel.Size = new System.Drawing.Size(911, 187);
            this.plot2Panel.TabIndex = 1;
            this.plot2Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.plot2Panel_Paint);
            // 
            // plot3Panel
            // 
            this.plot3Panel.Location = new System.Drawing.Point(9, 394);
            this.plot3Panel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plot3Panel.Name = "plot3Panel";
            this.plot3Panel.Size = new System.Drawing.Size(911, 187);
            this.plot3Panel.TabIndex = 1;
            this.plot3Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.plot3Panel_Paint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.prLabel, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(944, 221);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.4F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(140, 286);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("等线", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.LimeGreen;
            this.label2.Location = new System.Drawing.Point(2, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 95);
            this.label2.TabIndex = 5;
            this.label2.Text = "心率";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prLabel
            // 
            this.prLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prLabel.Font = new System.Drawing.Font("等线", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.prLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.prLabel.Location = new System.Drawing.Point(72, 0);
            this.prLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.prLabel.Name = "prLabel";
            this.prLabel.Size = new System.Drawing.Size(66, 95);
            this.prLabel.TabIndex = 4;
            this.prLabel.Text = "-";
            this.prLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CushionRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 588);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.plot2Panel);
            this.Controls.Add(this.plot3Panel);
            this.Controls.Add(this.openSeriesButton);
            this.Controls.Add(this.plot1Panel);
            this.Controls.Add(this.comNameComboBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CushionRecordForm";
            this.Text = "波形数据录制";
            this.Load += new System.EventHandler(this.WaveRecordForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plot1Panel;
        private System.Windows.Forms.Timer plotTimer;
        private System.Windows.Forms.Panel plot2Panel;
        private System.Windows.Forms.Button openSeriesButton;
        private System.Windows.Forms.ComboBox comNameComboBox;
        private System.Windows.Forms.Panel plot3Panel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label prLabel;
    }
}