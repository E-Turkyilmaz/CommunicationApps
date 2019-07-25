namespace CAN_bus_gui
{
    partial class CAN_Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CAN_Form1));
            this.slctDevBtn = new System.Windows.Forms.Button();
            this.deviceListCBox = new System.Windows.Forms.ComboBox();
            this.CANstartBtn = new System.Windows.Forms.Button();
            this.BaudRateCBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ModeSelectCBox = new System.Windows.Forms.ComboBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.transmitBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.RFcheckbox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.D1txt = new System.Windows.Forms.TextBox();
            this.D2txt = new System.Windows.Forms.TextBox();
            this.D3txt = new System.Windows.Forms.TextBox();
            this.D4txt = new System.Windows.Forms.TextBox();
            this.D5txt = new System.Windows.Forms.TextBox();
            this.D6txt = new System.Windows.Forms.TextBox();
            this.D7txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.D8txt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.CANstopBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // slctDevBtn
            // 
            this.slctDevBtn.Location = new System.Drawing.Point(24, 24);
            this.slctDevBtn.Name = "slctDevBtn";
            this.slctDevBtn.Size = new System.Drawing.Size(103, 23);
            this.slctDevBtn.TabIndex = 0;
            this.slctDevBtn.Text = "Select Device";
            this.slctDevBtn.UseVisualStyleBackColor = true;
            this.slctDevBtn.Click += new System.EventHandler(this.slctDevBtn_Click);
            // 
            // deviceListCBox
            // 
            this.deviceListCBox.DropDownWidth = 400;
            this.deviceListCBox.FormattingEnabled = true;
            this.deviceListCBox.Location = new System.Drawing.Point(281, 26);
            this.deviceListCBox.Name = "deviceListCBox";
            this.deviceListCBox.Size = new System.Drawing.Size(218, 21);
            this.deviceListCBox.TabIndex = 1;
            // 
            // CANstartBtn
            // 
            this.CANstartBtn.Location = new System.Drawing.Point(24, 86);
            this.CANstartBtn.Name = "CANstartBtn";
            this.CANstartBtn.Size = new System.Drawing.Size(103, 23);
            this.CANstartBtn.TabIndex = 2;
            this.CANstartBtn.Text = "Start CAN";
            this.CANstartBtn.UseVisualStyleBackColor = true;
            this.CANstartBtn.Click += new System.EventHandler(this.CANstartBtn_Click);
            // 
            // BaudRateCBox
            // 
            this.BaudRateCBox.FormattingEnabled = true;
            this.BaudRateCBox.Location = new System.Drawing.Point(281, 88);
            this.BaudRateCBox.Name = "BaudRateCBox";
            this.BaudRateCBox.Size = new System.Drawing.Size(121, 21);
            this.BaudRateCBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Device:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Baudrate:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mode:";
            // 
            // ModeSelectCBox
            // 
            this.ModeSelectCBox.FormattingEnabled = true;
            this.ModeSelectCBox.Location = new System.Drawing.Point(281, 127);
            this.ModeSelectCBox.Name = "ModeSelectCBox";
            this.ModeSelectCBox.Size = new System.Drawing.Size(121, 21);
            this.ModeSelectCBox.TabIndex = 7;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(281, 181);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(121, 20);
            this.txtID.TabIndex = 8;
            // 
            // transmitBtn
            // 
            this.transmitBtn.Location = new System.Drawing.Point(24, 179);
            this.transmitBtn.Name = "transmitBtn";
            this.transmitBtn.Size = new System.Drawing.Size(103, 23);
            this.transmitBtn.TabIndex = 9;
            this.transmitBtn.Text = "Transmit Data";
            this.transmitBtn.UseVisualStyleBackColor = true;
            this.transmitBtn.Click += new System.EventHandler(this.transmitBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(163, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "ID:";
            // 
            // RFcheckbox
            // 
            this.RFcheckbox.AutoSize = true;
            this.RFcheckbox.Location = new System.Drawing.Point(281, 220);
            this.RFcheckbox.Name = "RFcheckbox";
            this.RFcheckbox.Size = new System.Drawing.Size(65, 17);
            this.RFcheckbox.TabIndex = 11;
            this.RFcheckbox.Text = "Enabled";
            this.RFcheckbox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(163, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Remote Frame:";
            // 
            // D1txt
            // 
            this.D1txt.Location = new System.Drawing.Point(281, 275);
            this.D1txt.MaxLength = 2;
            this.D1txt.Name = "D1txt";
            this.D1txt.Size = new System.Drawing.Size(22, 20);
            this.D1txt.TabIndex = 13;
            // 
            // D2txt
            // 
            this.D2txt.Location = new System.Drawing.Point(309, 275);
            this.D2txt.MaxLength = 2;
            this.D2txt.Name = "D2txt";
            this.D2txt.Size = new System.Drawing.Size(22, 20);
            this.D2txt.TabIndex = 14;
            // 
            // D3txt
            // 
            this.D3txt.Location = new System.Drawing.Point(337, 275);
            this.D3txt.MaxLength = 2;
            this.D3txt.Name = "D3txt";
            this.D3txt.Size = new System.Drawing.Size(22, 20);
            this.D3txt.TabIndex = 15;
            // 
            // D4txt
            // 
            this.D4txt.Location = new System.Drawing.Point(365, 275);
            this.D4txt.MaxLength = 2;
            this.D4txt.Name = "D4txt";
            this.D4txt.Size = new System.Drawing.Size(22, 20);
            this.D4txt.TabIndex = 16;
            // 
            // D5txt
            // 
            this.D5txt.Location = new System.Drawing.Point(393, 275);
            this.D5txt.MaxLength = 2;
            this.D5txt.Name = "D5txt";
            this.D5txt.Size = new System.Drawing.Size(22, 20);
            this.D5txt.TabIndex = 17;
            // 
            // D6txt
            // 
            this.D6txt.Location = new System.Drawing.Point(421, 275);
            this.D6txt.MaxLength = 2;
            this.D6txt.Name = "D6txt";
            this.D6txt.Size = new System.Drawing.Size(22, 20);
            this.D6txt.TabIndex = 18;
            // 
            // D7txt
            // 
            this.D7txt.Location = new System.Drawing.Point(449, 275);
            this.D7txt.MaxLength = 2;
            this.D7txt.Name = "D7txt";
            this.D7txt.Size = new System.Drawing.Size(22, 20);
            this.D7txt.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(282, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "D1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(310, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "D2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(338, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "D3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(366, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "D4";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(394, 259);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "D5";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(422, 259);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "D6";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(450, 259);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "D7";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(478, 259);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "D8";
            // 
            // D8txt
            // 
            this.D8txt.Location = new System.Drawing.Point(477, 275);
            this.D8txt.MaxLength = 2;
            this.D8txt.Name = "D8txt";
            this.D8txt.Size = new System.Drawing.Size(22, 20);
            this.D8txt.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(163, 278);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "DLC:";
            // 
            // CANstopBtn
            // 
            this.CANstopBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CANstopBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CANstopBtn.Location = new System.Drawing.Point(166, 315);
            this.CANstopBtn.Name = "CANstopBtn";
            this.CANstopBtn.Size = new System.Drawing.Size(193, 64);
            this.CANstopBtn.TabIndex = 30;
            this.CANstopBtn.Text = "Stop CAN";
            this.CANstopBtn.UseVisualStyleBackColor = true;
            this.CANstopBtn.Click += new System.EventHandler(this.CANstopBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(504, 53);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 71);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(504, 92);
            this.tableLayoutPanel2.TabIndex = 32;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 169);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(504, 140);
            this.tableLayoutPanel3.TabIndex = 33;
            // 
            // CAN_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 400);
            this.Controls.Add(this.CANstopBtn);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.D8txt);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.D7txt);
            this.Controls.Add(this.D6txt);
            this.Controls.Add(this.D5txt);
            this.Controls.Add(this.D4txt);
            this.Controls.Add(this.D3txt);
            this.Controls.Add(this.D2txt);
            this.Controls.Add(this.D1txt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RFcheckbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.transmitBtn);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.ModeSelectCBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BaudRateCBox);
            this.Controls.Add(this.CANstartBtn);
            this.Controls.Add(this.deviceListCBox);
            this.Controls.Add(this.slctDevBtn);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CAN_Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAN INTERFACE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button slctDevBtn;
        private System.Windows.Forms.ComboBox deviceListCBox;
        private System.Windows.Forms.Button CANstartBtn;
        private System.Windows.Forms.ComboBox BaudRateCBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ModeSelectCBox;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button transmitBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox RFcheckbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox D1txt;
        private System.Windows.Forms.TextBox D2txt;
        private System.Windows.Forms.TextBox D3txt;
        private System.Windows.Forms.TextBox D4txt;
        private System.Windows.Forms.TextBox D5txt;
        private System.Windows.Forms.TextBox D6txt;
        private System.Windows.Forms.TextBox D7txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox D8txt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button CANstopBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}

