namespace udp_serverUI
{
    partial class UDPlistener_SendBack_Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UDPlistener_SendBack_Form2));
            this.stopBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.receivingWorker = new System.ComponentModel.BackgroundWorker();
            this.sendingWorker = new System.ComponentModel.BackgroundWorker();
            this.sendBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stopBtn
            // 
            this.stopBtn.Enabled = false;
            this.stopBtn.Location = new System.Drawing.Point(118, 17);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(100, 24);
            this.stopBtn.TabIndex = 5;
            this.stopBtn.Text = "Stop Server";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(12, 17);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(100, 24);
            this.startBtn.TabIndex = 4;
            this.startBtn.Text = "Start Server";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(12, 46);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceive.Size = new System.Drawing.Size(520, 148);
            this.txtReceive.TabIndex = 3;
            // 
            // receivingWorker
            // 
            this.receivingWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.receivingWorker_DoWork);
            // 
            // sendingWorker
            // 
            this.sendingWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.sendingWorker_DoWork);
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(480, 17);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(52, 23);
            this.sendBtn.TabIndex = 6;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendData);
            // 
            // UDPlistener_SendBack_Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 211);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.txtReceive);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UDPlistener_SendBack_Form2";
            this.Text = "UDP Listener(SendBack)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.TextBox txtReceive;
        private System.ComponentModel.BackgroundWorker receivingWorker;
        private System.ComponentModel.BackgroundWorker sendingWorker;
        private System.Windows.Forms.Button sendBtn;
    }
}