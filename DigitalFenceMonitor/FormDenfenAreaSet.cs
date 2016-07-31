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

    public partial class FormDenfenAreaSet : Form
    {
        OleDbConnection conn = FormMain.conn;
        OleDbDataAdapter dataada = null;
        OleDbCommandBuilder commandbld = null;
        DataTable datatable = null;
        BindingSource bindingsrc = null;

        static public Dictionary<string, string> StaBuff = new Dictionary<string, string>();

        static public int DataLength;
        public FormDenfenAreaSet()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void FormDenfenAreaSet_Load(object sender, EventArgs e)
        {
            if (FormMain.NowUser == "admin")
            {
                but_Del.Enabled = true;
                btn_DelAll.Enabled = true;
                btn_Add.Enabled = true;
            }

            if (conn.State == ConnectionState.Closed) conn.Open();

            datatable = new DataTable();
            string sql = "select * from tb_AreaSet";
            dataada = new OleDbDataAdapter(sql, conn);
            commandbld = new OleDbCommandBuilder(dataada);
            bindingsrc = new BindingSource();
            dataGridView.DataSource = datatable;
            bindingsrc.DataSource = datatable;
            DataSet dsMsg = new DataSet();
            dataada.Fill(dsMsg);
            DataLength = dsMsg.Tables[0].Rows.Count;

            StaBuff = FormMain.StaBuff;

            update_Data("init");

            dataGridView.Columns.Add("StaName", "基站名称");
            dataGridView.Columns["StaName"].DisplayIndex = 2;
            for(int i = 0; i < DataLength; i++)
            {
                string s = dataGridView.Rows[i].Cells["IPandPort"].Value.ToString();
                dataGridView.Rows[i].Cells["StaName"].Value = StaBuff[s.Trim()];
            }

            dataGridView.Columns["IPandPort"].HeaderText = "基站";
            dataGridView.Columns["AreaNum"].HeaderText = "设备地址";
            dataGridView.Columns["Status"].HeaderText = "防区状态";
            dataGridView.Columns["Descripe"].HeaderText = "防区位置";
            dataGridView.Columns["DeviceType"].HeaderText = "设备类型";
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FormDefenAreaAdd defenareaadd = new FormDefenAreaAdd();
            defenareaadd.StartPosition = FormStartPosition.CenterScreen;
            defenareaadd.UpdateDataBase += update_Data;
            defenareaadd.LoadTreeView += myLoadTreeView;
            defenareaadd.Show();
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

        private void update_Data(string cmd)
        {

            if (cmd != "init")
            {
                OleDbCommand comm = new OleDbCommand(cmd, conn);
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show(" IP : Port 重复", "插入错误");
                    DataLength--;
                }
            }

            DataTable dt = (DataTable)dataGridView.DataSource;
            dt.Rows.Clear();
            dataGridView.DataSource = dt;

            dataada.Fill(datatable);
            dataada.Update((DataTable)bindingsrc.DataSource);

            for (int i = 0; i < DataLength; i++)
            {
                string s = dataGridView.Rows[i].Cells["IPandPort"].Value.ToString();
                try
                {
                    dataGridView.Rows[i].Cells["StaName"].Value = StaBuff[s];
                }
                catch
                {
                    ;
                }
            }
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[5].Visible = false;

            dataGridView.Columns[1].Width = 150;
        }

        private void btn_DelAll_Click(object sender, EventArgs e)
        {
            if (DataLength != 0)
            {
                string mapstr = "delete from tb_Map";
                OleDbCommand comm = new OleDbCommand(mapstr, conn);
                comm.ExecuteNonQuery();
                UpdateAlertArea("dele");

                string deleall = "delete from tb_AreaSet";
                DataLength = 0;
                update_Data(deleall);
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
            catch
            {
                Console.WriteLine("no data");
            }
        }
        public delegate void UpdateAA(string str);
        public event UpdateAA UpdateAlertArea;
        private void but_Del_Click(object sender, EventArgs e)
        {
            if (DataLength > 0 && int.Parse(label_select.Text) < DataLength)
            {
                int Selected = int.Parse(label_select.Text);
                string str = dataGridView.Rows[Selected].Cells["Map"].Value.ToString().Split('-')[1];

                string s1 = dataGridView.Rows[Selected].Cells["IPandPort"].Value.ToString();
                string s2 = dataGridView.Rows[Selected].Cells["AreaNum"].Value.ToString();
                string mapstr = "delete from tb_Map where MapInfo like '%" + s1 + "," + s2 + "," + "%'";
                OleDbCommand comm = new OleDbCommand(mapstr, conn);
                comm.ExecuteNonQuery();
                UpdateAlertArea("dele");

                if (str == "0")
                { 
                    string map = dataGridView.Rows[int.Parse(label_select.Text)].Cells["Map"].Value.ToString().Split('-')[0] + "-0";
                    string deletestr = "delete from tb_AreaSet where map = '" + map + "'";
                    DataLength--;
                    update_Data(deletestr);
                }
                else
                {
                    string map = dataGridView.Rows[Selected].Cells["Map"].Value.ToString().Split('-')[0];
                    for (int j = 1; j < 3; j++)
                    {
                        string deletestr = "delete from tb_AreaSet where map = '" + map + "-" + j.ToString() + "'";
                        DataLength--;
                        update_Data(deletestr);
                    }
                    
                }
                
            }
            LoadTreeView();
        }

        private void dataGridView_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < DataLength; i++)
            {
                string s = dataGridView.Rows[i].Cells["IPandPort"].Value.ToString();
                dataGridView.Rows[i].Cells["StaName"].Value = StaBuff[s];
            }
        }
        private void updata_datagridView()
        {
            DataTable dt = (DataTable)dataGridView.DataSource;
            dt.Rows.Clear();
            dataGridView.DataSource = dt;

            dataada.Fill(datatable);
            dataada.Update((DataTable)bindingsrc.DataSource);
            for (int i = 0; i < DataLength; i++)
            {
                string s = dataGridView.Rows[i].Cells["IPandPort"].Value.ToString();
                try
                {
                    dataGridView.Rows[i].Cells["StaName"].Value = StaBuff[s];
                }
                catch
                {
                    ;
                }
            }
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[5].Visible = false;

            dataGridView.Columns[1].Width = 150;
        }

        static public string[] forChange = new string[4];
        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Selected = int.Parse(label_select.Text);
            forChange[0] = dataGridView.Rows[Selected].Cells[1].Value.ToString();
            forChange[1] = dataGridView.Rows[Selected].Cells[2].Value.ToString();
            forChange[2] = dataGridView.Rows[Selected].Cells["Descripe"].Value.ToString();
            forChange[3] = dataGridView.Rows[Selected].Cells["DeviceType"].Value.ToString();

            FormDefenceAreaChange formdefencechange = new FormDefenceAreaChange();
            formdefencechange.StartPosition = FormStartPosition.CenterScreen;
            formdefencechange.GetDatabaseData += myGetDBData;
            formdefencechange.LoadTreeView += myLoadTreeView;
            formdefencechange.update_datagridView += updata_datagridView;
            formdefencechange.ShowDialog();
        }
    }
}
