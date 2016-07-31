using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace DigitalFenceMonitor
{
    public partial class SystemConfig : Form
    {
        FormMain fm = new FormMain();

        public delegate void UpdateMsgTB(string msg);

        public SystemConfig()
        {
            InitializeComponent();
        }

        private void SystemConfig_Load(object sender, EventArgs e)
        {
            if (FormMain.AddressList.Length>0)
            {
                for (int i = 0; i < FormMain.AddressList.Length; i++)
                    comboBox_localIP.Items.Add(FormMain.AddressList[i].ToString());
                comboBox_localIP.SelectedIndex = 0;
            }
            
        }



        public event UpdateMsgTB UpdateMsgTextBox;

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            string localip = comboBox_localIP.Text;
            string localport = textBox_localPort.Text; 

            if(fm.getValidIP(localip) != null && fm.getValidPort(localport) != -1) { 
                FormMain.localIP = fm.getValidIP(localip);
                FormMain.localPort = fm.getValidPort(localport);
                UpdateMsgTextBox("已设置->本机IP:Port=" + localip + ":" + localport + "    请更新配置");
                this.Close();
            }
            else
            {
                if (fm.getValidIP(localip) == null)
                    UpdateMsgTextBox("本地IP获取失败");
                else { 
                    UpdateMsgTextBox("本地端口输入有误");
                    UpdateMsgTextBox("本机->IP:Port=" + FormMain.localIP + ":" + FormMain.localPort + "");
                }
            }

        }
    }
}
