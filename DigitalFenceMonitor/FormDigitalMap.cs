using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace DigitalFenceMonitor
{
    public partial class FormDigitalMap : Form
    {
        OleDbConnection conn = FormMain.conn;
        static public string MapPath = "";

        public FormDigitalMap()
        {
            InitializeComponent();
            this.ControlBox = false;
        }


        private void btn_Done_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Brows_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                textBox_MapPath.Text = file;
            }
        }

        public delegate void ChangeMP(string path);
        public event ChangeMP ChangeMapPath;
        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if( DialogResult.OK ==MessageBox.Show("已选择文件:" + textBox_MapPath.Text, "选择文件提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
            {
                MapPath = textBox_MapPath.Text;
                string destPath = Path.Combine(@".\", "map.jpg");
                File.Copy(@MapPath, destPath, true);

                ChangeMapPath(MapPath);
            }
            else
            {
                textBox_MapPath.Text = "";
            }
        }

        private void FormDigitalMap_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            for (int i = 0; i < FormMain.StaSetCount; i++)
            {
                string ipport = FormMain.RemotePointArr[i].ToString();
                this.comboBox_StaName.Items.Add(FormMain.StaBuff[ipport] + "-" + ipport);
            }

        }


        private void comboBox_StaName_TextChanged(object sender, EventArgs e)
        {
            string str = comboBox_StaName.Text.Split('-')[1];
            
            if(conn.State == ConnectionState.Closed) conn.Open();
            string sql = "select AreaNum from tb_AreaSet where IPandPort = '" + str + "'";
            DataTable tempdt = new DataTable();
            OleDbDataAdapter tempda = new OleDbDataAdapter(sql, conn);

            tempda.Fill(tempdt);

            comboBox_AreaNum.Items.Clear();
            comboBox_AreaNum.Text = "";

            if (tempdt.Rows.Count !=0)
            {
                for (int i = 0; i < tempdt.Rows.Count; i++)
                {
                    if (i != 0)
                    {
                        int x = Convert.ToInt16(tempdt.Rows[i]["AreaNum"]);
                        int y = Convert.ToInt16(tempdt.Rows[i - 1]["AreaNum"]);
                        if (x == y) ;
                        else comboBox_AreaNum.Items.Add(tempdt.Rows[i]["AreaNum"]);
                    }
                    else
                    {
                        comboBox_AreaNum.Items.Add(tempdt.Rows[i]["AreaNum"]);
                    }
                }

                comboBox_AreaNum.SelectedIndex = 0;
            }
            
        }

        private void comboBox_AreaNum_TextChanged(object sender, EventArgs e)
        {
            string str1 = comboBox_StaName.Text.Split('-')[1];
            string str2 = comboBox_AreaNum.Text;

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

        private void btn_Set_Click(object sender, EventArgs e)
        {
            if (comboBox_StaName.Text != "" && comboBox_AreaNum.Text != "" && comboBox_Position.Text != "")
            {
                MessageBox.Show("设置" + (checkBox.CheckState.ToString() == "Checked" ? "" : "不") + "关联");
            }
            else
            {
                MessageBox.Show("请填写完整","关联设置");
            }
        }
    }
}
