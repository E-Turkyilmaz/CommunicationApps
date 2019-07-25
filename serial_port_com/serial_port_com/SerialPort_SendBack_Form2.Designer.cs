namespace serial_port_com
{
    partial class SerialPort_SendBack_Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialPort_SendBack_Form2));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.textReceive = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 192);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(309, 188);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(95, 25);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(208, 188);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(95, 25);
            this.cmdConnect.TabIndex = 6;
            this.cmdConnect.Text = "Connect";
            this.cmdConnect.UseVisualStyleBackColor = true;
            // 
            // textReceive
            // 
            this.textReceive.BackColor = System.Drawing.SystemColors.Control;
            this.textReceive.Location = new System.Drawing.Point(12, 12);
            this.textReceive.Multiline = true;
            this.textReceive.Name = "textReceive";
            this.textReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textReceive.Size = new System.Drawing.Size(392, 170);
            this.textReceive.TabIndex = 9;
            // 
            // SerialPort_SendBack_Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 225);
            this.Controls.Add(this.textReceive);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdConnect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SerialPort_SendBack_Form2";
            this.Text = "Serial Communication(SendBack)";
            this.Load += new System.EventHandler(this.SerialPort_SendBack_Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdConnect;
        private System.Windows.Forms.TextBox textReceive;
    }
}