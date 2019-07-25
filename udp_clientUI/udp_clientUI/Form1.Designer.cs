namespace udp_clientUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.sendingWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(12, 41);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceive.Size = new System.Drawing.Size(517, 119);
            this.txtReceive.TabIndex = 0;
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(12, 12);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(100, 24);
            this.connectBtn.TabIndex = 1;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(12, 169);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(411, 20);
            this.txtSend.TabIndex = 2;
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(429, 166);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(100, 24);
            this.sendBtn.TabIndex = 3;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // sendingWorker
            // 
            this.sendingWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.sendingWorker_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 211);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.txtReceive);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "UDP Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button sendBtn;
        private System.ComponentModel.BackgroundWorker sendingWorker;
    }
}

