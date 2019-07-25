namespace serial_port_com
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textReceive = new System.Windows.Forms.TextBox();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.cmdClose = new System.Windows.Forms.Button();
            this.textSend = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textReceive
            // 
            this.textReceive.BackColor = System.Drawing.SystemColors.Control;
            this.textReceive.Location = new System.Drawing.Point(12, 12);
            this.textReceive.Multiline = true;
            this.textReceive.Name = "textReceive";
            this.textReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textReceive.Size = new System.Drawing.Size(392, 118);
            this.textReceive.TabIndex = 0;
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(208, 178);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(95, 25);
            this.cmdConnect.TabIndex = 1;
            this.cmdConnect.Text = "Connect";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(309, 178);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(95, 25);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // textSend
            // 
            this.textSend.Location = new System.Drawing.Point(12, 139);
            this.textSend.Name = "textSend";
            this.textSend.Size = new System.Drawing.Size(291, 20);
            this.textSend.TabIndex = 3;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(309, 139);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(95, 23);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 182);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 225);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.textSend);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdConnect);
            this.Controls.Add(this.textReceive);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Serial Port Communication";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textReceive;
        private System.Windows.Forms.Button cmdConnect;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.TextBox textSend;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ComboBox comboBox1;

    }
}

