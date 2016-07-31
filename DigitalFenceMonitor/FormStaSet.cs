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
    public partial class FormStaSet : Form
    {
        OleDbConnection conn = FormMain.conn;
        OleDbDataAdapter dataada = null;
        OleDbCommandBuilder commandbld = null;
        DataTable datatable = null;
        BindingSource bindingsrc = null;
        FormMain fm = new FormMain();

        int DataLength;
        public FormStaSet()
        {
            InitializeComponent();
            this.ControlBox = false;
        }
        
        private void FormStaSet_Load(object sender, EventArgs e)
        {
            if (FormMain.NowUser == "admin")
            {
                but_Del.Enabled = true;
                btn_DelAll.Enabled = true;
                btn_Add.Enabled = true;
            }
            datatable = new DataTable();
            string sql = "select ID,IP,Port,StaName from tb_StaSet";
            dataada = new OleDbDataAdapter(sql, conn);
            commandbld = new OleDbCommandBuilder(dataada);
            bindingsrc = new BindingSource();
            dataGridView.DataSource = datatable;
            bindingsrc.DataSource = datatable;
            DataSet dsMsg = new DataSet();
            dataada.Fill(dsMsg);
            DataLength = dsMsg.Tables[0].Rows.Count;
            label_all.Text = DataLength.ToString();

            update_Data("init");

            dataGridView.Columns["IP"].HeaderText = "基站IP";
            dataGridView.Columns["StaName"].HeaderText = "基站名称";
            dataGridView.Columns["Port"].HeaderText = "端口号";
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public delegate void GetDBData();
        public event GetDBData GetDatabaseData;

        public delegate void Load_TreeView();
        public event Load_TreeView LoadTreeView;

        private void myGetDBData()
        {
            GetDatabaseData();
        }
        private void myLoadTreeView()
        {
            LoadTreeView();
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            string str1 = textBox_IP.Text;
            string str2 = textBox_SatName.Text;
            string str3 = textBox_Port.Text;
            if (str1 == "" || str2 == "" || str3 == "" ) {
                MessageBox.Show("请完整填写","添加错误");
            }
            else
            {
                if (fm.getValidIP(str1) !=null && fm.getValidPort(str3) !=-1) { 
                    string insertstr = "insert into tb_StaSet(IP,StaName,Port,IPandPort) values('";
                    insertstr += str1 + "', '";
                    insertstr += str2 + "', '";
                    insertstr += str3 + "', '";
                    insertstr += str1 + ":" + str3 + "')";

                    DataLength++;
                    label_all.Text = DataLength.ToString();

                    update_Data(insertstr);
                    GetDatabaseData();
                }
                else
                {
                    if (fm.getValidIP(str1) == null && fm.getValidPort(str3) != -1)
                    { MessageBox.Show("  IP  格式错误", "添加错误"); }
                    else if (fm.getValidIP(str1) != null && fm.getValidPort(str3) == -1)
                    { MessageBox.Show("  端口  格式错误", "添加错误"); }
                    else
                    { MessageBox.Show("IP及端口格式错", "添加错误"); }
                }
            }

        }

        private void update_Data(string cmd)
        {
            if (cmd != "init") { 
                OleDbCommand comm = new OleDbCommand(cmd, conn);
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show(" IP : Port 重复","插入错误");
                }
            }

            updata_datagridView();
        }
        private void updata_datagridView()
        {
            DataTable dt = (DataTable)dataGridView.DataSource;
            dt.Rows.Clear();
            dataGridView.DataSource = dt;

            dataada.Fill(datatable);
            dataada.Update((DataTable)bindingsrc.DataSource);

            dataGridView.Columns[0].Visible = false;
        }
        public delegate void UpdateAA(string str);
        public event UpdateAA UpdateAlertArea;

        private void but_Del_Click(object sender, EventArgs e)
        {
            if (DataLength > 0 && int.Parse(label_select.Text)<DataLength)
            {
                int Selected = int.Parse(label_select.Text);
                string deleIP = dataGridView.Rows[Selected].Cells[1].Value.ToString();
                string delePort = dataGridView.Rows[Selected].Cells[2].Value.ToString();
                string delestr = deleIP + ":" + delePort;

                string mapstr = "delete from tb_Map where MapInfo like '"+"%"+ delestr + "%"+"'";
                OleDbCommand comm = new OleDbCommand(mapstr, conn);
                comm.ExecuteNonQuery();
                UpdateAlertArea("dele");


                string deletestr = "delete from tb_StaSet where IPandPort = '" + delestr + "'";
                DataLength--;
                label_all.Text = DataLength.ToString();
                update_Data(deletestr);

                deletestr = "delete from tb_AreaSet where IPandPort = '" + delestr + "'";
                update_Data(deletestr);
                LoadTreeView();
            }

        }



        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int rows = dataGridView.CurrentRow.Index;
                label_select.Text = rows.ToString();
            }
            catch { Console.WriteLine("no data"); }
        }

        private void btn_DelAll_Click(object sender, EventArgs e)
        {
            if (DataLength != 0)
            {
                string mapstr = "delete from tb_Map";
                OleDbCommand comm = new OleDbCommand(mapstr, conn);
                comm.ExecuteNonQuery();
                UpdateAlertArea("dele");

                string deleall = "delete from tb_StaSet";

                DataLength = 0;
                label_all.Text = DataLength.ToString();

                update_Data(deleall);

                deleall = "delete from tb_AreaSet ";
                update_Data(deleall);
                LoadTreeView();

            }
        }

        static public string[] forChange = new string[3];
        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Selected = int.Parse(label_select.Text);
            forChange[0] = dataGridView.Rows[Selected].Cells[1].Value.ToString();
            forChange[1] = dataGridView.Rows[Selected].Cells[2].Value.ToString();
            forChange[2] = dataGridView.Rows[Selected].Cells[3].Value.ToString();

            FormStaChange changedatabase = new FormStaChange();
            changedatabase.StartPosition = FormStartPosition.CenterScreen;
            changedatabase.update_datagridView += updata_datagridView;
            changedatabase.GetDatabaseData += myGetDBData;
            changedatabase.LoadTreeView += myLoadTreeView;
            changedatabase.ShowDialog();
        }
    }
}
