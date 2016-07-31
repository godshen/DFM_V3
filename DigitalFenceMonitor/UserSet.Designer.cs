namespace DigitalFenceMonitor
{
    partial class UserSet
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
            this.textBox_UserPSW0 = new System.Windows.Forms.TextBox();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.lab_Auth = new System.Windows.Forms.Label();
            this.lab_UserPSW = new System.Windows.Forms.Label();
            this.lab_UserName = new System.Windows.Forms.Label();
            this.comboBox_auth = new System.Windows.Forms.ComboBox();
            this.but_Del = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.textBox_UserPSW1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_select = new System.Windows.Forms.Label();
            this.label_none = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_UserPSW0
            // 
            this.textBox_UserPSW0.Location = new System.Drawing.Point(82, 56);
            this.textBox_UserPSW0.Name = "textBox_UserPSW0";
            this.textBox_UserPSW0.PasswordChar = '*';
            this.textBox_UserPSW0.Size = new System.Drawing.Size(54, 21);
            this.textBox_UserPSW0.TabIndex = 10;
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Location = new System.Drawing.Point(82, 20);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(84, 21);
            this.textBox_UserName.TabIndex = 9;
            // 
            // lab_Auth
            // 
            this.lab_Auth.AutoSize = true;
            this.lab_Auth.Font = new System.Drawing.Font("黑体", 12F);
            this.lab_Auth.Location = new System.Drawing.Point(185, 23);
            this.lab_Auth.Name = "lab_Auth";
            this.lab_Auth.Size = new System.Drawing.Size(40, 16);
            this.lab_Auth.TabIndex = 8;
            this.lab_Auth.Text = "权限";
            // 
            // lab_UserPSW
            // 
            this.lab_UserPSW.AutoSize = true;
            this.lab_UserPSW.Font = new System.Drawing.Font("黑体", 12F);
            this.lab_UserPSW.Location = new System.Drawing.Point(22, 59);
            this.lab_UserPSW.Name = "lab_UserPSW";
            this.lab_UserPSW.Size = new System.Drawing.Size(40, 16);
            this.lab_UserPSW.TabIndex = 7;
            this.lab_UserPSW.Text = "密码";
            // 
            // lab_UserName
            // 
            this.lab_UserName.AutoSize = true;
            this.lab_UserName.Font = new System.Drawing.Font("黑体", 12F);
            this.lab_UserName.Location = new System.Drawing.Point(22, 23);
            this.lab_UserName.Name = "lab_UserName";
            this.lab_UserName.Size = new System.Drawing.Size(56, 16);
            this.lab_UserName.TabIndex = 6;
            this.lab_UserName.Text = "用户名";
            // 
            // comboBox_auth
            // 
            this.comboBox_auth.FormattingEnabled = true;
            this.comboBox_auth.Location = new System.Drawing.Point(236, 21);
            this.comboBox_auth.Name = "comboBox_auth";
            this.comboBox_auth.Size = new System.Drawing.Size(121, 20);
            this.comboBox_auth.TabIndex = 11;
            // 
            // but_Del
            // 
            this.but_Del.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.but_Del.Font = new System.Drawing.Font("黑体", 12F);
            this.but_Del.Location = new System.Drawing.Point(12, 285);
            this.but_Del.Name = "but_Del";
            this.but_Del.Size = new System.Drawing.Size(100, 40);
            this.but_Del.TabIndex = 14;
            this.but_Del.Text = "删除";
            this.but_Del.UseVisualStyleBackColor = false;
            this.but_Del.Click += new System.EventHandler(this.but_Del_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btn_Add.Font = new System.Drawing.Font("黑体", 12F);
            this.btn_Add.Location = new System.Drawing.Point(285, 47);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(100, 40);
            this.btn_Add.TabIndex = 13;
            this.btn_Add.Text = "添加";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btn_exit.Font = new System.Drawing.Font("黑体", 12F);
            this.btn_exit.Location = new System.Drawing.Point(285, 285);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(100, 40);
            this.btn_exit.TabIndex = 12;
            this.btn_exit.Text = "退出";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 93);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(373, 167);
            this.dataGridView.TabIndex = 15;
            this.dataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseClick);
            // 
            // textBox_UserPSW1
            // 
            this.textBox_UserPSW1.Location = new System.Drawing.Point(212, 56);
            this.textBox_UserPSW1.Name = "textBox_UserPSW1";
            this.textBox_UserPSW1.PasswordChar = '*';
            this.textBox_UserPSW1.Size = new System.Drawing.Size(63, 21);
            this.textBox_UserPSW1.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 12F);
            this.label1.Location = new System.Drawing.Point(142, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "确认密码";
            // 
            // label_select
            // 
            this.label_select.AutoSize = true;
            this.label_select.Location = new System.Drawing.Point(184, 301);
            this.label_select.Name = "label_select";
            this.label_select.Size = new System.Drawing.Size(11, 12);
            this.label_select.TabIndex = 18;
            this.label_select.Text = "1";
            // 
            // label_none
            // 
            this.label_none.AutoSize = true;
            this.label_none.Location = new System.Drawing.Point(125, 301);
            this.label_none.Name = "label_none";
            this.label_none.Size = new System.Drawing.Size(53, 12);
            this.label_none.TabIndex = 19;
            this.label_none.Text = "当前选择";
            // 
            // UserSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 342);
            this.Controls.Add(this.label_none);
            this.Controls.Add(this.label_select);
            this.Controls.Add(this.textBox_UserPSW1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.but_Del);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.comboBox_auth);
            this.Controls.Add(this.textBox_UserPSW0);
            this.Controls.Add(this.textBox_UserName);
            this.Controls.Add(this.lab_Auth);
            this.Controls.Add(this.lab_UserPSW);
            this.Controls.Add(this.lab_UserName);
            this.Name = "UserSet";
            this.Text = "用户设置";
            this.Load += new System.EventHandler(this.UserSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_UserPSW0;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.Label lab_Auth;
        private System.Windows.Forms.Label lab_UserPSW;
        private System.Windows.Forms.Label lab_UserName;
        private System.Windows.Forms.ComboBox comboBox_auth;
        private System.Windows.Forms.Button but_Del;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox textBox_UserPSW1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_select;
        private System.Windows.Forms.Label label_none;
    }
}