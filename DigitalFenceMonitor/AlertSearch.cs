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
using Excel = Microsoft.Office.Interop.Excel;

namespace DigitalFenceMonitor
{
    public partial class AlertSearch : Form
    {
        public AlertSearch()
        {
            InitializeComponent();
        }
        OleDbConnection conn = FormMain.conn;
        private void AlertSearch_Load(object sender, EventArgs e)
        {
            if (FormMain.NowUser=="admin")
                but_clear.Enabled = true;
            ReLoad();
        }

        private void ReLoad()
        {
            

            OleDbDataAdapter alertada = null;
            DataTable datatable = new DataTable();
            BindingSource bindingsrc = new BindingSource();
            OleDbCommandBuilder commandbld = null;

            string sql = "select * from tb_Content";

            alertada = new OleDbDataAdapter(sql, conn);
            dataGridView.DataSource = datatable;
            bindingsrc.DataSource = datatable;
            commandbld = new OleDbCommandBuilder(alertada);
            alertada.Fill(datatable);

            dataGridView.Columns["NowDate"].HeaderText = "日期";
            dataGridView.Columns["NowTime"].HeaderText = "时间";
            dataGridView.Columns["StationIP"].HeaderText = "基站IP";
            dataGridView.Columns["StationName"].HeaderText = "基站名称";
            dataGridView.Columns["AreaNum"].HeaderText = "防区号";

            dataGridView.Columns["AlertType"].HeaderText = "信息类型";
            dataGridView.Columns["Descripe"].HeaderText = "地理位置";
            dataGridView.Columns["OperationInfo"].HeaderText = "操作信息";
            dataGridView.Columns["Operator"].HeaderText = "操作员";
            dataGridView.Columns["OperationResult"].HeaderText = "处理结果";

            dataGridView.Columns[0].Visible = false;

            dataGridView.Columns[1].Width = 80;
            dataGridView.Columns[2].Width = 80;
            dataGridView.Columns[5].Width = 75;
        }

        private void but_clear_Click(object sender, EventArgs e)
        {
            string sql = "delete from tb_Content";
            OleDbCommand comm = new OleDbCommand(sql, conn);
            comm.ExecuteNonQuery();

            DataTable datatable = null;
            dataGridView.DataSource = datatable;
        }

        private void btn_output_Click(object sender, EventArgs e)
        {
            MessageBox.Show("开始生成要导出的数据", "导出提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Excel.Application excel = new Excel.Application();
            excel.Application.Workbooks.Add(true);
            excel.Visible = false;
            for (int i = 0; i < dataGridView.ColumnCount; i++)
                excel.Cells[1, i + 1] = dataGridView.Columns[i].HeaderText;

            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    if (dataGridView[j, i].ValueType == typeof(string))
                    {
                        excel.Cells[i + 2, j + 1] = "'" + dataGridView[j, i].Value.ToString();
                    }
                    else
                    {
                        excel.Cells[i + 2, j + 1] = dataGridView[j, i].Value.ToString();
                    }
                }

            }

            MessageBox.Show("生成成功，请保存。", "生成提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            excel.Visible = true;
        }
    }
}
