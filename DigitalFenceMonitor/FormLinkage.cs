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
using System.IO.Ports;

namespace DigitalFenceMonitor
{
    public partial class FormLinkage : Form
    {
        public FormLinkage()
        {
            InitializeComponent();
        }
        OleDbConnection conn = FormMain.conn;


        private void btn_Done_Click(object sender, EventArgs e)
        {
            if (FormMain.LinkageSelect == 1)
            {

                if (textBox_Node.Text != "" && 
                    comboBox_StaName.Text!="" && 
                    comboBox_SerialNum.Text!="" &&
                    comboBox_DeviceAdd.Text!="")
                {
                    string msg = "";
                    int all = textBox_Node.Text.Split(',').Count();
                    for (int i = 0; i < textBox_Node.Text.Split(',').Count(); i++)
                    {
                        if (textBox_Node.Text.Split(',')[i] == "") all--;
                        else
                        {
                            try { byte num = Convert.ToByte(textBox_Node.Text.Split(',')[i]); msg += num.ToString() + " "; }
                            catch { all--; }
                        }

                    }
                    
                    string LinkageNodes = msg.Trim().Replace(' ', ',');
                    string LinkageConnect = comboBox_SerialNum.Text.Trim();
                    int area = 1;
                    if (comboBox_Position.Items.Count==2) { area = comboBox_Position.SelectedIndex + 1; }

                    FormMain.LinkageBuff[lb_thisip.Text + "-" + comboBox_DeviceAdd.Text + "-" + area.ToString()] = LinkageConnect + "-" + LinkageNodes;
                        
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    string cmd = "insert into tb_LinkageAlert (IpPortNodes,LinkInfo) values(";
                    cmd += "'" + LinkageConnect + "-" + LinkageNodes + "',";
                    cmd += "'" + lb_thisip.Text + "-" + comboBox_DeviceAdd.Text + "-" + area.ToString() + "'";
                    cmd += ")";
                    OleDbCommand comm = new OleDbCommand(cmd, conn);
                    try { comm.ExecuteNonQuery(); }
                    catch
                        {
                        cmd = "update tb_LinkageAlert set IpPortNodes = '" + LinkageConnect + "-" + LinkageNodes + "'";
                            cmd += " where LinkInfo = '" + lb_thisip.Text + "-" + comboBox_DeviceAdd.Text + "-" + area.ToString() + "'";
                            comm = new OleDbCommand(cmd, conn);
                            try { comm.ExecuteNonQuery(); }
                            catch {; }
                        }

                    MessageBox.Show("共有" + all.ToString() + "个结点被设置\r\n" + LinkageNodes + "");
                }
                else
                {
                    MessageBox.Show("请完整填写", "联动设置");
                }

            }
            else if (FormMain.LinkageSelect == 2)
            {

            }


        }

        private void FormLinkage_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            if (FormMain.LinkageSelect==1)
            {
                for (int i = 0; i < FormMain.StaSetCount; i++)
                {
                    string ipport = FormMain.RemotePointArr[i].ToString();
                    this.comboBox_StaName.Items.Add(FormMain.StaBuff[ipport]);
                }
            }
            else if (FormMain.LinkageSelect == 2)
            {
                this.Text = "电子地图设置";

                lab_LinkNode.Visible = false;
                textBox_Node.Visible = false;

                lab_alert0.Visible = false;
                lab_alert1.Visible = false;
            }
            

            rbtn_net.Checked = true;
            rbtn_serial.Checked = false;

        }

        
        

        private void rbtn_net_CheckedChanged(object sender, EventArgs e)
        {
            lab_SerialNum.Text = "网络地址";
            comboBox_SerialNum.Text = "";
        }

        private void rbtn_serial_CheckedChanged(object sender, EventArgs e)
        {
            lab_SerialNum.Text = "串口编号";
            comboBox_SerialNum.Items.Clear() ;
            string[] PortName = SerialPort.GetPortNames();
            if (PortName.Length !=0)
            {
                for (int i = 0; i < PortName.Length; i++)
                {
                    this.comboBox_SerialNum.Items.Add(PortName[i]);
                }
                comboBox_SerialNum.SelectedIndex = 0;
            }
            else
            {
                comboBox_SerialNum.Text = "未发现有效串口";
            }
        }

        private void FormLinkage_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain.LinkageSelect = -1;
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            if (FormMain.LinkageSelect == 1)
            {
                FormMain.LinkageBuff.Clear();
                if (conn.State == ConnectionState.Closed) conn.Open();
                string cmd = "delete * from tb_LinkageAlert";
                OleDbCommand comm = new OleDbCommand(cmd, conn);
                comm.ExecuteNonQuery();
            }
        }

        private void comboBox_StaName_TextChanged(object sender, EventArgs e)
        {
            lb_thisip.Text = FormMain.IPBuff[comboBox_StaName.Text];
            string sql = "select AreaNum from tb_AreaSet where IPandPort = '" + lb_thisip.Text + "'";
            DataTable tempdt = new DataTable();
            OleDbDataAdapter tempda = new OleDbDataAdapter(sql, conn);
            tempda.Fill(tempdt);

            comboBox_DeviceAdd.Items.Clear();
            comboBox_DeviceAdd.Text = "";

            for (int i = 0; i < tempdt.Rows.Count; i++)
            {
                if (i != 0)
                {
                    int x = Convert.ToInt16(tempdt.Rows[i]["AreaNum"]);
                    int y = Convert.ToInt16(tempdt.Rows[i - 1]["AreaNum"]);
                    if (x != y) comboBox_DeviceAdd.Items.Add(tempdt.Rows[i]["AreaNum"]);
                }
                else
                {
                    comboBox_DeviceAdd.Items.Add(tempdt.Rows[i]["AreaNum"]);
                }
            }
        }

        private void comboBox_DeviceAdd_TextChanged(object sender, EventArgs e)
        {
            string str1 = lb_thisip.Text;
            string str2 = comboBox_DeviceAdd.Text;

            if (conn.State == ConnectionState.Closed) conn.Open();
            string sql = "select Descripe from tb_AreaSet where IPandPort = '" + str1 + "' and AreaNum = '" + str2 + "'";
            DataTable tempdt = new DataTable();
            OleDbDataAdapter tempda = new OleDbDataAdapter(sql, conn);

            tempda.Fill(tempdt);
            comboBox_Position.Items.Clear();
            comboBox_Position.Text = "";

            if (tempdt.Rows.Count != 0)
            {
                for (int i = 0; i < tempdt.Rows.Count; i++)
                {
                    comboBox_Position.Items.Add(tempdt.Rows[i]["Descripe"]);
                }
                comboBox_Position.SelectedIndex = 0;
            }
        }
    }
}
