using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace DigitalFenceMonitor
{
    public partial class FormMusic : Form
    {
        OleDbConnection conn = FormMain.conn;
        static public string MusicPath = "";
        public FormMusic()
        {
            InitializeComponent();
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

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("已选择文件:" + textBox_MapPath.Text, "选择文件提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
            {
                MusicPath = textBox_MapPath.Text;
                string destPath = Path.Combine(@".\", "alert.wav");
                File.Copy(@MusicPath, destPath, true);
                FormMain.player.Load();
            }
            else
            {
                textBox_MapPath.Text = "";
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
