namespace DigitalFenceMonitor
{
    partial class AlertSearch
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.but_clear = new System.Windows.Forms.Button();
            this.btn_output = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(1001, 330);
            this.dataGridView.TabIndex = 22;
            // 
            // but_clear
            // 
            this.but_clear.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.but_clear.Enabled = false;
            this.but_clear.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_clear.Location = new System.Drawing.Point(104, 353);
            this.but_clear.Margin = new System.Windows.Forms.Padding(2);
            this.but_clear.Name = "but_clear";
            this.but_clear.Padding = new System.Windows.Forms.Padding(1);
            this.but_clear.Size = new System.Drawing.Size(85, 45);
            this.but_clear.TabIndex = 23;
            this.but_clear.Text = "清空";
            this.but_clear.UseVisualStyleBackColor = false;
            this.but_clear.Click += new System.EventHandler(this.but_clear_Click);
            // 
            // btn_output
            // 
            this.btn_output.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btn_output.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_output.Location = new System.Drawing.Point(222, 353);
            this.btn_output.Margin = new System.Windows.Forms.Padding(2);
            this.btn_output.Name = "btn_output";
            this.btn_output.Padding = new System.Windows.Forms.Padding(1);
            this.btn_output.Size = new System.Drawing.Size(85, 45);
            this.btn_output.TabIndex = 24;
            this.btn_output.Text = "导出";
            this.btn_output.UseVisualStyleBackColor = false;
            this.btn_output.Click += new System.EventHandler(this.btn_output_Click);
            // 
            // AlertSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 409);
            this.Controls.Add(this.btn_output);
            this.Controls.Add(this.but_clear);
            this.Controls.Add(this.dataGridView);
            this.Name = "AlertSearch";
            this.Text = "报警查询";
            this.Load += new System.EventHandler(this.AlertSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button but_clear;
        private System.Windows.Forms.Button btn_output;
    }
}