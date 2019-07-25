namespace udp_clientUI
{
    partial class UDPclient_SendBack_Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UDPclient_SendBack_Form2));
            this.sendBtn = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.sendingWorker = new System.ComponentModel.BackgroundWorker();
            this.receivingWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(431, 170);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(100, 24);
            this.sendBtn.TabIndex = 7;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(14, 173);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(411, 20);
            this.txtSend.TabIndex = 6;
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(14, 16);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(100, 24);
            this.connectBtn.TabIndex = 5;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(14, 45);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceive.Size = new System.Drawing.Size(517, 119);
            this.txtReceive.TabIndex = 4;
            // 
            // receivingWorker
            // 
            this.receivingWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.receivingWorker_DoWork);
            //
            // sendingWorker
            //
            this.sendingWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.receivingWorker_DoWork);
            //
            // UDPclient_SendBack_Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 211);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.txtReceive);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UDPclient_SendBack_Form2";
            this.Text = "UDP Client(SendBack)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.TextBox txtReceive;
        private System.ComponentModel.BackgroundWorker sendingWorker;
        private System.ComponentModel.BackgroundWorker receivingWorker;
    }
}