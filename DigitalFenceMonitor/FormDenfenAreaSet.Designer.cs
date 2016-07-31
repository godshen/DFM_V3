namespace DigitalFenceMonitor
{
    partial class FormDenfenAreaSet
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.conMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_DelAll = new System.Windows.Forms.Button();
            this.but_Del = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label_select = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.conMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ContextMenuStrip = this.conMenuStrip;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(685, 327);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseClick);
            this.dataGridView.Sorted += new System.EventHandler(this.dataGridView_Sorted);
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
            // btn_DelAll
            // 
            this.btn_DelAll.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btn_DelAll.Enabled = false;
            this.btn_DelAll.Font = new System.Drawing.Font("黑体", 12F);
            this.btn_DelAll.Location = new System.Drawing.Point(365, 356);
            this.btn_DelAll.Name = "btn_DelAll";
            this.btn_DelAll.Size = new System.Drawing.Size(100, 40);
            this.btn_DelAll.TabIndex = 13;
            this.btn_DelAll.Text = "全部删除";
            this.btn_DelAll.UseVisualStyleBackColor = false;
            this.btn_DelAll.Click += new System.EventHandler(this.btn_DelAll_Click);
            // 
            // but_Del
            // 
            this.but_Del.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.but_Del.Enabled = false;
            this.but_Del.Font = new System.Drawing.Font("黑体", 12F);
            this.but_Del.Location = new System.Drawing.Point(220, 356);
            this.but_Del.Name = "but_Del";
            this.but_Del.Size = new System.Drawing.Size(100, 40);
            this.but_Del.TabIndex = 12;
            this.but_Del.Text = "删除";
            this.but_Del.UseVisualStyleBackColor = false;
            this.but_Del.Click += new System.EventHandler(this.but_Del_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btn_Add.Enabled = false;
            this.btn_Add.Font = new System.Drawing.Font("黑体", 12F);
            this.btn_Add.Location = new System.Drawing.Point(75, 356);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(100, 40);
            this.btn_Add.TabIndex = 11;
            this.btn_Add.Text = "添加";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btn_exit.Font = new System.Drawing.Font("黑体", 12F);
            this.btn_exit.Location = new System.Drawing.Point(510, 356);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(100, 40);
            this.btn_exit.TabIndex = 10;
            this.btn_exit.Text = "退出";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label_select
            // 
            this.label_select.AutoSize = true;
            this.label_select.Location = new System.Drawing.Point(326, 372);
            this.label_select.Name = "label_select";
            this.label_select.Size = new System.Drawing.Size(0, 12);
            this.label_select.TabIndex = 14;
            // 
            // FormDenfenAreaSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 404);
            this.Controls.Add(this.label_select);
            this.Controls.Add(this.btn_DelAll);
            this.Controls.Add(this.but_Del);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormDenfenAreaSet";
            this.Text = "防区设置";
            this.Load += new System.EventHandler(this.FormDenfenAreaSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.conMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btn_DelAll;
        private System.Windows.Forms.Button but_Del;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label_select;
        private System.Windows.Forms.ContextMenuStrip conMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
    }
}