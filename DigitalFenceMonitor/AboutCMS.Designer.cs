namespace DigitalFenceMonitor
{
    partial class AboutCMS
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
            this.lb_ver = new System.Windows.Forms.Label();
            this.lb_Serial = new System.Windows.Forms.Label();
            this.lb_reg = new System.Windows.Forms.Label();
            this.lb_ver30 = new System.Windows.Forms.Label();
            this.textBox_reg = new System.Windows.Forms.TextBox();
            this.btn_reg = new System.Windows.Forms.Button();
            this.textBox_ser = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lb_ver
            // 
            this.lb_ver.AutoSize = true;
            this.lb_ver.Location = new System.Drawing.Point(21, 10);
            this.lb_ver.Name = "lb_ver";
            this.lb_ver.Size = new System.Drawing.Size(29, 12);
            this.lb_ver.TabIndex = 0;
            this.lb_ver.Text = "版本";
            // 
            // lb_Serial
            // 
            this.lb_Serial.AutoSize = true;
            this.lb_Serial.Location = new System.Drawing.Point(21, 36);
            this.lb_Serial.Name = "lb_Serial";
            this.lb_Serial.Size = new System.Drawing.Size(41, 12);
            this.lb_Serial.TabIndex = 1;
            this.lb_Serial.Text = "序列号";
            // 
            // lb_reg
            // 
            this.lb_reg.AutoSize = true;
            this.lb_reg.Location = new System.Drawing.Point(21, 64);
            this.lb_reg.Name = "lb_reg";
            this.lb_reg.Size = new System.Drawing.Size(41, 12);
            this.lb_reg.TabIndex = 2;
            this.lb_reg.Text = "注册号";
            // 
            // lb_ver30
            // 
            this.lb_ver30.AutoSize = true;
            this.lb_ver30.Location = new System.Drawing.Point(105, 10);
            this.lb_ver30.Name = "lb_ver30";
            this.lb_ver30.Size = new System.Drawing.Size(29, 12);
            this.lb_ver30.TabIndex = 3;
            this.lb_ver30.Text = "V3.0";
            // 
            // textBox_reg
            // 
            this.textBox_reg.Location = new System.Drawing.Point(107, 61);
            this.textBox_reg.Name = "textBox_reg";
            this.textBox_reg.Size = new System.Drawing.Size(100, 21);
            this.textBox_reg.TabIndex = 5;
            // 
            // btn_reg
            // 
            this.btn_reg.Location = new System.Drawing.Point(51, 106);
            this.btn_reg.Name = "btn_reg";
            this.btn_reg.Size = new System.Drawing.Size(184, 23);
            this.btn_reg.TabIndex = 6;
            this.btn_reg.Text = "点击注册";
            this.btn_reg.UseVisualStyleBackColor = true;
            this.btn_reg.Click += new System.EventHandler(this.btn_reg_Click);
            // 
            // textBox_ser
            // 
            this.textBox_ser.Location = new System.Drawing.Point(107, 33);
            this.textBox_ser.Name = "textBox_ser";
            this.textBox_ser.Size = new System.Drawing.Size(100, 21);
            this.textBox_ser.TabIndex = 7;
            // 
            // AboutCMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 141);
            this.Controls.Add(this.textBox_ser);
            this.Controls.Add(this.btn_reg);
            this.Controls.Add(this.textBox_reg);
            this.Controls.Add(this.lb_ver30);
            this.Controls.Add(this.lb_reg);
            this.Controls.Add(this.lb_Serial);
            this.Controls.Add(this.lb_ver);
            this.Name = "AboutCMS";
            this.Text = "关于CMS3.0";
            this.Load += new System.EventHandler(this.AboutCMS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_ver;
        private System.Windows.Forms.Label lb_Serial;
        private System.Windows.Forms.Label lb_reg;
        private System.Windows.Forms.Label lb_ver30;
        private System.Windows.Forms.TextBox textBox_reg;
        private System.Windows.Forms.Button btn_reg;
        private System.Windows.Forms.TextBox textBox_ser;
    }
}