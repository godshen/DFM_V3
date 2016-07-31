using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DigitalFenceMonitor
{
    public partial class UserSet : Form
    {
        OleDbConnection conn = FormMain.conn;
        OleDbDataAdapter dataada = null;
        OleDbCommandBuilder commandbld = null;
        DataTable datatable = null;
        BindingSource bindingsrc = null;
        FormMain fm = new FormMain();
        int DataLength;
        public UserSet()
        {
            InitializeComponent();
        }

        private void UserSet_Load(object sender, EventArgs e)
        {
            datatable = new DataTable();
            string sql = "select username,authorition from tb_Account";
            dataada = new OleDbDataAdapter(sql, conn);
            commandbld = new OleDbCommandBuilder(dataada);
            bindingsrc = new BindingSource();
            dataGridView.DataSource = datatable;
            bindingsrc.DataSource = datatable;
            DataSet dsMsg = new DataSet();
            dataada.Fill(dsMsg);
            DataLength = dsMsg.Tables[0].Rows.Count;
            update_Data("init");
            dataGridView.Columns["username"].HeaderText = "用户名";
            dataGridView.Columns["authorition"].HeaderText = "权限";

            comboBox_auth.Items.Add("0-管理员权限");
            comboBox_auth.Items.Add("1-普通权限");
        }
        private void update_Data(string cmd)
        {
            if (cmd != "init")
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                OleDbCommand comm = new OleDbCommand(cmd, conn);
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("重复", "插入错误");
                }
            }

            DataTable dt = (DataTable)dataGridView.DataSource;
            dt.Rows.Clear();
            dataGridView.DataSource = dt;

            dataada.Fill(datatable);
            dataada.Update((DataTable)bindingsrc.DataSource);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void but_Del_Click(object sender, EventArgs e)
        {
            if (DataLength > 0 && int.Parse(label_select.Text) < DataLength)
            {
                int Selected = int.Parse(label_select.Text);
                string username = dataGridView.Rows[Selected].Cells[0].Value.ToString();

                string deletestr = "delete * from tb_Account where username = '" + username + "'";
                update_Data(deletestr);
            }
        }

        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rows = dataGridView.CurrentRow.Index;
            label_select.Text = rows.ToString();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (textBox_UserName.Text != "" && textBox_UserPSW0.Text != "" && textBox_UserPSW1.Text != "" && comboBox_auth.Text != "")
            {
                if (textBox_UserPSW0.Text == textBox_UserPSW1.Text)
                {
                    string insertstr = "insert into tb_Account(username,psw,authorition) values('";
                    insertstr += textBox_UserName.Text + "', '";
                    insertstr += textBox_UserPSW0.Text + "', '";
                    insertstr += comboBox_auth.Text + "')";

                    update_Data(insertstr);
                    DataLength++;
                }
                else
                {
                    MessageBox.Show("两次密码不一致", "提示");
                }
            }
            else
            {
                MessageBox.Show("信息不完整","提示");
            }
        }
    }
}
