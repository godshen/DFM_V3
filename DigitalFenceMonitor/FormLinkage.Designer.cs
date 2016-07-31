namespace DigitalFenceMonitor
{
    partial class FormLinkage
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
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Done = new System.Windows.Forms.Button();
            this.comboBox_SerialNum = new System.Windows.Forms.ComboBox();
            this.lab_SerialNum = new System.Windows.Forms.Label();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.lab_method = new System.Windows.Forms.Label();
            this.rbtn_net = new System.Windows.Forms.RadioButton();
            this.rbtn_serial = new System.Windows.Forms.RadioButton();
            this.lab_alert0 = new System.Windows.Forms.Label();
            this.lab_alert1 = new System.Windows.Forms.Label();
            this.lab_LinkNode = new System.Windows.Forms.Label();
            this.textBox_Node = new System.Windows.Forms.TextBox();
            this.lb_thisip = new System.Windows.Forms.Label();
            this.lb_ip = new System.Windows.Forms.Label();
            this.lb_DeviceAdd = new System.Windows.Forms.Label();
            this.comboBox_DeviceAdd = new System.Windows.Forms.ComboBox();
            this.lb_StaName = new System.Windows.Forms.Label();
            this.comboBox_StaName = new System.Windows.Forms.ComboBox();
            this.comboBox_Position = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Reset
            // 
            this.btn_Reset.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btn_Reset.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Reset.Location = new System.Drawing.Point(159, 298);
            this.btn_Reset.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Padding = new System.Windows.Forms.Padding(1);
            this.btn_Reset.Size = new System.Drawing.Size(85, 45);
            this.btn_Reset.TabIndex = 6;
            this.btn_Reset.Text = "重置";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_Done
            // 
            this.btn_Done.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btn_Done.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Done.Location = new System.Drawing.Point(47, 298);
            this.btn_Done.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Done.Name = "btn_Done";
            this.btn_Done.Padding = new System.Windows.Forms.Padding(1);
            this.btn_Done.Size = new System.Drawing.Size(85, 45);
            this.btn_Done.TabIndex = 5;
            this.btn_Done.Text = "确定";
            this.btn_Done.UseVisualStyleBackColor = false;
            this.btn_Done.Click += new System.EventHandler(this.btn_Done_Click);
            // 
            // comboBox_SerialNum
            // 
            this.comboBox_SerialNum.FormattingEnabled = true;
            this.comboBox_SerialNum.Location = new System.Drawing.Point(121, 62);
            this.comboBox_SerialNum.Name = "comboBox_SerialNum";
            this.comboBox_SerialNum.Size = new System.Drawing.Size(135, 20);
            this.comboBox_SerialNum.TabIndex = 3;
            // 
            // lab_SerialNum
            // 
            this.lab_SerialNum.AutoSize = true;
            this.lab_SerialNum.Font = new System.Drawing.Font("黑体", 12F);
            this.lab_SerialNum.Location = new System.Drawing.Point(34, 61);
            this.lab_SerialNum.Name = "lab_SerialNum";
            this.lab_SerialNum.Size = new System.Drawing.Size(72, 16);
            this.lab_SerialNum.TabIndex = 0;
            this.lab_SerialNum.Text = "串口编号";
            // 
            // lab_method
            // 
            this.lab_method.AutoSize = true;
            this.lab_method.Font = new System.Drawing.Font("黑体", 12F);
            this.lab_method.Location = new System.Drawing.Point(34, 28);
            this.lab_method.Name = "lab_method";
            this.lab_method.Size = new System.Drawing.Size(72, 16);
            this.lab_method.TabIndex = 11;
            this.lab_method.Text = "联动方式";
            // 
            // rbtn_net
            // 
            this.rbtn_net.AutoSize = true;
            this.rbtn_net.Location = new System.Drawing.Point(121, 28);
            this.rbtn_net.Name = "rbtn_net";
            this.rbtn_net.Size = new System.Drawing.Size(47, 16);
            this.rbtn_net.TabIndex = 12;
            this.rbtn_net.TabStop = true;
            this.rbtn_net.Text = "网络";
            this.rbtn_net.UseVisualStyleBackColor = true;
            this.rbtn_net.CheckedChanged += new System.EventHandler(this.rbtn_net_CheckedChanged);
            // 
            // rbtn_serial
            // 
            this.rbtn_serial.AutoSize = true;
            this.rbtn_serial.Location = new System.Drawing.Point(186, 28);
            this.rbtn_serial.Name = "rbtn_serial";
            this.rbtn_serial.Size = new System.Drawing.Size(47, 16);
            this.rbtn_serial.TabIndex = 13;
            this.rbtn_serial.TabStop = true;
            this.rbtn_serial.Text = "串口";
            this.rbtn_serial.UseVisualStyleBackColor = true;
            this.rbtn_serial.CheckedChanged += new System.EventHandler(this.rbtn_serial_CheckedChanged);
            // 
            // lab_alert0
            // 
            this.lab_alert0.AutoSize = true;
            this.lab_alert0.Location = new System.Drawing.Point(121, 259);
            this.lab_alert0.Name = "lab_alert0";
            this.lab_alert0.Size = new System.Drawing.Size(161, 12);
            this.lab_alert0.TabIndex = 14;
            this.lab_alert0.Text = "提示:如有多个结点，用,隔开";
            // 
            // lab_alert1
            // 
            this.lab_alert1.AutoSize = true;
            this.lab_alert1.Location = new System.Drawing.Point(121, 276);
            this.lab_alert1.Name = "lab_alert1";
            this.lab_alert1.Size = new System.Drawing.Size(65, 12);
            this.lab_alert1.TabIndex = 15;
            this.lab_alert1.Text = "如:1,3,4,7";
            // 
            // lab_LinkNode
            // 
            this.lab_LinkNode.AutoSize = true;
            this.lab_LinkNode.Font = new System.Drawing.Font("黑体", 12F);
            this.lab_LinkNode.Location = new System.Drawing.Point(34, 230);
            this.lab_LinkNode.Name = "lab_LinkNode";
            this.lab_LinkNode.Size = new System.Drawing.Size(72, 16);
            this.lab_LinkNode.TabIndex = 0;
            this.lab_LinkNode.Text = "联动结点";
            // 
            // textBox_Node
            // 
            this.textBox_Node.AcceptsTab = true;
            this.textBox_Node.Location = new System.Drawing.Point(121, 231);
            this.textBox_Node.Name = "textBox_Node";
            this.textBox_Node.Size = new System.Drawing.Size(135, 21);
            this.textBox_Node.TabIndex = 4;
            // 
            // lb_thisip
            // 
            this.lb_thisip.AutoSize = true;
            this.lb_thisip.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_thisip.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_thisip.Location = new System.Drawing.Point(118, 124);
            this.lb_thisip.Name = "lb_thisip";
            this.lb_thisip.Size = new System.Drawing.Size(63, 15);
            this.lb_thisip.TabIndex = 45;
            this.lb_thisip.Text = "0.0.0.0";
            // 
            // lb_ip
            // 
            this.lb_ip.AutoSize = true;
            this.lb_ip.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_ip.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_ip.Location = new System.Drawing.Point(34, 124);
            this.lb_ip.Name = "lb_ip";
            this.lb_ip.Size = new System.Drawing.Size(64, 16);
            this.lb_ip.TabIndex = 44;
            this.lb_ip.Text = "基站 IP";
            // 
            // lb_DeviceAdd
            // 
            this.lb_DeviceAdd.AutoSize = true;
            this.lb_DeviceAdd.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_DeviceAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_DeviceAdd.Location = new System.Drawing.Point(34, 153);
            this.lb_DeviceAdd.Name = "lb_DeviceAdd";
            this.lb_DeviceAdd.Size = new System.Drawing.Size(72, 16);
            this.lb_DeviceAdd.TabIndex = 43;
            this.lb_DeviceAdd.Text = "设备地址";
            // 
            // comboBox_DeviceAdd
            // 
            this.comboBox_DeviceAdd.FormattingEnabled = true;
            this.comboBox_DeviceAdd.Location = new System.Drawing.Point(121, 149);
            this.comboBox_DeviceAdd.Name = "comboBox_DeviceAdd";
            this.comboBox_DeviceAdd.Size = new System.Drawing.Size(135, 20);
            this.comboBox_DeviceAdd.TabIndex = 42;
            this.comboBox_DeviceAdd.TextChanged += new System.EventHandler(this.comboBox_DeviceAdd_TextChanged);
            // 
            // lb_StaName
            // 
            this.lb_StaName.AutoSize = true;
            this.lb_StaName.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_StaName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_StaName.Location = new System.Drawing.Point(34, 94);
            this.lb_StaName.Name = "lb_StaName";
            this.lb_StaName.Size = new System.Drawing.Size(72, 16);
            this.lb_StaName.TabIndex = 41;
            this.lb_StaName.Text = "基站名称";
            // 
            // comboBox_StaName
            // 
            this.comboBox_StaName.FormattingEnabled = true;
            this.comboBox_StaName.Location = new System.Drawing.Point(121, 96);
            this.comboBox_StaName.Name = "comboBox_StaName";
            this.comboBox_StaName.Size = new System.Drawing.Size(135, 20);
            this.comboBox_StaName.TabIndex = 40;
            this.comboBox_StaName.TextChanged += new System.EventHandler(this.comboBox_StaName_TextChanged);
            // 
            // comboBox_Position
            // 
            this.comboBox_Position.FormattingEnabled = true;
            this.comboBox_Position.Location = new System.Drawing.Point(121, 183);
            this.comboBox_Position.Name = "comboBox_Position";
            this.comboBox_Position.Size = new System.Drawing.Size(135, 20);
            this.comboBox_Position.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 12F);
            this.label4.Location = new System.Drawing.Point(34, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 46;
            this.label4.Text = "防区位置";
            // 
            // FormLinkage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 376);
            this.Controls.Add(this.comboBox_Position);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_thisip);
            this.Controls.Add(this.lb_ip);
            this.Controls.Add(this.lb_DeviceAdd);
            this.Controls.Add(this.comboBox_DeviceAdd);
            this.Controls.Add(this.lb_StaName);
            this.Controls.Add(this.comboBox_StaName);
            this.Controls.Add(this.lab_alert1);
            this.Controls.Add(this.lab_alert0);
            this.Controls.Add(this.rbtn_serial);
            this.Controls.Add(this.rbtn_net);
            this.Controls.Add(this.lab_method);
            this.Controls.Add(this.comboBox_SerialNum);
            this.Controls.Add(this.textBox_Node);
            this.Controls.Add(this.lab_LinkNode);
            this.Controls.Add(this.lab_SerialNum);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_Done);
            this.Name = "FormLinkage";
            this.Text = "联动设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLinkage_FormClosing);
            this.Load += new System.EventHandler(this.FormLinkage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Done;
        private System.Windows.Forms.ComboBox comboBox_SerialNum;
        private System.Windows.Forms.Label lab_SerialNum;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Label lab_method;
        private System.Windows.Forms.RadioButton rbtn_net;
        private System.Windows.Forms.RadioButton rbtn_serial;
        private System.Windows.Forms.Label lab_alert0;
        private System.Windows.Forms.Label lab_alert1;
        private System.Windows.Forms.Label lab_LinkNode;
        private System.Windows.Forms.TextBox textBox_Node;
        private System.Windows.Forms.Label lb_thisip;
        private System.Windows.Forms.Label lb_ip;
        private System.Windows.Forms.Label lb_DeviceAdd;
        private System.Windows.Forms.ComboBox comboBox_DeviceAdd;
        private System.Windows.Forms.Label lb_StaName;
        private System.Windows.Forms.ComboBox comboBox_StaName;
        private System.Windows.Forms.ComboBox comboBox_Position;
        private System.Windows.Forms.Label label4;
    }
}