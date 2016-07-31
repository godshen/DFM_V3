namespace DigitalFenceMonitor
{
    partial class FormDefenAreaAdd
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
            this.lab_AreaNum = new System.Windows.Forms.Label();
            this.lab_StaName = new System.Windows.Forms.Label();
            this.lab_AreaStatus = new System.Windows.Forms.Label();
            this.lab_Position = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Done = new System.Windows.Forms.Button();
            this.comboBox_StaName = new System.Windows.Forms.ComboBox();
            this.comboBox_AreaStatus = new System.Windows.Forms.ComboBox();
            this.textBox_AreaNum = new System.Windows.Forms.TextBox();
            this.textBox_Position = new System.Windows.Forms.TextBox();
            this.lb_type = new System.Windows.Forms.Label();
            this.comboBox_type = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lab_AreaNum
            // 
            this.lab_AreaNum.AutoSize = true;
            this.lab_AreaNum.Font = new System.Drawing.Font("黑体", 12F);
            this.lab_AreaNum.Location = new System.Drawing.Point(48, 70);
            this.lab_AreaNum.Name = "lab_AreaNum";
            this.lab_AreaNum.Size = new System.Drawing.Size(72, 16);
            this.lab_AreaNum.TabIndex = 3;
            this.lab_AreaNum.Text = "设备地址";
            // 
            // lab_StaName
            // 
            this.lab_StaName.AutoSize = true;
            this.lab_StaName.Font = new System.Drawing.Font("黑体", 12F);
            this.lab_StaName.Location = new System.Drawing.Point(48, 35);
            this.lab_StaName.Name = "lab_StaName";
            this.lab_StaName.Size = new System.Drawing.Size(72, 16);
            this.lab_StaName.TabIndex = 2;
            this.lab_StaName.Text = "基站名称";
            // 
            // lab_AreaStatus
            // 
            this.lab_AreaStatus.AutoSize = true;
            this.lab_AreaStatus.Font = new System.Drawing.Font("黑体", 12F);
            this.lab_AreaStatus.Location = new System.Drawing.Point(48, 133);
            this.lab_AreaStatus.Name = "lab_AreaStatus";
            this.lab_AreaStatus.Size = new System.Drawing.Size(72, 16);
            this.lab_AreaStatus.TabIndex = 5;
            this.lab_AreaStatus.Text = "防区状态";
            // 
            // lab_Position
            // 
            this.lab_Position.AutoSize = true;
            this.lab_Position.Font = new System.Drawing.Font("黑体", 12F);
            this.lab_Position.Location = new System.Drawing.Point(48, 163);
            this.lab_Position.Name = "lab_Position";
            this.lab_Position.Size = new System.Drawing.Size(72, 16);
            this.lab_Position.TabIndex = 6;
            this.lab_Position.Text = "防区位置";
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btn_Exit.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Exit.Location = new System.Drawing.Point(204, 204);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Padding = new System.Windows.Forms.Padding(1);
            this.btn_Exit.Size = new System.Drawing.Size(85, 45);
            this.btn_Exit.TabIndex = 8;
            this.btn_Exit.Text = "退出";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Done
            // 
            this.btn_Done.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btn_Done.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Done.Location = new System.Drawing.Point(65, 204);
            this.btn_Done.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Done.Name = "btn_Done";
            this.btn_Done.Padding = new System.Windows.Forms.Padding(1);
            this.btn_Done.Size = new System.Drawing.Size(85, 45);
            this.btn_Done.TabIndex = 7;
            this.btn_Done.Text = "添加";
            this.btn_Done.UseVisualStyleBackColor = false;
            this.btn_Done.Click += new System.EventHandler(this.btn_Done_Click);
            // 
            // comboBox_StaName
            // 
            this.comboBox_StaName.FormattingEnabled = true;
            this.comboBox_StaName.Location = new System.Drawing.Point(137, 36);
            this.comboBox_StaName.Name = "comboBox_StaName";
            this.comboBox_StaName.Size = new System.Drawing.Size(135, 20);
            this.comboBox_StaName.TabIndex = 9;
            // 
            // comboBox_AreaStatus
            // 
            this.comboBox_AreaStatus.FormattingEnabled = true;
            this.comboBox_AreaStatus.Location = new System.Drawing.Point(137, 134);
            this.comboBox_AreaStatus.Name = "comboBox_AreaStatus";
            this.comboBox_AreaStatus.Size = new System.Drawing.Size(135, 20);
            this.comboBox_AreaStatus.TabIndex = 10;
            // 
            // textBox_AreaNum
            // 
            this.textBox_AreaNum.AcceptsTab = true;
            this.textBox_AreaNum.Location = new System.Drawing.Point(137, 71);
            this.textBox_AreaNum.Name = "textBox_AreaNum";
            this.textBox_AreaNum.Size = new System.Drawing.Size(135, 21);
            this.textBox_AreaNum.TabIndex = 12;
            // 
            // textBox_Position
            // 
            this.textBox_Position.AcceptsTab = true;
            this.textBox_Position.Location = new System.Drawing.Point(137, 164);
            this.textBox_Position.Name = "textBox_Position";
            this.textBox_Position.Size = new System.Drawing.Size(135, 21);
            this.textBox_Position.TabIndex = 13;
            // 
            // lb_type
            // 
            this.lb_type.AutoSize = true;
            this.lb_type.Font = new System.Drawing.Font("黑体", 12F);
            this.lb_type.Location = new System.Drawing.Point(48, 101);
            this.lb_type.Name = "lb_type";
            this.lb_type.Size = new System.Drawing.Size(72, 16);
            this.lb_type.TabIndex = 15;
            this.lb_type.Text = "设备类型";
            // 
            // comboBox_type
            // 
            this.comboBox_type.FormattingEnabled = true;
            this.comboBox_type.Location = new System.Drawing.Point(137, 102);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new System.Drawing.Size(135, 20);
            this.comboBox_type.TabIndex = 16;
            this.comboBox_type.TextChanged += new System.EventHandler(this.comboBox_type_TextChanged);
            // 
            // FormDefenAreaAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 257);
            this.Controls.Add(this.comboBox_type);
            this.Controls.Add(this.lb_type);
            this.Controls.Add(this.textBox_Position);
            this.Controls.Add(this.textBox_AreaNum);
            this.Controls.Add(this.comboBox_AreaStatus);
            this.Controls.Add(this.comboBox_StaName);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Done);
            this.Controls.Add(this.lab_Position);
            this.Controls.Add(this.lab_AreaStatus);
            this.Controls.Add(this.lab_AreaNum);
            this.Controls.Add(this.lab_StaName);
            this.Name = "FormDefenAreaAdd";
            this.Text = "添加新防区";
            this.Load += new System.EventHandler(this.FormDefenAreaAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_AreaNum;
        private System.Windows.Forms.Label lab_StaName;
        private System.Windows.Forms.Label lab_AreaStatus;
        private System.Windows.Forms.Label lab_Position;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Done;
        private System.Windows.Forms.ComboBox comboBox_StaName;
        private System.Windows.Forms.ComboBox comboBox_AreaStatus;
        private System.Windows.Forms.TextBox textBox_AreaNum;
        private System.Windows.Forms.TextBox textBox_Position;
        private System.Windows.Forms.Label lb_type;
        private System.Windows.Forms.ComboBox comboBox_type;
    }
}