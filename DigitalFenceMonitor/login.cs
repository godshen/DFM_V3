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
    public partial class FormLogin : Form
    {
        string[] username = new string[100];
        string[] password = new string[100];
        int pswindex = -1;
        int numberofaccount = 0;
        public FormLogin()
        {
            InitializeComponent();
            this.ControlBox = false;
            
        }
        private void but_login_Click(object sender, EventArgs e)
        {
            bool IsChecked = false;
            if (-1 == pswindex)
            {
                for (int n = 0; n < numberofaccount; n++)
                {
                    if (comboBox_login_id.Text == username[n])
                    {
                        pswindex = n;
                        IsChecked = true;
                        break;
                    }
                }
                if (false == IsChecked)
                    MessageBox.Show("查无此用户");
            }
            else
                IsChecked = true;

            if (true == IsChecked)
                if (textBox_login_psw.Text == password[pswindex])
                {
                    FormMain.NowUser = comboBox_login_id.Text;
                    this.Owner.Show();
                    FormMain.reloadmap.Start();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("密码错误","提示");
                }
            pswindex = -1;
        }
        private void but_exit_Click(object sender, EventArgs e)
        {
            this.Owner.Close();
        }
        private void login_Load(object sender, EventArgs e)
        {
            OleDbConnection conn = FormMain.conn;
            if (conn.State == ConnectionState.Closed) conn.Open();

            DataSet dsMsg = new DataSet();
            string sql = "select * from tb_Account";
            OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
            da.Fill(dsMsg);
            if (dsMsg.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Nothing!");
            }
            else
            {
                int RowsofTable = dsMsg.Tables[0].Rows.Count;
                numberofaccount = RowsofTable;
                for (int n = 0; n < RowsofTable; n++)
                {
                    username[n] = dsMsg.Tables[0].Rows[n]["username"].ToString();
                    password[n] = dsMsg.Tables[0].Rows[n]["psw"].ToString();
                    this.comboBox_login_id.Items.Add(username[n]);
                }
                comboBox_login_id.SelectedIndex = 0;
            }
            conn.Close();
        }

        private void comboBox_login_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            pswindex = comboBox_login_id.Items.IndexOf(comboBox_login_id.Text);

        }
    }
}
