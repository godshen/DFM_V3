namespace DigitalFenceMonitor
{
    partial class FormMusic
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
            this.btn_confirm = new System.Windows.Forms.Button();
            this.btn_Brows = new System.Windows.Forms.Button();
            this.textBox_MapPath = new System.Windows.Forms.TextBox();
            this.lab_MusicPath = new System.Windows.Forms.Label();
            this.button_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_confirm
            // 
            this.btn_confirm.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_confirm.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_confirm.Location = new System.Drawing.Point(198, 125);
            this.btn_confirm.Margin = new System.Windows.Forms.Padding(2);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Padding = new System.Windows.Forms.Padding(1);
            this.btn_confirm.Size = new System.Drawing.Size(65, 26);
            this.btn_confirm.TabIndex = 11;
            this.btn_confirm.Text = "确认";
            this.btn_confirm.UseVisualStyleBackColor = false;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // btn_Brows
            // 
            this.btn_Brows.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Brows.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Brows.Location = new System.Drawing.Point(268, 54);
            this.btn_Brows.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Brows.Name = "btn_Brows";
            this.btn_Brows.Padding = new System.Windows.Forms.Padding(1);
            this.btn_Brows.Size = new System.Drawing.Size(65, 26);
            this.btn_Brows.TabIndex = 10;
            this.btn_Brows.Text = "浏览";
            this.btn_Brows.UseVisualStyleBackColor = false;
            this.btn_Brows.Click += new System.EventHandler(this.btn_Brows_Click);
            // 
            // textBox_MapPath
            // 
            this.textBox_MapPath.AcceptsReturn = true;
            this.textBox_MapPath.Location = new System.Drawing.Point(26, 54);
            this.textBox_MapPath.Name = "textBox_MapPath";
            this.textBox_MapPath.Size = new System.Drawing.Size(237, 21);
            this.textBox_MapPath.TabIndex = 9;
            // 
            // lab_MusicPath
            // 
            this.lab_MusicPath.AutoSize = true;
            this.lab_MusicPath.Location = new System.Drawing.Point(23, 22);
            this.lab_MusicPath.Name = "lab_MusicPath";
            this.lab_MusicPath.Size = new System.Drawing.Size(89, 12);
            this.lab_MusicPath.TabIndex = 8;
            this.lab_MusicPath.Text = "警报音地图路径";
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_exit.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_exit.Location = new System.Drawing.Point(268, 125);
            this.button_exit.Margin = new System.Windows.Forms.Padding(2);
            this.button_exit.Name = "button_exit";
            this.button_exit.Padding = new System.Windows.Forms.Padding(1);
            this.button_exit.Size = new System.Drawing.Size(65, 26);
            this.button_exit.TabIndex = 12;
            this.button_exit.Text = "退出";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // FormMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 183);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.btn_Brows);
            this.Controls.Add(this.textBox_MapPath);
            this.Controls.Add(this.lab_MusicPath);
            this.Name = "FormMusic";
            this.Text = "报警声音设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Button btn_Brows;
        private System.Windows.Forms.TextBox textBox_MapPath;
        private System.Windows.Forms.Label lab_MusicPath;
        private System.Windows.Forms.Button button_exit;
    }
}