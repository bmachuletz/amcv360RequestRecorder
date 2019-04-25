using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading.Tasks;

/*
 * First of all: I don't want to win any coding competition with the code used in this project :)
 * If you have any suggestions on functionality, i'll perhaps integrate that.
 * AND
 * Feel free to use the snippets to integrate the 360 vacuum cleaner in your own applications.
 */

namespace amcv
{
    public partial class MainForm : Form
    {
        TitaniumEngine tEngine;
        ContextMenuStrip contextMenuStrip;

        public MainForm()
        {
            InitializeComponent();
            

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.None);
            listView1.Columns[0].Width = 70;
          
            listView1.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.None);
            listView1.Columns[1].Width = 200;


            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add("Replay Request");

            contextMenuStrip.ItemClicked += ContextMenuStrip_ItemClicked;

            listView1.ContextMenuStrip = contextMenuStrip;

            listView1.MouseClick += ListView1_MouseClick;
        }

        private void ContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (listView1.SelectedItems[0].Tag.ToString() != "Cookie-Content")
            {
                QihooRequest request = new QihooRequest
                {
                    cookie = tEngine.cmdModel.Cookie,
                    body = listView1.SelectedItems[0].Tag.ToString()
                };

                Task.Run(() =>
                {
                    HttpWebResponse response;
                    WebEngine.Request_q_smart_360_cn(request, out response);
                });
            }
        }

        private void ListView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location))
                {
                    listView1.ContextMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private void GenerateCertificateButton_Click(object sender, EventArgs e)
        {
            tEngine = new TitaniumEngine();
            FileServer filerserver = new FileServer();

            GenerateCertificateButton.Enabled = false;
            StartProxyButton.Enabled = true;
            
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    if (!ip.ToString().Contains("169.254"))
                    {
                        LinkLabel linkLabel = new LinkLabel();
                        linkLabel.AutoSize = true;
                    
                        linkLabel.Text = string.Format("http://{0}/Temporary_Listen_Addresses/", ip.ToString());
                        ipAdressPanel.Controls.Add(linkLabel);
                        linkLabel.Click += LinkLabel_Click;
                    }
                }
            }

            ipAdressPanel.Visible = true;
            downloadToPhoneLabel.Visible = true;

            StartProxyButton.Visible = true;
        }

        private void LinkLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Link saved to clipboard.");
            Clipboard.SetText(((LinkLabel)sender).Text.ToString());

        }

        private void StartProxyButton_Click(object sender, EventArgs e)
        {
            tEngine.ProxyStart();

            tEngine.StartCommandLoaded += TEngine_StartCommandLoaded;
            tEngine.StopCommandLoaded += TEngine_StopCommandLoaded;
            tEngine.ChargeCommandLoaded += TEngine_ChargeCommandLoaded;
            tEngine.CompleteHandler += TEngine_CompleteHandler;
            tEngine.CookieLoaded += TEngine_CookieLoaded;

            tEngine.UnknownCommandReceived += TEngine_UnknownCommandReceived;

            StartProxyButton.Text = "Stop Proxy";
            StartProxyButton.Click -= StartProxyButton_Click;
            StartProxyButton.Click += StartProxyButton_Click1;
        }

        private void TEngine_UnknownCommandReceived(object sender, UnknownCommandEventArgs e)
        {
            List<string> row = new List<string> { "unknown-command", e.command };

            ListViewItem item = new ListViewItem(row.ToArray());
            item.Tag = "unknown-command";

            listView2.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                listView2.Items.Add(item);
                listView2.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView2.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            });
        }

        private void TEngine_CompleteHandler(object sender, EventArgs e)
        {
            MessageBox.Show("Capture of the currently support commands is complete.\n");

            SendAnalyzedDataButton.Invoke((MethodInvoker)delegate {
                SendAnalyzedDataButton.Enabled = true;
            });
            SaveResultButton.Invoke((MethodInvoker)delegate
            {
                SaveResultButton.Enabled = true;
            });

            string fileContent = Newtonsoft.Json.JsonConvert.SerializeObject(tEngine.cmdModel);
            if (!Directory.Exists("result"))
            {
                Directory.CreateDirectory("result");
            }
            File.WriteAllText(@"result\result.json", fileContent);
        }

        private void StartProxyButton_Click1(object sender, EventArgs e)
        {
            tEngine.ProxyStop();
            StartProxyButton.Text = "Start Proxy";
            StartProxyButton.Click += StartProxyButton_Click;
            StartProxyButton.Click -= StartProxyButton_Click1;
        }

        private void TEngine_CookieLoaded(object sender, EventArgs e)
        {
            List<string> row = new List<string> { "Cookie-Content", tEngine.cmdModel.Cookie };
            
            ListViewItem item = new ListViewItem(row.ToArray());
            item.Tag = "Cookie-Content";

            listView1.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                listView1.Items.Add(item);
                listView1.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            });
            
        }

        private void TEngine_ChargeCommandLoaded(object sender, EventArgs e)
        {

            List<string> row = new List<string> { "ChargeCommand", tEngine.cmdModel.ChargeCleaningCommand };
            ListViewItem item = new ListViewItem(row.ToArray());
            item.Tag = tEngine.cmdModel.ChargeCleaningCommand;

            listView1.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                listView1.Items.Add(item);
                listView1.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            });
        }

        private void TEngine_StopCommandLoaded(object sender, EventArgs e)
        {
            List<string> row = new List<string> { "StopCleaningCommand", tEngine.cmdModel.StopCleaningCommand };
            ListViewItem item = new ListViewItem(row.ToArray());
            item.Tag = tEngine.cmdModel.StopCleaningCommand;

            listView1.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                listView1.Items.Add(item);
                listView1.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            });
        }

        private void TEngine_StartCommandLoaded(object sender, EventArgs e)
        {
            List<string> row = new List<string> { "StartCleaningCommand", tEngine.cmdModel.StartCleaningCommand };
            ListViewItem item = new ListViewItem(row.ToArray());
            item.Tag = tEngine.cmdModel.StartCleaningCommand;

            listView1.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                listView1.Items.Add(item);
                listView1.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            });
        }

        private void SendAnalyzedDataButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Currently not implemented. Please send result via email to amcv@mnetworx.de");
        }

        private void SaveResultButton_Click(object sender, EventArgs e)
        {
            string fileContent = Newtonsoft.Json.JsonConvert.SerializeObject(tEngine.cmdModel);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, fileContent);
            }
        }
    }
}
