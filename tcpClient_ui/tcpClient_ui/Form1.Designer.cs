namespace tcpClient_ui
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
            this.conBtn = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.sendingWorker = new System.ComponentModel.BackgroundWorker();
            this.receivingWorker = new System.ComponentModel.BackgroundWorker();
            this.dcBtn = new System.Windows.Forms.Button();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(12, 75);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceive.Size = new System.Drawing.Size(399, 121);
            this.txtReceive.TabIndex = 0;
            // 
            // conBtn
            // 
            this.conBtn.Location = new System.Drawing.Point(277, 6);
            this.conBtn.Name = "conBtn";
            this.conBtn.Size = new System.Drawing.Size(134, 24);
            this.conBtn.TabIndex = 1;
            this.conBtn.Text = "Connect";
            this.conBtn.UseVisualStyleBackColor = true;
            this.conBtn.Click += new System.EventHandler(this.conBtn_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(12, 212);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(310, 20);
            this.txtSend.TabIndex = 2;
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(328, 209);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(83, 24);
            this.sendBtn.TabIndex = 3;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // sendingWorker
            // 
            this.sendingWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.sendingWorker_DoWork);
            // 
            // receivingWorker
            // 
            this.receivingWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.receivingWorker_DoWork);
            // 
            // dcBtn
            // 
            this.dcBtn.Enabled = false;
            this.dcBtn.Location = new System.Drawing.Point(277, 44);
            this.dcBtn.Name = "dcBtn";
            this.dcBtn.Size = new System.Drawing.Size(134, 24);
            this.dcBtn.TabIndex = 4;
            this.dcBtn.Text = "Disconnect";
            this.dcBtn.UseVisualStyleBackColor = true;
            this.dcBtn.Click += new System.EventHandler(this.dcBtn_Click);
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(87, 6);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(140, 20);
            this.ipTextBox.TabIndex = 5;
            this.ipTextBox.Text = "127.0.0.1";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(87, 48);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(92, 20);
            this.portTextBox.TabIndex = 6;
            this.portTextBox.Text = "6300";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "IP Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Port Number:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 245);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.dcBtn);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.conBtn);
            this.Controls.Add(this.txtReceive);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCP Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Button conBtn;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button sendBtn;
        private System.ComponentModel.BackgroundWorker sendingWorker;
        private System.ComponentModel.BackgroundWorker receivingWorker;
        private System.Windows.Forms.Button dcBtn;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

