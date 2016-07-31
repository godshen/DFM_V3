namespace DigitalFenceMonitor
{
    partial class FormStaSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lab_IP = new System.Windows.Forms.Label();
            this.lab_StaName = new System.Windows.Forms.Label();
            this.lab_Port = new System.Windows.Forms.Label();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.textBox_SatName = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.but_Del = new System.Windows.Forms.Button();
            this.btn_DelAll = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label_select = new System.Windows.Forms.Label();
            this.label_all = new System.Windows.Forms.Label();
            this.conMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.conMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lab_IP
            // 
            this.lab_IP.AutoSize = true;
            this.lab_IP.Font = new System.Drawing.Font("黑体", 12F);
            this.lab_IP.Location = new System.Drawing.Point(14, 30);
            this.lab_IP.Name = "lab_IP";
            this.lab_IP.Size = new System.Drawing.Size(56, 16);
            this.lab_IP.TabIndex = 0;
            this.lab_IP.Text = "IP地址";
            // 
            // lab_StaName
            // 
            this.lab_StaName.AutoSize = true;
            this.lab_StaName.Font = new System.Drawing.Font("黑体", 12F);
            this.lab_StaName.Location = new System.Drawing.Point(234, 30);
            this.lab_StaName.Name = "lab_StaName";
            this.lab_StaName.Size = new System.Drawing.Size(72, 16);
            this.lab_StaName.TabIndex = 1;
            this.lab_StaName.Text = "基站名称";
            // 
            // lab_Port
            // 
            this.lab_Port.AutoSize = true;
            this.lab_Port.Font = new System.Drawing.Font("黑体", 12F);
            this.lab_Port.Location = new System.Drawing.Point(456, 30);
            this.lab_Port.Name = "lab_Port";
            this.lab_Port.Size = new System.Drawing.Size(56, 16);
            this.lab_Port.TabIndex = 2;
            this.lab_Port.Text = "端口号";
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(75, 30);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(137, 21);
            this.textBox_IP.TabIndex = 3;
            // 
            // textBox_SatName
            // 
            this.textBox_SatName.Location = new System.Drawing.Point(312, 30);
            this.textBox_SatName.Name = "textBox_SatName";
            this.textBox_SatName.Size = new System.Drawing.Size(100, 21);
            this.textBox_SatName.TabIndex = 4;
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(518, 30);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(74, 21);
            this.textBox_Port.TabIndex = 5;
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btn_exit.Font = new System.Drawing.Font("黑体", 12F);
            this.btn_exit.Location = new System.Drawing.Point(475, 349);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(100, 40);
            this.btn_exit.TabIndex = 6;
            this.btn_exit.Text = "退出";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btn_Add.Enabled = false;
            this.btn_Add.Font = new System.Drawing.Font("黑体", 12F);
            this.btn_Add.Location = new System.Drawing.Point(32, 349);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(100, 40);
            this.btn_Add.TabIndex = 7;
            this.btn_Add.Text = "添加";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // but_Del
            // 
            this.but_Del.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.but_Del.Enabled = false;
            this.but_Del.Font = new System.Drawing.Font("黑体", 12F);
            this.but_Del.Location = new System.Drawing.Point(177, 349);
            this.but_Del.Name = "but_Del";
            this.but_Del.Size = new System.Drawing.Size(100, 40);
            this.but_Del.TabIndex = 8;
            this.but_Del.Text = "删除";
            this.but_Del.UseVisualStyleBackColor = false;
            this.but_Del.Click += new System.EventHandler(this.but_Del_Click);
            // 
            // btn_DelAll
            // 
            this.btn_DelAll.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btn_DelAll.Enabled = false;
            this.btn_DelAll.Font = new System.Drawing.Font("黑体", 12F);
            this.btn_DelAll.Location = new System.Drawing.Point(322, 349);
            this.btn_DelAll.Name = "btn_DelAll";
            this.btn_DelAll.Size = new System.Drawing.Size(100, 40);
            this.btn_DelAll.TabIndex = 9;
            this.btn_DelAll.Text = "全部删除";
            this.btn_DelAll.UseVisualStyleBackColor = false;
            this.btn_DelAll.Click += new System.EventHandler(this.btn_DelAll_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ContextMenuStrip = this.conMenuStrip;
            this.dataGridView.Location = new System.Drawing.Point(14, 75);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(578, 256);
            this.dataGridView.TabIndex = 10;
            this.dataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseClick);
            // 
            // label_select
            // 
            this.label_select.AutoSize = true;
            this.label_select.Location = new System.Drawing.Point(295, 365);
            this.label_select.Name = "label_select";
            this.label_select.Size = new System.Drawing.Size(0, 12);
            this.label_select.TabIndex = 11;
            // 
            // label_all
            // 
            this.label_all.AutoSize = true;
            this.label_all.Location = new System.Drawing.Point(440, 365);
            this.label_all.Name = "label_all";
            this.label_all.Size = new System.Drawing.Size(11, 12);
            this.label_all.TabIndex = 12;
            this.label_all.Text = "0";
            // 
            // conMenuStrip
            // 
            this.conMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改ToolStripMenuItem});
            this.conMenuStrip.Name = "conMenuStrip";
            this.conMenuStrip.Size = new System.Drawing.Size(153, 48);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.修改ToolStripMenuItem.Text = "修改";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // FormStaSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 401);
            this.Controls.Add(this.label_all);
            this.Controls.Add(this.label_select);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btn_DelAll);
            this.Controls.Add(this.but_Del);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_SatName);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.lab_Port);
            this.Controls.Add(this.lab_StaName);
            this.Controls.Add(this.lab_IP);
            this.Name = "FormStaSet";
            this.Text = "基站设置";
            this.Load += new System.EventHandler(this.FormStaSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.conMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_IP;
        private System.Windows.Forms.Label lab_StaName;
        private System.Windows.Forms.Label lab_Port;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.TextBox textBox_SatName;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button but_Del;
        private System.Windows.Forms.Button btn_DelAll;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label_select;
        private System.Windows.Forms.Label label_all;
        private System.Windows.Forms.ContextMenuStrip conMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
    }
}