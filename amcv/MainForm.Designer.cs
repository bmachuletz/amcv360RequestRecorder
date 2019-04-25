namespace amcv
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listView1 = new System.Windows.Forms.ListView();
            this.typeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GenerateCertificateButton = new System.Windows.Forms.Button();
            this.StartProxyButton = new System.Windows.Forms.Button();
            this.downloadToPhoneLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.ipAdressPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SaveResultButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SendAnalyzedDataButton = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.typeHeader,
            this.dataHeader});
            this.listView1.Location = new System.Drawing.Point(3, 384);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1184, 214);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // typeHeader
            // 
            this.typeHeader.Text = "Type";
            // 
            // dataHeader
            // 
            this.dataHeader.Text = "Data";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(459, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Captured Data (currently supported commands: start, pause, charging).";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1184, 102);
            this.label2.TabIndex = 2;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // GenerateCertificateButton
            // 
            this.GenerateCertificateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GenerateCertificateButton.AutoSize = true;
            this.GenerateCertificateButton.Location = new System.Drawing.Point(3, 105);
            this.GenerateCertificateButton.Name = "GenerateCertificateButton";
            this.GenerateCertificateButton.Size = new System.Drawing.Size(1184, 32);
            this.GenerateCertificateButton.TabIndex = 1;
            this.GenerateCertificateButton.Text = "Generate Certificate";
            this.GenerateCertificateButton.UseVisualStyleBackColor = true;
            this.GenerateCertificateButton.Click += new System.EventHandler(this.GenerateCertificateButton_Click);
            // 
            // StartProxyButton
            // 
            this.StartProxyButton.AutoSize = true;
            this.StartProxyButton.Enabled = false;
            this.StartProxyButton.Location = new System.Drawing.Point(3, 183);
            this.StartProxyButton.Name = "StartProxyButton";
            this.StartProxyButton.Size = new System.Drawing.Size(1184, 32);
            this.StartProxyButton.TabIndex = 2;
            this.StartProxyButton.Text = "Start Proxy";
            this.StartProxyButton.UseVisualStyleBackColor = true;
            this.StartProxyButton.Click += new System.EventHandler(this.StartProxyButton_Click);
            // 
            // downloadToPhoneLabel
            // 
            this.downloadToPhoneLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadToPhoneLabel.AutoSize = true;
            this.downloadToPhoneLabel.Location = new System.Drawing.Point(3, 146);
            this.downloadToPhoneLabel.Name = "downloadToPhoneLabel";
            this.downloadToPhoneLabel.Size = new System.Drawing.Size(1184, 34);
            this.downloadToPhoneLabel.TabIndex = 8;
            this.downloadToPhoneLabel.Text = "Please download certificate to your mobile phone. I\'ve you can copy the URL to yo" +
    "ur\r\nclipboard by clicking the appropriate URL.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(538, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Configure your phone to use the proxy. Please use one of the following IP-Adresse" +
    "s.";
            this.label4.Visible = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.GenerateCertificateButton);
            this.flowLayoutPanel2.Controls.Add(this.ipAdressPanel);
            this.flowLayoutPanel2.Controls.Add(this.downloadToPhoneLabel);
            this.flowLayoutPanel2.Controls.Add(this.StartProxyButton);
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel2.Controls.Add(this.listView1);
            this.flowLayoutPanel2.Controls.Add(this.label6);
            this.flowLayoutPanel2.Controls.Add(this.listView2);
            this.flowLayoutPanel2.Controls.Add(this.label5);
            this.flowLayoutPanel2.Controls.Add(this.SendAnalyzedDataButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1229, 935);
            this.flowLayoutPanel2.TabIndex = 6;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // ipAdressPanel
            // 
            this.ipAdressPanel.AutoSize = true;
            this.ipAdressPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ipAdressPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ipAdressPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ipAdressPanel.Location = new System.Drawing.Point(3, 143);
            this.ipAdressPanel.Name = "ipAdressPanel";
            this.ipAdressPanel.Size = new System.Drawing.Size(1184, 0);
            this.ipAdressPanel.TabIndex = 9;
            this.ipAdressPanel.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1184, 119);
            this.label3.TabIndex = 10;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.SaveResultButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 340);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1184, 38);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // SaveResultButton
            // 
            this.SaveResultButton.Enabled = false;
            this.SaveResultButton.Location = new System.Drawing.Point(468, 8);
            this.SaveResultButton.Name = "SaveResultButton";
            this.SaveResultButton.Size = new System.Drawing.Size(113, 30);
            this.SaveResultButton.TabIndex = 2;
            this.SaveResultButton.Text = "Save Result";
            this.SaveResultButton.UseVisualStyleBackColor = true;
            this.SaveResultButton.Click += new System.EventHandler(this.SaveResultButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 843);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(500, 34);
            this.label5.TabIndex = 13;
            this.label5.Text = "You can replay the request using the context menu.\r\nReplay URL is always ther 360" +
    "-Cloud (https://q.smart.360.cn/clean/cmd/send).";
            // 
            // SendAnalyzedDataButton
            // 
            this.SendAnalyzedDataButton.AutoSize = true;
            this.SendAnalyzedDataButton.Enabled = false;
            this.SendAnalyzedDataButton.Location = new System.Drawing.Point(3, 880);
            this.SendAnalyzedDataButton.Name = "SendAnalyzedDataButton";
            this.SendAnalyzedDataButton.Size = new System.Drawing.Size(1184, 44);
            this.SendAnalyzedDataButton.TabIndex = 11;
            this.SendAnalyzedDataButton.Text = "Send data to the devlopers by email for analyzing the request.\r\nI promise you to " +
    "treat the data confidentially.";
            this.SendAnalyzedDataButton.UseVisualStyleBackColor = true;
            this.SendAnalyzedDataButton.Click += new System.EventHandler(this.SendAnalyzedDataButton_Click);
            // 
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView2.Location = new System.Drawing.Point(3, 626);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1184, 214);
            this.listView2.TabIndex = 14;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Type";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Data";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 601);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label6.Size = new System.Drawing.Size(1184, 22);
            this.label6.TabIndex = 15;
            this.label6.Text = "Captured Data (unknown commands).";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1229, 935);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.label4);
            this.Name = "MainForm";
            this.Text = "Analyze My Chinese Vacuum";
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader typeHeader;
        private System.Windows.Forms.ColumnHeader dataHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GenerateCertificateButton;
        private System.Windows.Forms.Button StartProxyButton;
        private System.Windows.Forms.Label downloadToPhoneLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel ipAdressPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SendAnalyzedDataButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button SaveResultButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

