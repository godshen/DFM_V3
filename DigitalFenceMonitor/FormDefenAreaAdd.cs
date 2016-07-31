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

namespace DigitalFenceMonitor
{
    public partial class FormDefenAreaAdd : Form
    {
        string[] data = new string[5];
        static public Dictionary<string, string> StaBuff = new Dictionary<string, string>();

        public delegate void UpdateDB(string msg);
        public event UpdateDB UpdateDataBase;

        public FormDefenAreaAdd()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public delegate void Load_TreeView();
        public event Load_TreeView LoadTreeView;
        OleDbConnection conn = FormMain.conn;

        private void btn_Done_Click(object sender, EventArgs e)
        {
            if (textBox_AreaNum.Text != "" && textBox_Position.Text != "")
            {
                try
                {
                    data[0] = StaBuff[comboBox_StaName.Text].Trim();
                }
                catch
                {
                    data[0] = "null";
                }
                data[1] = textBox_AreaNum.Text.Trim();
                data[2] = comboBox_AreaStatus.Text.Trim();
                data[3] = textBox_Position.Text.Trim();
                data[4] = comboBox_type.Text.Split('-')[1].Trim();
                bool flag = true;

                string sql = "select AreaNum from tb_AreaSet Where IPandPort ='" + data[0] + "'";
                DataTable tempdt = new DataTable();
                OleDbDataAdapter tempda = new OleDbDataAdapter(sql, conn);
                tempda.Fill(tempdt);

                for (int i = 0; i < tempdt.Rows.Count; i++)
                {
                    string temp = tempdt.Rows[i]["AreaNum"].ToString();
                    if (temp == data[1])
                    {
                        flag = false;
                        break;
                    }
                }

                if(flag)
                { 
                    char CheckState = (comboBox_type.Text.Split('-')[0] == "单防区" ? 'N' : 'Y');

                    if (CheckState == 'N')
                    {

                        string insertstr = "insert into tb_areaset(ipandport,areanum,status,descripe,devicetype,map) values('";
                        for (int i = 0; i < 5; i++)
                            insertstr += data[i] + "', '";
                        insertstr += data[0] + "," + data[1] + "-0" + "')";

                        FormDenfenAreaSet.DataLength++;
                        UpdateDataBase(insertstr);
                    }
                    else
                    {

                        for (int j = 1; j < 3; j++)
                        {

                            string insertstr = "insert into tb_areaset(ipandport,areanum,status,descripe,devicetype,map) values('";
                            for (int i = 0; i < 3; i++)
                                insertstr += data[i] + "', '";
                            insertstr += data[3] + "_" + j.ToString() + "', '";
                            insertstr += data[4] + "', '";
                            insertstr += data[0] + "," + data[1] + "-" + j.ToString() + "')";

                            FormDenfenAreaSet.DataLength++;
                            UpdateDataBase(insertstr);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("相同IP:Port下防区号重复","插入错误");
                }
                
            }
            else
            {
                MessageBox.Show("请完整填写");
            }
            LoadTreeView();
        }
        
        private void FormDefenAreaAdd_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            string sql = "select IPandPort,StaName from tb_StaSet";
            DataTable tempdt = new DataTable();
            OleDbDataAdapter tempda = new OleDbDataAdapter(sql, conn);
            tempda.Fill(tempdt);

            int len = tempdt.Rows.Count;
            for (int i = 0; i < len; i++)
            {
                StaBuff[tempdt.Rows[i]["StaName"].ToString()] = tempdt.Rows[i]["IPandPort"].ToString();
            }

            for (int i=0;i<tempdt.Rows.Count;i++)
                comboBox_StaName.Items.Add(tempdt.Rows[i]["StaName"].ToString());
            if(tempdt.Rows.Count!=0) comboBox_StaName.SelectedIndex = 0;

            comboBox_AreaStatus.Items.Add("布防");
            comboBox_AreaStatus.Items.Add("撤防");
            comboBox_AreaStatus.SelectedIndex = 0;

            comboBox_type.Items.Add("单防区-脉冲主机");
            comboBox_type.Items.Add("双防区-脉冲主机");
            comboBox_type.Items.Add("单防区-张力主机");
            comboBox_type.Items.Add("双防区-张力主机");
            comboBox_type.Items.Add("单防区-地址码");
            comboBox_type.Items.Add("双防区-地址码");
            comboBox_type.Items.Add("单防区-触网脉冲主机");
            comboBox_type.Items.Add("双防区-触网脉冲主机");
            comboBox_type.Items.Add("单防区-振动光纤");
            comboBox_type.Items.Add("双防区-振动光纤");
            comboBox_type.Items.Add("单防区-泄露电缆");
            comboBox_type.Items.Add("单防区-静电感应");     
            comboBox_type.SelectedIndex = 0;
        }

        private void comboBox_type_TextChanged(object sender, EventArgs e)
        {
            char CheckState = (comboBox_type.Text.Split('-')[0]=="单防区" ? 'N' : 'Y');
        }
    }
}
