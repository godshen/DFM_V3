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
    public partial class FormDefenceAreaChange : Form
    {
        public FormDefenceAreaChange()
        {
            InitializeComponent();
        }
        OleDbConnection conn = FormMain.conn;

        string ipPort, name, addr, posi, type;



        private void FormDefenceAreaChange_Load(object sender, EventArgs e)
        {
            ipPort = FormDenfenAreaSet.forChange[0].Trim();
            name = FormMain.StaBuff[ipPort].Trim();
            addr = FormDenfenAreaSet.forChange[1];
            posi = FormDenfenAreaSet.forChange[2];
            type = FormDenfenAreaSet.forChange[3];

            textBox1.Text = ipPort;
            textBox2.Text = name;
            textBox_IP.Text = textBox_IPn.Text = addr;
            textBox_Port.Text = textBox_Portn.Text = type;
            textBox_SatName.Text = textBox_SatNamen.Text = posi;
        }


        public delegate void GetDBData();
        public event GetDBData GetDatabaseData;

        public delegate void Load_TreeView();
        public event Load_TreeView LoadTreeView;

        public delegate void updategridView();
        public event updategridView update_datagridView;

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            string addressOld = textBox_IP.Text.Trim();
            string address = textBox_IPn.Text.Trim();
            string position = textBox_SatNamen.Text.Trim();
            string type = textBox_Portn.Text.Trim();

            OleDbConnection conn = FormMain.conn;
            OleDbCommand comm = null;
            string sql = null;

            if (conn.State == ConnectionState.Closed) conn.Open();

            try
            {
                sql = " update tb_AreaSet set ";
                sql += "    AreaNum = '" + address;
                sql += "' , Descripe = '" + position;
                sql += "' , DeviceType = '" + type;
                sql += "' , Map = replace( Map , '," + addressOld + "-' , '," + address + "-' )";
                sql += " Where IPandPort = '" + ipPort + "' and AreaNum = '" + addr +"' and Descripe = '" + posi + "'";
                comm = new OleDbCommand(sql, conn);
                comm.ExecuteNonQuery();


                sql = " update tb_AreaSet set ";
                sql += "    AreaNum = '" + address;
                sql += "' , DeviceType = '" + type;
                sql += "' , Map = replace( Map , '," + addressOld + "-' , '," + address + "-' )";
                sql += " Where IPandPort = '" + ipPort + "' and AreaNum = '" + addr + "'";
                comm = new OleDbCommand(sql, conn);
                comm.ExecuteNonQuery();

                update_datagridView();
            }

            catch
            {
                MessageBox.Show("AreaSet修改失败");
            }



            try
            {
                sql = " update tb_Map set ";
                sql += " MapInfo = '" + ipPort + "," + address + "," + position + "'";
                sql += " Where MapInfo = '" + ipPort + "," + addr + "," + posi + "'";
                comm = new OleDbCommand(sql, conn);
                comm.ExecuteNonQuery();

                sql = " update tb_Map set ";
                sql += " MapInfo = replace(MapInfo,',"+ addr + ",',',"+ address + ",'"+")";
                comm = new OleDbCommand(sql, conn);
                comm.ExecuteNonQuery();
            }

            catch
            {
                MessageBox.Show("Map修改失败");
            }


            GetDatabaseData();
            LoadTreeView();
            this.Close();
        }
    }
}
