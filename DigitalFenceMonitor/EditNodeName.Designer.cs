namespace DigitalFenceMonitor
{
    partial class EditNodeName
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
            this.lb_old = new System.Windows.Forms.Label();
            this.lb_new = new System.Windows.Forms.Label();
            this.tBox_new = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_quit = new System.Windows.Forms.Button();
            this.tBox_old = new System.Windows.Forms.ComboBox();
            this.comboBox_new = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lb_old
            // 
            this.lb_old.AutoSize = true;
            this.lb_old.Location = new System.Drawing.Point(12, 9);
            this.lb_old.Name = "lb_old";
            this.lb_old.Size = new System.Drawing.Size(53, 12);
            this.lb_old.TabIndex = 0;
            this.lb_old.Text = "现在名称";
            // 
            // lb_new
            // 
            this.lb_new.AutoSize = true;
            this.lb_new.Location = new System.Drawing.Point(12, 36);
            this.lb_new.Name = "lb_new";
            this.lb_new.Size = new System.Drawing.Size(41, 12);
            this.lb_new.TabIndex = 1;
            this.lb_new.Text = "新名称";
            // 
            // tBox_new
            // 
            this.tBox_new.Location = new System.Drawing.Point(96, 33);
            this.tBox_new.Name = "tBox_new";
            this.tBox_new.Size = new System.Drawing.Size(120, 21);
            this.tBox_new.TabIndex = 3;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(37, 70);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(59, 23);
            this.btn_ok.TabIndex = 4;
            this.btn_ok.Text = "确认";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_quit
            // 
            this.btn_quit.Location = new System.Drawing.Point(116, 70);
            this.btn_quit.Name = "btn_quit";
            this.btn_quit.Size = new System.Drawing.Size(57, 23);
            this.btn_quit.TabIndex = 5;
            this.btn_quit.Text = "退出";
            this.btn_quit.UseVisualStyleBackColor = true;
            this.btn_quit.Click += new System.EventHandler(this.btn_quit_Click);
            // 
            // tBox_old
            // 
            this.tBox_old.Location = new System.Drawing.Point(95, 6);
            this.tBox_old.Name = "tBox_old";
            this.tBox_old.Size = new System.Drawing.Size(121, 20);
            this.tBox_old.TabIndex = 6;
            // 
            // comboBox_new
            // 
            this.comboBox_new.Location = new System.Drawing.Point(95, 32);
            this.comboBox_new.Name = "comboBox_new";
            this.comboBox_new.Size = new System.Drawing.Size(121, 20);
            this.comboBox_new.TabIndex = 7;
            // 
            // EditNodeName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 104);
            this.Controls.Add(this.comboBox_new);
            this.Controls.Add(this.tBox_old);
            this.Controls.Add(this.btn_quit);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.tBox_new);
            this.Controls.Add(this.lb_new);
            this.Controls.Add(this.lb_old);
            this.Name = "EditNodeName";
            this.Text = "修改名称";
            this.Load += new System.EventHandler(this.EditNodeName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_old;
        private System.Windows.Forms.Label lb_new;
        private System.Windows.Forms.TextBox tBox_new;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_quit;
        private System.Windows.Forms.ComboBox tBox_old;
        private System.Windows.Forms.ComboBox comboBox_new;
    }
}