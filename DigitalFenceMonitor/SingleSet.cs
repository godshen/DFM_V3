using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net;
using System.Collections.Generic;

namespace DigitalFenceMonitor
{
    public partial class SingleSet : Form
    {
        OleDbConnection conn = FormMain.conn;
        
        public SingleSet()
        {
            InitializeComponent();
        }

        public delegate void SendDt(byte[] data, EndPoint RemotePoin);
        public event SendDt SendData;


        private void SingleSet_Load(object sender, EventArgs e)
        {
            SingleSetInit();
        }
        private void SingleSetInit()
        {
            
            for (int i = 0; i < FormMain.StaSetCount; i++)
            {
                string ipport = FormMain.RemotePointArr[i].ToString();
                this.comboBox_StaName.Items.Add(FormMain.StaBuff[ipport]);
            }
                

            this.comboBox_BuCheFang.Items.Add("撤防");
            this.comboBox_BuCheFang.Items.Add("布防");
            comboBox_BuCheFang.SelectedIndex = 0;

            this.comboBox_Beep.Items.Add("关闭蜂鸣器");
            this.comboBox_Beep.Items.Add("打开蜂鸣器");
            comboBox_Beep.SelectedIndex = 0;

            this.comboBox_Mode.Items.Add("脉冲模式");
            this.comboBox_Mode.Items.Add("智能模式");
            this.comboBox_Mode.Items.Add("静电模式");
            comboBox_Mode.SelectedIndex = 0;

            this.comboBox_JingDian.Items.Add("精度等级1");
            this.comboBox_JingDian.Items.Add("精度等级2");
            this.comboBox_JingDian.Items.Add("精度等级3");
            this.comboBox_JingDian.Items.Add("精度等级4");
            comboBox_JingDian.SelectedIndex = 0;

            for (int i = 0; i < 10; i++)
                this.comboBox_Voltage.Items.Add(i.ToString());
            comboBox_Voltage.SelectedIndex = 0;


        }
        private void but_confirm0_Click(object sender, EventArgs e)
        {

            if (comboBox_StaName.Text!="" && comboBox_DeviceAdd.Text!="")
            {
                string temp = FormMain.IPBuff[ comboBox_StaName.Text ];
                IPAddress IPadr = IPAddress.Parse(temp.Split(':')[0]);//先把string类型转换成IPAddress类型
                IPEndPoint EndPoint = new IPEndPoint(IPadr, int.Parse(temp.Split(':')[1]));//传递IPAddress和Port

                byte[] data = new byte[7];
                data[0] = 0xAA;
                data[1] = Convert.ToByte(comboBox_DeviceAdd.Text.ToString());
                data[2] = 0xF8;
                data[3] = 0x07;
                data[5] = Convert.ToByte(comboBox_Voltage.Text);
                data[6] = 0;
                
                byte num3 = (byte)comboBox_JingDian.SelectedIndex;
                byte num2 = (byte)comboBox_Mode.SelectedIndex;
                byte num1 = (byte)comboBox_Beep.SelectedIndex;
                byte num0 = (byte)comboBox_BuCheFang.SelectedIndex;

                data[4] = (byte)((byte)num3 * 64 + (byte)num2 * 16 + (byte)num1 * 8 + (byte)num0 * 4 + (byte)0 * 2 + (byte)1 * 1);

                SendData(data, EndPoint);
                InfoUpdate(temp, comboBox_DeviceAdd.Text, comboBox_BuCheFang.Text + ", 电压" + comboBox_Voltage.Text + ".6Kv");
            }
            else
            {
                MessageBox.Show("请完整填写");
            }            



        }
        private string[] AlertInfoBuff = new string[7] { "NowDate", "NowTime", "StationIP", "StationName", "AreaNum", "AlertType", "Descripe" };
        private void InfoUpdate(string StaIP, string AreaNum, string AlertType)
        {
            string datetime = DateTime.Now.ToString();
            string[] alertinfobuff = new string[7];
            alertinfobuff[0] = datetime.Split(' ')[0];
            alertinfobuff[1] = datetime.Split(' ')[1];
            alertinfobuff[2] = StaIP;
            alertinfobuff[3] = FormMain.StaBuff[StaIP];
            alertinfobuff[4] = AreaNum;
            alertinfobuff[5] = AlertType;
            alertinfobuff[6] = "全部";

            string cmd = "insert into tb_Content (NowDate,NowTime,StationIP,StationName,AreaNum," +
                "AlertType,Descripe,OperationInfo,Operator,OperationResult) values(";
            for (int i = 0; i < AlertInfoBuff.Length; i++)
                cmd += "'" + alertinfobuff[i] + "',";
            cmd += "'" + "无" + "',";
            cmd += "'" + "admin" + "',";
            cmd += "'" + "已发送" + "'";
            cmd += ")";

            OleDbCommand comm = new OleDbCommand(cmd, conn);
            try { comm.ExecuteNonQuery(); }
            catch {; }
        }
        private void but_confirm1_Click(object sender, EventArgs e)
        {
            if (rbtn_daynight_on.Checked)
            {
                if (comboBox_StaName.Text != "" && comboBox_DeviceAdd.Text != "" && textBox_dayTime.Text != "" && textBox_nightTime.Text != "")
                {
                    try
                    {
                        string dt0, dt1;
                        dt0 = "20000101" + textBox_dayTime.Text.Remove(2, 1) + "00";
                        dt1 = "20000101" + textBox_nightTime.Text.Remove(2, 1) + "00";
                        DateTime day = DateTime.ParseExact(dt0, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                        DateTime night = DateTime.ParseExact(dt1, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                        int dayvol = comboBox_dayVol.SelectedIndex;
                        int nightvol = comboBox_nightVol.SelectedIndex;

                        FormMain.DayNightBuff[comboBox_StaName.Text.Split('-')[1] + "," + comboBox_DeviceAdd.Text] = new FormMain.DayNightBuffCLS(day, night, dayvol, nightvol);
                        string cmd = "insert into tb_DayNightAlert (IpPortNum,Status) values(";
                        cmd += "'" + comboBox_StaName.Text.Split('-')[1] + "," + comboBox_DeviceAdd.Text + "',";
                        cmd += "'" + textBox_dayTime.Text + "-" + dayvol + "-" + textBox_nightTime.Text + "-" + nightvol + "'";
                        cmd += ")";
                        OleDbCommand comm = new OleDbCommand(cmd, conn);
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine(exp.Message.Length);
                        if (exp.Message.Length == 30)
                            MessageBox.Show("时间格式错误", "提示");
                        else if (exp.Message.Length != 30)
                        {
                            string cmd = "update tb_DayNightAlert set Status = ";
                            cmd += "'" + textBox_dayTime.Text + "-" + comboBox_dayVol.SelectedIndex + "-" + textBox_nightTime.Text + "-" + comboBox_nightVol.SelectedIndex + "'";
                            cmd += " where IpPortNum = ";
                            cmd += "'" + comboBox_StaName.Text.Split('-')[1] + "," + comboBox_DeviceAdd.Text + "'";
                            OleDbCommand comm = new OleDbCommand(cmd, conn);
                            comm.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请完整填写");
                }
            }
            else
            {
                if (comboBox_StaName.Text != "" && comboBox_DeviceAdd.Text != "")
                {
                    try
                    {
                        FormMain.DayNightBuff.Remove(comboBox_StaName.Text.Split('-')[1] + "," + comboBox_DeviceAdd.Text);
                        string cmd = "delete * from tb_DayNightAlert Where IpPortNum =";
                        cmd += "'" + comboBox_StaName.Text.Split('-')[1] + "," + comboBox_DeviceAdd.Text + "'";
                        OleDbCommand comm = new OleDbCommand(cmd, conn);
                        comm.ExecuteNonQuery();
                    }
                    catch { MessageBox.Show("删除失败"); }
                }
                else
                {
                    MessageBox.Show("请完整填写");
                }
            }
        }

        private void DataBaseSelect(string str)
        {
            lb_thisip.Text = FormMain.IPBuff[str] ;
            string sql = "select AreaNum from tb_AreaSet where IPandPort = '"+ lb_thisip.Text + "'";
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

        private void comboBox_StaName_TextChanged(object sender, EventArgs e)
        {
            DataBaseSelect(comboBox_StaName.Text);
        }

        private void rbtn_daynight_off_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_daynight_off.Checked)
            {
                rbtn_daynight_on.Checked = false;
            }
            else
            {
                rbtn_daynight_on.Checked = true;
            }
        }

        private void rbtn_daynight_on_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_daynight_on.Checked)
            {
                rbtn_daynight_off.Checked = false;

                lab_dayTime.Enabled = true;
                lab_dayVol.Enabled = true;
                lab_nightTime.Enabled = true;
                lab_nightVol.Enabled = true;

                textBox_dayTime.Enabled = true;
                comboBox_dayVol.Enabled = true;
                textBox_nightTime.Enabled = true;
                comboBox_nightVol.Enabled = true;

                for (int i = 0; i < 10; i++)
                {
                    comboBox_dayVol.Items.Add(i.ToString());
                    comboBox_nightVol.Items.Add(i.ToString());
                }
                comboBox_dayVol.SelectedIndex = 0;
                comboBox_nightVol.SelectedIndex = 5;

            }
            else
            {
                rbtn_daynight_off.Checked = true;

                comboBox_dayVol.Text = "";
                comboBox_nightVol.Text = "";
                comboBox_dayVol.Items.Clear();
                comboBox_nightVol.Items.Clear();

                lab_dayTime.Enabled = false;
                lab_dayVol.Enabled = false;
                lab_nightTime.Enabled = false;
                lab_nightVol.Enabled = false;

                textBox_dayTime.Enabled = false;
                comboBox_dayVol.Enabled = false;
                textBox_nightTime.Enabled = false;
                comboBox_nightVol.Enabled = false;
            }
        }


    }
}
