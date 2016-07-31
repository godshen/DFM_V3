namespace DigitalFenceMonitor
{
    partial class FormLogin
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
            this.but_login = new System.Windows.Forms.Button();
            this.label_login_id = new System.Windows.Forms.Label();
            this.label_login_psw = new System.Windows.Forms.Label();
            this.textBox_login_psw = new System.Windows.Forms.TextBox();
            this.but_exit = new System.Windows.Forms.Button();
            this.comboBox_login_id = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // but_login
            // 
            this.but_login.Location = new System.Drawing.Point(101, 93);
            this.but_login.Name = "but_login";
            this.but_login.Size = new System.Drawing.Size(64, 22);
            this.but_login.TabIndex = 3;
            this.but_login.Text = "登陆";
            this.but_login.UseVisualStyleBackColor = true;
            this.but_login.Click += new System.EventHandler(this.but_login_Click);
            // 
            // label_login_id
            // 
            this.label_login_id.AutoSize = true;
            this.label_login_id.Location = new System.Drawing.Point(51, 24);
            this.label_login_id.Name = "label_login_id";
            this.label_login_id.Size = new System.Drawing.Size(29, 12);
            this.label_login_id.TabIndex = 1;
            this.label_login_id.Text = "账号";
            // 
            // label_login_psw
            // 
            this.label_login_psw.AutoSize = true;
            this.label_login_psw.Location = new System.Drawing.Point(51, 58);
            this.label_login_psw.Name = "label_login_psw";
            this.label_login_psw.Size = new System.Drawing.Size(29, 12);
            this.label_login_psw.TabIndex = 2;
            this.label_login_psw.Text = "密码";
            // 
            // textBox_login_psw
            // 
            this.textBox_login_psw.AcceptsTab = true;
            this.textBox_login_psw.Location = new System.Drawing.Point(101, 55);
            this.textBox_login_psw.Name = "textBox_login_psw";
            this.textBox_login_psw.PasswordChar = '*';
            this.textBox_login_psw.Size = new System.Drawing.Size(135, 21);
            this.textBox_login_psw.TabIndex = 2;
            // 
            // but_exit
            // 
            this.but_exit.Location = new System.Drawing.Point(171, 93);
            this.but_exit.Name = "but_exit";
            this.but_exit.Size = new System.Drawing.Size(65, 23);
            this.but_exit.TabIndex = 4;
            this.but_exit.Text = "退出";
            this.but_exit.UseVisualStyleBackColor = true;
            this.but_exit.Click += new System.EventHandler(this.but_exit_Click);
            // 
            // comboBox_login_id
            // 
            this.comboBox_login_id.FormattingEnabled = true;
            this.comboBox_login_id.Location = new System.Drawing.Point(101, 21);
            this.comboBox_login_id.Name = "comboBox_login_id";
            this.comboBox_login_id.Size = new System.Drawing.Size(135, 20);
            this.comboBox_login_id.TabIndex = 1;
            this.comboBox_login_id.SelectedIndexChanged += new System.EventHandler(this.comboBox_login_id_SelectedIndexChanged);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 130);
            this.Controls.Add(this.comboBox_login_id);
            this.Controls.Add(this.textBox_login_psw);
            this.Controls.Add(this.label_login_psw);
            this.Controls.Add(this.label_login_id);
            this.Controls.Add(this.but_exit);
            this.Controls.Add(this.but_login);
            this.Location = new System.Drawing.Point(200, 200);
            this.Name = "FormLogin";
            this.Text = "用户登陆";
            this.Load += new System.EventHandler(this.login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_login;
        private System.Windows.Forms.Label label_login_id;
        private System.Windows.Forms.Label label_login_psw;
        private System.Windows.Forms.TextBox textBox_login_psw;
        private System.Windows.Forms.Button but_exit;
        private System.Windows.Forms.ComboBox comboBox_login_id;
    }
}