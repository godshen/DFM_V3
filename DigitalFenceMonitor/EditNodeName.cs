using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net.Sockets;
using System.Net;

namespace DigitalFenceMonitor
{
    public partial class EditNodeName : Form
    {
        public EditNodeName()
        {
            InitializeComponent();
        }
        OleDbConnection conn = FormMain.conn;

        int forswitch = FormMain.Num_Node_Vol_CMD;
        private void EditNodeName_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
 
            switch (forswitch)
            {
                case 0: NodeName(); break;
                case 1: AreaNum(); break;
                case 2: WorkVoltage(); break;
                default: MessageBox.Show(forswitch.ToString()); break;
            }

        }

        private void btn_quit_Click(object sender, EventArgs e)
        {
            FormMain.Num_Node_Vol_CMD = -1;
            this.Close();
        }

        private void NodeName()
        {
            if (FormMain.CurrentNode != null)
            {
                this.comboBox_new.Visible = false;
                this.tBox_new.Visible = true;
                this.lb_old.Text = "现在名称";
                this.lb_new.Text = "新名称";
                tBox_old.Text = FormMain.CurrentNode.Split(',')[2];
                tboxoldtext = FormMain.CurrentNode;
            }
            else
            {
                FormMain.Num_Node_Vol_CMD = -1;
                this.Close();
            }
        }
        public delegate void thisMapNN(string name);
        public event thisMapNN thisMapNodeName;
        public string tboxoldtext = "";
        private void NodeNameOK()
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            string sql = " update tb_AreaSet set Descripe ='" + tBox_new.Text;
            sql += " 'Where Descripe = '" + tboxoldtext.Split(',')[2] + "'";
            sql += " and IPandPort = '" + tboxoldtext.Split(',')[0] + "'";
            sql += " and AreaNum = '" + tboxoldtext.Split(',')[1] + "'";
            OleDbCommand comm = new OleDbCommand(sql, conn);
            comm.ExecuteNonQuery();

            sql = " update tb_Map set MapInfo ='" +
                FormMain.CurrentNode.Split(',')[0] + "," +
                FormMain.CurrentNode.Split(',')[1] + "," +
                tBox_new.Text +
                " 'Where MapInfo = '" + FormMain.CurrentNode + "'";
            comm = new OleDbCommand(sql, conn);
            comm.ExecuteNonQuery();

            thisMapNodeName(tBox_new.Text);

            LoadTreeView();
            tBox_old.Text = tBox_new.Text;
            tBox_new.Text = "";
        }




        public delegate void SendData(byte[] data, EndPoint RemotePoint);
        public event SendData SendNumData;
        private void AreaNum()
        {
            this.comboBox_new.Visible = false;
            this.tBox_new.Visible = true;
            this.Text = "修改地址";
            this.lb_old.Text = "基站名称";
            this.lb_new.Text = "主机地址";       
            for (int i = 0; i < FormMain.StaSetCount; i++)
                tBox_old.Items.Add(FormMain.StaBuff[FormMain.RemotePointArr[i].ToString()]);
        }
        private void AreaNumOK()
        {
            if (tBox_old.Text != "")
            {
                byte[] data = new byte[6];
                data[0] = 0xAA;
                data[1] = 0xAE;
                data[2] = 0xF8;
                data[3] = 0x06;
                data[4] = (byte)(Convert.ToInt32(tBox_new.Text) & 0x0FF);
                data[5] = 0x00;
                int cou = tBox_old.SelectedIndex;
                FormMain.SetAreaNum = true;
                SendNumData(data, FormMain.RemotePointArr[cou]);
            }
        }





        private void WorkVoltage()
        {
            string[] buff = new string[7] { "低压-0.6KV","高压-1.6KV", "高压-2.6KV", "高压-3.6KV", "高压-4.6KV", "高压-5.6KV", "高压-6.6KV" };
            this.comboBox_new.Visible = true;
            this.tBox_new.Visible = false;

            this.lb_old.Text = "基站名称";
            this.lb_new.Text = "新电压";

            for (int i = 0; i < FormMain.StaSetCount; i++)
                tBox_old.Items.Add(FormMain.StaBuff[FormMain.RemotePointArr[i].ToString()]);
            for(int i=0;i<buff.Length;i++)
                comboBox_new.Items.Add(buff[i]);
        }
        private void WorkVoltageOK()
        {
            byte[] data = new byte[6];
            data[0] = 0xAA;
            data[1] = 0xAD;
            data[2] = 0xF8;
            data[3] = 0x06;
            data[4] = (byte)(comboBox_new.SelectedIndex);
            tBox_new.Text = data[4].ToString();
            data[5] = 0x00;
            int cou = tBox_old.SelectedIndex;
            SendNumData(data, FormMain.RemotePointArr[cou]);
        }




        public delegate void Load_TreeView();
        public event Load_TreeView LoadTreeView;

        private void btn_ok_Click(object sender, EventArgs e)
        {
            switch (forswitch)
            {
                case 0: NodeNameOK(); break;
                case 1: AreaNumOK(); break;
                case 2: WorkVoltageOK(); break;
                default: MessageBox.Show(forswitch.ToString()); break;
            }
            FormMain.Num_Node_Vol_CMD = -1;
            this.Close();
        }
    }
}
