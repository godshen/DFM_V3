namespace DigitalFenceMonitor
{
    partial class SystemConfig
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
            this.textBox_localPort = new System.Windows.Forms.TextBox();
            this.label_localIP = new System.Windows.Forms.Label();
            this.label_localPort = new System.Windows.Forms.Label();
            this.button_Confirm = new System.Windows.Forms.Button();
            this.comboBox_localIP = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBox_localPort
            // 
            this.textBox_localPort.Location = new System.Drawing.Point(113, 72);
            this.textBox_localPort.Name = "textBox_localPort";
            this.textBox_localPort.Size = new System.Drawing.Size(131, 21);
            this.textBox_localPort.TabIndex = 0;
            // 
            // label_localIP
            // 
            this.label_localIP.AutoSize = true;
            this.label_localIP.Location = new System.Drawing.Point(24, 33);
            this.label_localIP.Name = "label_localIP";
            this.label_localIP.Size = new System.Drawing.Size(65, 12);
            this.label_localIP.TabIndex = 1;
            this.label_localIP.Text = "本机IP地址";
            // 
            // label_localPort
            // 
            this.label_localPort.AutoSize = true;
            this.label_localPort.Location = new System.Drawing.Point(48, 75);
            this.label_localPort.Name = "label_localPort";
            this.label_localPort.Size = new System.Drawing.Size(41, 12);
            this.label_localPort.TabIndex = 1;
            this.label_localPort.Text = "端口号";
            // 
            // button_Confirm
            // 
            this.button_Confirm.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button_Confirm.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Confirm.Location = new System.Drawing.Point(95, 112);
            this.button_Confirm.Margin = new System.Windows.Forms.Padding(2);
            this.button_Confirm.Name = "button_Confirm";
            this.button_Confirm.Padding = new System.Windows.Forms.Padding(1);
            this.button_Confirm.Size = new System.Drawing.Size(85, 45);
            this.button_Confirm.TabIndex = 3;
            this.button_Confirm.Text = "确认";
            this.button_Confirm.UseVisualStyleBackColor = false;
            this.button_Confirm.Click += new System.EventHandler(this.button_Confirm_Click);
            // 
            // comboBox_localIP
            // 
            this.comboBox_localIP.FormattingEnabled = true;
            this.comboBox_localIP.Location = new System.Drawing.Point(113, 30);
            this.comboBox_localIP.Name = "comboBox_localIP";
            this.comboBox_localIP.Size = new System.Drawing.Size(131, 20);
            this.comboBox_localIP.TabIndex = 4;
            // 
            // SystemConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 168);
            this.Controls.Add(this.comboBox_localIP);
            this.Controls.Add(this.button_Confirm);
            this.Controls.Add(this.label_localPort);
            this.Controls.Add(this.label_localIP);
            this.Controls.Add(this.textBox_localPort);
            this.Name = "SystemConfig";
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.SystemConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_localPort;
        private System.Windows.Forms.Label label_localIP;
        private System.Windows.Forms.Label label_localPort;
        private System.Windows.Forms.Button button_Confirm;
        private System.Windows.Forms.ComboBox comboBox_localIP;
    }
}