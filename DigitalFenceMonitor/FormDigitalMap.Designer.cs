namespace DigitalFenceMonitor
{
    partial class FormDigitalMap
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
            this.btn_Done = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.SelectMap = new System.Windows.Forms.TabPage();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.btn_Brows = new System.Windows.Forms.Button();
            this.textBox_MapPath = new System.Windows.Forms.TextBox();
            this.lab_MapPath = new System.Windows.Forms.Label();
            this.SetDenfenArea = new System.Windows.Forms.TabPage();
            this.btn_Set = new System.Windows.Forms.Button();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.comboBox_Position = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_AreaNum = new System.Windows.Forms.ComboBox();
            this.comboBox_StaName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.SelectMap.SuspendLayout();
            this.SetDenfenArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Done
            // 
            this.btn_Done.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btn_Done.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Done.Location = new System.Drawing.Point(310, 219);
            this.btn_Done.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Done.Name = "btn_Done";
            this.btn_Done.Padding = new System.Windows.Forms.Padding(1);
            this.btn_Done.Size = new System.Drawing.Size(85, 26);
            this.btn_Done.TabIndex = 4;
            this.btn_Done.Text = "完成";
            this.btn_Done.UseVisualStyleBackColor = false;
            this.btn_Done.Click += new System.EventHandler(this.btn_Done_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.SelectMap);
            this.tabControl.Controls.Add(this.SetDenfenArea);
            this.tabControl.Location = new System.Drawing.Point(14, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(402, 195);
            this.tabControl.TabIndex = 6;
            // 
            // SelectMap
            // 
            this.SelectMap.Controls.Add(this.btn_confirm);
            this.SelectMap.Controls.Add(this.btn_Brows);
            this.SelectMap.Controls.Add(this.textBox_MapPath);
            this.SelectMap.Controls.Add(this.lab_MapPath);
            this.SelectMap.Font = new System.Drawing.Font("黑体", 12F);
            this.SelectMap.Location = new System.Drawing.Point(4, 22);
            this.SelectMap.Name = "SelectMap";
            this.SelectMap.Padding = new System.Windows.Forms.Padding(3);
            this.SelectMap.Size = new System.Drawing.Size(394, 169);
            this.SelectMap.TabIndex = 0;
            this.SelectMap.Text = "选择地图";
            this.SelectMap.UseVisualStyleBackColor = true;
            // 
            // btn_confirm
            // 
            this.btn_confirm.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_confirm.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_confirm.Location = new System.Drawing.Point(292, 129);
            this.btn_confirm.Margin = new System.Windows.Forms.Padding(2);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Padding = new System.Windows.Forms.Padding(1);
            this.btn_confirm.Size = new System.Drawing.Size(65, 26);
            this.btn_confirm.TabIndex = 7;
            this.btn_confirm.Text = "确认";
            this.btn_confirm.UseVisualStyleBackColor = false;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // btn_Brows
            // 
            this.btn_Brows.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Brows.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Brows.Location = new System.Drawing.Point(292, 56);
            this.btn_Brows.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Brows.Name = "btn_Brows";
            this.btn_Brows.Padding = new System.Windows.Forms.Padding(1);
            this.btn_Brows.Size = new System.Drawing.Size(65, 26);
            this.btn_Brows.TabIndex = 6;
            this.btn_Brows.Text = "浏览";
            this.btn_Brows.UseVisualStyleBackColor = false;
            this.btn_Brows.Click += new System.EventHandler(this.btn_Brows_Click);
            // 
            // textBox_MapPath
            // 
            this.textBox_MapPath.AcceptsReturn = true;
            this.textBox_MapPath.Location = new System.Drawing.Point(50, 56);
            this.textBox_MapPath.Name = "textBox_MapPath";
            this.textBox_MapPath.Size = new System.Drawing.Size(237, 26);
            this.textBox_MapPath.TabIndex = 1;
            // 
            // lab_MapPath
            // 
            this.lab_MapPath.AutoSize = true;
            this.lab_MapPath.Location = new System.Drawing.Point(47, 24);
            this.lab_MapPath.Name = "lab_MapPath";
            this.lab_MapPath.Size = new System.Drawing.Size(104, 16);
            this.lab_MapPath.TabIndex = 0;
            this.lab_MapPath.Text = "电子地图路径";
            // 
            // SetDenfenArea
            // 
            this.SetDenfenArea.Controls.Add(this.btn_Set);
            this.SetDenfenArea.Controls.Add(this.checkBox);
            this.SetDenfenArea.Controls.Add(this.comboBox_Position);
            this.SetDenfenArea.Controls.Add(this.label4);
            this.SetDenfenArea.Controls.Add(this.comboBox_AreaNum);
            this.SetDenfenArea.Controls.Add(this.comboBox_StaName);
            this.SetDenfenArea.Controls.Add(this.label3);
            this.SetDenfenArea.Controls.Add(this.label2);
            this.SetDenfenArea.Controls.Add(this.label1);
            this.SetDenfenArea.Location = new System.Drawing.Point(4, 22);
            this.SetDenfenArea.Name = "SetDenfenArea";
            this.SetDenfenArea.Padding = new System.Windows.Forms.Padding(3);
            this.SetDenfenArea.Size = new System.Drawing.Size(394, 169);
            this.SetDenfenArea.TabIndex = 1;
            this.SetDenfenArea.Text = "图像关联设置";
            this.SetDenfenArea.UseVisualStyleBackColor = true;
            // 
            // btn_Set
            // 
            this.btn_Set.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Set.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Set.Location = new System.Drawing.Point(292, 129);
            this.btn_Set.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Set.Name = "btn_Set";
            this.btn_Set.Padding = new System.Windows.Forms.Padding(1);
            this.btn_Set.Size = new System.Drawing.Size(65, 26);
            this.btn_Set.TabIndex = 8;
            this.btn_Set.Text = "设置";
            this.btn_Set.UseVisualStyleBackColor = false;
            this.btn_Set.Click += new System.EventHandler(this.btn_Set_Click);
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(131, 130);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(96, 16);
            this.checkBox.TabIndex = 16;
            this.checkBox.Text = "是否显示图像";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // comboBox_Position
            // 
            this.comboBox_Position.FormattingEnabled = true;
            this.comboBox_Position.Location = new System.Drawing.Point(124, 82);
            this.comboBox_Position.Name = "comboBox_Position";
            this.comboBox_Position.Size = new System.Drawing.Size(139, 20);
            this.comboBox_Position.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 12F);
            this.label4.Location = new System.Drawing.Point(29, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "防区位置";
            // 
            // comboBox_AreaNum
            // 
            this.comboBox_AreaNum.FormattingEnabled = true;
            this.comboBox_AreaNum.Location = new System.Drawing.Point(124, 53);
            this.comboBox_AreaNum.Name = "comboBox_AreaNum";
            this.comboBox_AreaNum.Size = new System.Drawing.Size(139, 20);
            this.comboBox_AreaNum.TabIndex = 12;
            this.comboBox_AreaNum.TextChanged += new System.EventHandler(this.comboBox_AreaNum_TextChanged);
            // 
            // comboBox_StaName
            // 
            this.comboBox_StaName.FormattingEnabled = true;
            this.comboBox_StaName.Location = new System.Drawing.Point(124, 21);
            this.comboBox_StaName.Name = "comboBox_StaName";
            this.comboBox_StaName.Size = new System.Drawing.Size(173, 20);
            this.comboBox_StaName.TabIndex = 11;
            this.comboBox_StaName.TextChanged += new System.EventHandler(this.comboBox_StaName_TextChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("黑体", 12F);
            this.label3.Location = new System.Drawing.Point(29, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 36);
            this.label3.TabIndex = 2;
            this.label3.Text = "防区图像关联设置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 12F);
            this.label2.Location = new System.Drawing.Point(29, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "设备地址";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 12F);
            this.label1.Location = new System.Drawing.Point(29, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "基站名称";
            // 
            // FormDigitalMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 256);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btn_Done);
            this.Name = "FormDigitalMap";
            this.Text = "电子地图设置";
            this.Load += new System.EventHandler(this.FormDigitalMap_Load);
            this.tabControl.ResumeLayout(false);
            this.SelectMap.ResumeLayout(false);
            this.SelectMap.PerformLayout();
            this.SetDenfenArea.ResumeLayout(false);
            this.SetDenfenArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Done;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage SelectMap;
        private System.Windows.Forms.TabPage SetDenfenArea;
        private System.Windows.Forms.TextBox textBox_MapPath;
        private System.Windows.Forms.Label lab_MapPath;
        private System.Windows.Forms.Button btn_Brows;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_AreaNum;
        private System.Windows.Forms.ComboBox comboBox_StaName;
        private System.Windows.Forms.ComboBox comboBox_Position;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Button btn_Set;
    }
}