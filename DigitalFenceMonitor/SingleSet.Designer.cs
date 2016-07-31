namespace DigitalFenceMonitor
{
    partial class SingleSet
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
            this.but_confirm1 = new System.Windows.Forms.Button();
            this.but_confirm0 = new System.Windows.Forms.Button();
            this.comboBox_StaName = new System.Windows.Forms.ComboBox();
            this.comboBox_BuCheFang = new System.Windows.Forms.ComboBox();
            this.lb_StaName = new System.Windows.Forms.Label();
            this.lb_BuCheFang = new System.Windows.Forms.Label();
            this.lb_Beep = new System.Windows.Forms.Label();
            this.comboBox_Beep = new System.Windows.Forms.ComboBox();
            this.lb_Mode = new System.Windows.Forms.Label();
            this.comboBox_Mode = new System.Windows.Forms.ComboBox();
            this.lb_JingDian = new System.Windows.Forms.Label();
            this.comboBox_JingDian = new System.Windows.Forms.ComboBox();
            this.lb_Voltage = new System.Windows.Forms.Label();
            this.comboBox_Voltage = new System.Windows.Forms.ComboBox();
            this.lb_DeviceAdd = new System.Windows.Forms.Label();
            this.comboBox_DeviceAdd = new System.Windows.Forms.ComboBox();
            this.lab_dayTime = new System.Windows.Forms.Label();
            this.lab_dayVol = new System.Windows.Forms.Label();
            this.comboBox_dayVol = new System.Windows.Forms.ComboBox();
            this.lab_nightVol = new System.Windows.Forms.Label();
            this.comboBox_nightVol = new System.Windows.Forms.ComboBox();
            this.lab_nightTime = new System.Windows.Forms.Label();
            this.textBox_dayTime = new System.Windows.Forms.TextBox();
            this.textBox_nightTime = new System.Windows.Forms.TextBox();
            this.rbtn_daynight_on = new System.Windows.Forms.RadioButton();
            this.rbtn_daynight_off = new System.Windows.Forms.RadioButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_status = new System.Windows.Forms.TabPage();
            this.tabPage_daynight = new System.Windows.Forms.TabPage();
            this.lb_ip = new System.Windows.Forms.Label();
            this.lb_thisip = new System.Windows.Forms.Label();
            this.lab_alt = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPage_status.SuspendLayout();
            this.tabPage_daynight.SuspendLayout();
            this.SuspendLayout();
            // 
            // but_confirm1
            // 
            this.but_confirm1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.but_confirm1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_confirm1.Location = new System.Drawing.Point(25, 200);
            this.but_confirm1.Margin = new System.Windows.Forms.Padding(2);
            this.but_confirm1.Name = "but_confirm1";
            this.but_confirm1.Padding = new System.Windows.Forms.Padding(1);
            this.but_confirm1.Size = new System.Drawing.Size(85, 28);
            this.but_confirm1.TabIndex = 1;
            this.but_confirm1.Text = "设置";
            this.but_confirm1.UseVisualStyleBackColor = false;
            this.but_confirm1.Click += new System.EventHandler(this.but_confirm1_Click);
            // 
            // but_confirm0
            // 
            this.but_confirm0.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.but_confirm0.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_confirm0.Location = new System.Drawing.Point(25, 200);
            this.but_confirm0.Margin = new System.Windows.Forms.Padding(2);
            this.but_confirm0.Name = "but_confirm0";
            this.but_confirm0.Padding = new System.Windows.Forms.Padding(1);
            this.but_confirm0.Size = new System.Drawing.Size(82, 28);
            this.but_confirm0.TabIndex = 2;
            this.but_confirm0.Text = "发送";
            this.but_confirm0.UseVisualStyleBackColor = false;
            this.but_confirm0.Click += new System.EventHandler(this.but_confirm0_Click);
            // 
            // comboBox_StaName
            // 
            this.comboBox_StaName.FormattingEnabled = true;
            this.comboBox_StaName.Location = new System.Drawing.Point(79, 20);
            this.comboBox_StaName.Name = "comboBox_StaName";
            this.comboBox_StaName.Size = new System.Drawing.Size(143, 20);
            this.comboBox_StaName.TabIndex = 10;
            this.comboBox_StaName.TextChanged += new System.EventHandler(this.comboBox_StaName_TextChanged);
            // 
            // comboBox_BuCheFang
            // 
            this.comboBox_BuCheFang.FormattingEnabled = true;
            this.comboBox_BuCheFang.Location = new System.Drawing.Point(78, 19);
            this.comboBox_BuCheFang.Name = "comboBox_BuCheFang";
            this.comboBox_BuCheFang.Size = new System.Drawing.Size(111, 20);
            this.comboBox_BuCheFang.TabIndex = 11;
            // 
            // lb_StaName
            // 
            this.lb_StaName.AutoSize = true;
            this.lb_StaName.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_StaName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_StaName.Location = new System.Drawing.Point(7, 25);
            this.lb_StaName.Name = "lb_StaName";
            this.lb_StaName.Size = new System.Drawing.Size(67, 15);
            this.lb_StaName.TabIndex = 12;
            this.lb_StaName.Text = "基站名称";
            // 
            // lb_BuCheFang
            // 
            this.lb_BuCheFang.AutoSize = true;
            this.lb_BuCheFang.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_BuCheFang.Location = new System.Drawing.Point(20, 23);
            this.lb_BuCheFang.Name = "lb_BuCheFang";
            this.lb_BuCheFang.Size = new System.Drawing.Size(53, 12);
            this.lb_BuCheFang.TabIndex = 13;
            this.lb_BuCheFang.Text = "布防撤防";
            // 
            // lb_Beep
            // 
            this.lb_Beep.AutoSize = true;
            this.lb_Beep.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Beep.Location = new System.Drawing.Point(20, 59);
            this.lb_Beep.Name = "lb_Beep";
            this.lb_Beep.Size = new System.Drawing.Size(53, 12);
            this.lb_Beep.TabIndex = 15;
            this.lb_Beep.Text = "蜂鸣开关";
            // 
            // comboBox_Beep
            // 
            this.comboBox_Beep.FormattingEnabled = true;
            this.comboBox_Beep.Location = new System.Drawing.Point(78, 55);
            this.comboBox_Beep.Name = "comboBox_Beep";
            this.comboBox_Beep.Size = new System.Drawing.Size(111, 20);
            this.comboBox_Beep.TabIndex = 14;
            // 
            // lb_Mode
            // 
            this.lb_Mode.AutoSize = true;
            this.lb_Mode.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Mode.Location = new System.Drawing.Point(20, 95);
            this.lb_Mode.Name = "lb_Mode";
            this.lb_Mode.Size = new System.Drawing.Size(53, 12);
            this.lb_Mode.TabIndex = 17;
            this.lb_Mode.Text = "工作模式";
            // 
            // comboBox_Mode
            // 
            this.comboBox_Mode.FormattingEnabled = true;
            this.comboBox_Mode.Location = new System.Drawing.Point(78, 91);
            this.comboBox_Mode.Name = "comboBox_Mode";
            this.comboBox_Mode.Size = new System.Drawing.Size(111, 20);
            this.comboBox_Mode.TabIndex = 16;
            // 
            // lb_JingDian
            // 
            this.lb_JingDian.AutoSize = true;
            this.lb_JingDian.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_JingDian.Location = new System.Drawing.Point(20, 131);
            this.lb_JingDian.Name = "lb_JingDian";
            this.lb_JingDian.Size = new System.Drawing.Size(53, 12);
            this.lb_JingDian.TabIndex = 19;
            this.lb_JingDian.Text = "静电感应";
            // 
            // comboBox_JingDian
            // 
            this.comboBox_JingDian.FormattingEnabled = true;
            this.comboBox_JingDian.Location = new System.Drawing.Point(78, 127);
            this.comboBox_JingDian.Name = "comboBox_JingDian";
            this.comboBox_JingDian.Size = new System.Drawing.Size(111, 20);
            this.comboBox_JingDian.TabIndex = 18;
            // 
            // lb_Voltage
            // 
            this.lb_Voltage.AutoSize = true;
            this.lb_Voltage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Voltage.Location = new System.Drawing.Point(20, 167);
            this.lb_Voltage.Name = "lb_Voltage";
            this.lb_Voltage.Size = new System.Drawing.Size(53, 12);
            this.lb_Voltage.TabIndex = 21;
            this.lb_Voltage.Text = "工作电压";
            // 
            // comboBox_Voltage
            // 
            this.comboBox_Voltage.FormattingEnabled = true;
            this.comboBox_Voltage.Location = new System.Drawing.Point(78, 163);
            this.comboBox_Voltage.Name = "comboBox_Voltage";
            this.comboBox_Voltage.Size = new System.Drawing.Size(111, 20);
            this.comboBox_Voltage.TabIndex = 20;
            // 
            // lb_DeviceAdd
            // 
            this.lb_DeviceAdd.AutoSize = true;
            this.lb_DeviceAdd.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_DeviceAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_DeviceAdd.Location = new System.Drawing.Point(7, 77);
            this.lb_DeviceAdd.Name = "lb_DeviceAdd";
            this.lb_DeviceAdd.Size = new System.Drawing.Size(67, 15);
            this.lb_DeviceAdd.TabIndex = 23;
            this.lb_DeviceAdd.Text = "设备地址";
            // 
            // comboBox_DeviceAdd
            // 
            this.comboBox_DeviceAdd.FormattingEnabled = true;
            this.comboBox_DeviceAdd.Location = new System.Drawing.Point(80, 72);
            this.comboBox_DeviceAdd.Name = "comboBox_DeviceAdd";
            this.comboBox_DeviceAdd.Size = new System.Drawing.Size(142, 20);
            this.comboBox_DeviceAdd.TabIndex = 22;
            // 
            // lab_dayTime
            // 
            this.lab_dayTime.AutoSize = true;
            this.lab_dayTime.Enabled = false;
            this.lab_dayTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_dayTime.Location = new System.Drawing.Point(24, 56);
            this.lab_dayTime.Name = "lab_dayTime";
            this.lab_dayTime.Size = new System.Drawing.Size(53, 12);
            this.lab_dayTime.TabIndex = 26;
            this.lab_dayTime.Text = "白天时间";
            // 
            // lab_dayVol
            // 
            this.lab_dayVol.AutoSize = true;
            this.lab_dayVol.Enabled = false;
            this.lab_dayVol.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_dayVol.Location = new System.Drawing.Point(24, 91);
            this.lab_dayVol.Name = "lab_dayVol";
            this.lab_dayVol.Size = new System.Drawing.Size(53, 12);
            this.lab_dayVol.TabIndex = 28;
            this.lab_dayVol.Text = "白天电压";
            // 
            // comboBox_dayVol
            // 
            this.comboBox_dayVol.Enabled = false;
            this.comboBox_dayVol.FormattingEnabled = true;
            this.comboBox_dayVol.Location = new System.Drawing.Point(82, 87);
            this.comboBox_dayVol.Name = "comboBox_dayVol";
            this.comboBox_dayVol.Size = new System.Drawing.Size(67, 20);
            this.comboBox_dayVol.TabIndex = 27;
            // 
            // lab_nightVol
            // 
            this.lab_nightVol.AutoSize = true;
            this.lab_nightVol.Enabled = false;
            this.lab_nightVol.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_nightVol.Location = new System.Drawing.Point(24, 159);
            this.lab_nightVol.Name = "lab_nightVol";
            this.lab_nightVol.Size = new System.Drawing.Size(53, 12);
            this.lab_nightVol.TabIndex = 32;
            this.lab_nightVol.Text = "夜晚电压";
            // 
            // comboBox_nightVol
            // 
            this.comboBox_nightVol.Enabled = false;
            this.comboBox_nightVol.FormattingEnabled = true;
            this.comboBox_nightVol.Location = new System.Drawing.Point(82, 155);
            this.comboBox_nightVol.Name = "comboBox_nightVol";
            this.comboBox_nightVol.Size = new System.Drawing.Size(67, 20);
            this.comboBox_nightVol.TabIndex = 31;
            // 
            // lab_nightTime
            // 
            this.lab_nightTime.AutoSize = true;
            this.lab_nightTime.Enabled = false;
            this.lab_nightTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_nightTime.Location = new System.Drawing.Point(24, 124);
            this.lab_nightTime.Name = "lab_nightTime";
            this.lab_nightTime.Size = new System.Drawing.Size(53, 12);
            this.lab_nightTime.TabIndex = 30;
            this.lab_nightTime.Text = "夜晚时间";
            // 
            // textBox_dayTime
            // 
            this.textBox_dayTime.Location = new System.Drawing.Point(82, 51);
            this.textBox_dayTime.Name = "textBox_dayTime";
            this.textBox_dayTime.Size = new System.Drawing.Size(67, 21);
            this.textBox_dayTime.TabIndex = 33;
            // 
            // textBox_nightTime
            // 
            this.textBox_nightTime.Location = new System.Drawing.Point(82, 124);
            this.textBox_nightTime.Name = "textBox_nightTime";
            this.textBox_nightTime.Size = new System.Drawing.Size(67, 21);
            this.textBox_nightTime.TabIndex = 34;
            // 
            // rbtn_daynight_on
            // 
            this.rbtn_daynight_on.AutoSize = true;
            this.rbtn_daynight_on.Location = new System.Drawing.Point(20, 23);
            this.rbtn_daynight_on.Name = "rbtn_daynight_on";
            this.rbtn_daynight_on.Size = new System.Drawing.Size(95, 16);
            this.rbtn_daynight_on.TabIndex = 35;
            this.rbtn_daynight_on.Text = "开启昼夜转换";
            this.rbtn_daynight_on.UseVisualStyleBackColor = true;
            this.rbtn_daynight_on.CheckedChanged += new System.EventHandler(this.rbtn_daynight_on_CheckedChanged);
            // 
            // rbtn_daynight_off
            // 
            this.rbtn_daynight_off.AutoSize = true;
            this.rbtn_daynight_off.Checked = true;
            this.rbtn_daynight_off.Location = new System.Drawing.Point(121, 23);
            this.rbtn_daynight_off.Name = "rbtn_daynight_off";
            this.rbtn_daynight_off.Size = new System.Drawing.Size(95, 16);
            this.rbtn_daynight_off.TabIndex = 36;
            this.rbtn_daynight_off.TabStop = true;
            this.rbtn_daynight_off.Text = "关闭昼夜转换";
            this.rbtn_daynight_off.UseVisualStyleBackColor = true;
            this.rbtn_daynight_off.CheckedChanged += new System.EventHandler(this.rbtn_daynight_off_CheckedChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_status);
            this.tabControl.Controls.Add(this.tabPage_daynight);
            this.tabControl.Location = new System.Drawing.Point(10, 111);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(229, 269);
            this.tabControl.TabIndex = 37;
            // 
            // tabPage_status
            // 
            this.tabPage_status.Controls.Add(this.comboBox_Voltage);
            this.tabPage_status.Controls.Add(this.comboBox_BuCheFang);
            this.tabPage_status.Controls.Add(this.lb_BuCheFang);
            this.tabPage_status.Controls.Add(this.comboBox_Beep);
            this.tabPage_status.Controls.Add(this.lb_Beep);
            this.tabPage_status.Controls.Add(this.but_confirm0);
            this.tabPage_status.Controls.Add(this.comboBox_Mode);
            this.tabPage_status.Controls.Add(this.lb_Mode);
            this.tabPage_status.Controls.Add(this.comboBox_JingDian);
            this.tabPage_status.Controls.Add(this.lb_JingDian);
            this.tabPage_status.Controls.Add(this.lb_Voltage);
            this.tabPage_status.Location = new System.Drawing.Point(4, 22);
            this.tabPage_status.Name = "tabPage_status";
            this.tabPage_status.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_status.Size = new System.Drawing.Size(233, 243);
            this.tabPage_status.TabIndex = 0;
            this.tabPage_status.Text = "状态设置";
            this.tabPage_status.UseVisualStyleBackColor = true;
            // 
            // tabPage_daynight
            // 
            this.tabPage_daynight.Controls.Add(this.lab_alt);
            this.tabPage_daynight.Controls.Add(this.comboBox_dayVol);
            this.tabPage_daynight.Controls.Add(this.rbtn_daynight_off);
            this.tabPage_daynight.Controls.Add(this.rbtn_daynight_on);
            this.tabPage_daynight.Controls.Add(this.lab_dayTime);
            this.tabPage_daynight.Controls.Add(this.lab_dayVol);
            this.tabPage_daynight.Controls.Add(this.but_confirm1);
            this.tabPage_daynight.Controls.Add(this.textBox_nightTime);
            this.tabPage_daynight.Controls.Add(this.lab_nightTime);
            this.tabPage_daynight.Controls.Add(this.textBox_dayTime);
            this.tabPage_daynight.Controls.Add(this.comboBox_nightVol);
            this.tabPage_daynight.Controls.Add(this.lab_nightVol);
            this.tabPage_daynight.Location = new System.Drawing.Point(4, 22);
            this.tabPage_daynight.Name = "tabPage_daynight";
            this.tabPage_daynight.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_daynight.Size = new System.Drawing.Size(221, 243);
            this.tabPage_daynight.TabIndex = 1;
            this.tabPage_daynight.Text = "昼夜转换";
            this.tabPage_daynight.UseVisualStyleBackColor = true;
            // 
            // lb_ip
            // 
            this.lb_ip.AutoSize = true;
            this.lb_ip.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_ip.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_ip.Location = new System.Drawing.Point(7, 50);
            this.lb_ip.Name = "lb_ip";
            this.lb_ip.Size = new System.Drawing.Size(61, 15);
            this.lb_ip.TabIndex = 38;
            this.lb_ip.Text = "基站 IP";
            // 
            // lb_thisip
            // 
            this.lb_thisip.AutoSize = true;
            this.lb_thisip.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_thisip.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_thisip.Location = new System.Drawing.Point(80, 50);
            this.lb_thisip.Name = "lb_thisip";
            this.lb_thisip.Size = new System.Drawing.Size(63, 15);
            this.lb_thisip.TabIndex = 39;
            this.lb_thisip.Text = "0.0.0.0";
            // 
            // lab_alt
            // 
            this.lab_alt.AutoSize = true;
            this.lab_alt.Location = new System.Drawing.Point(155, 54);
            this.lab_alt.Name = "lab_alt";
            this.lab_alt.Size = new System.Drawing.Size(53, 12);
            this.lab_alt.TabIndex = 37;
            this.lab_alt.Text = "例 14:28";
            // 
            // SingleSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 391);
            this.Controls.Add(this.lb_thisip);
            this.Controls.Add(this.lb_ip);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lb_DeviceAdd);
            this.Controls.Add(this.comboBox_DeviceAdd);
            this.Controls.Add(this.lb_StaName);
            this.Controls.Add(this.comboBox_StaName);
            this.Name = "SingleSet";
            this.Text = "单个设置";
            this.Load += new System.EventHandler(this.SingleSet_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage_status.ResumeLayout(false);
            this.tabPage_status.PerformLayout();
            this.tabPage_daynight.ResumeLayout(false);
            this.tabPage_daynight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_confirm1;
        private System.Windows.Forms.Button but_confirm0;
        private System.Windows.Forms.ComboBox comboBox_StaName;
        private System.Windows.Forms.ComboBox comboBox_BuCheFang;
        private System.Windows.Forms.Label lb_StaName;
        private System.Windows.Forms.Label lb_BuCheFang;
        private System.Windows.Forms.Label lb_Beep;
        private System.Windows.Forms.ComboBox comboBox_Beep;
        private System.Windows.Forms.Label lb_Mode;
        private System.Windows.Forms.ComboBox comboBox_Mode;
        private System.Windows.Forms.Label lb_JingDian;
        private System.Windows.Forms.ComboBox comboBox_JingDian;
        private System.Windows.Forms.Label lb_Voltage;
        private System.Windows.Forms.ComboBox comboBox_Voltage;
        private System.Windows.Forms.Label lb_DeviceAdd;
        private System.Windows.Forms.ComboBox comboBox_DeviceAdd;
        private System.Windows.Forms.Label lab_dayTime;
        private System.Windows.Forms.Label lab_dayVol;
        private System.Windows.Forms.ComboBox comboBox_dayVol;
        private System.Windows.Forms.Label lab_nightVol;
        private System.Windows.Forms.ComboBox comboBox_nightVol;
        private System.Windows.Forms.Label lab_nightTime;
        private System.Windows.Forms.TextBox textBox_dayTime;
        private System.Windows.Forms.TextBox textBox_nightTime;
        private System.Windows.Forms.RadioButton rbtn_daynight_on;
        private System.Windows.Forms.RadioButton rbtn_daynight_off;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_status;
        private System.Windows.Forms.TabPage tabPage_daynight;
        private System.Windows.Forms.Label lb_ip;
        private System.Windows.Forms.Label lb_thisip;
        private System.Windows.Forms.Label lab_alt;
    }
}