namespace OrderApp.Functions
{
    partial class Frm_All_Table
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtGrid = new System.Windows.Forms.DataGridView();
            this.Col_Stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_idTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_name_table = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_id_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_status_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_id_bill_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(299, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Bàn đang phục vụ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtGrid);
            this.groupBox1.Location = new System.Drawing.Point(12, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 346);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin bàn đang có khách";
            // 
            // dtGrid
            // 
            this.dtGrid.AllowUserToAddRows = false;
            this.dtGrid.AllowUserToDeleteRows = false;
            this.dtGrid.AllowUserToResizeRows = false;
            this.dtGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_Stt,
            this.Col_idTable,
            this.Col_name_table,
            this.Col_id_status,
            this.Col_status_name,
            this.Col_id_bill_1});
            this.dtGrid.Location = new System.Drawing.Point(6, 19);
            this.dtGrid.Name = "dtGrid";
            this.dtGrid.Size = new System.Drawing.Size(764, 321);
            this.dtGrid.TabIndex = 0;
            this.dtGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrid_CellDoubleClick);
            // 
            // Col_Stt
            // 
            this.Col_Stt.HeaderText = "TT";
            this.Col_Stt.Name = "Col_Stt";
            this.Col_Stt.ReadOnly = true;
            // 
            // Col_idTable
            // 
            this.Col_idTable.HeaderText = "Col_idTable";
            this.Col_idTable.Name = "Col_idTable";
            this.Col_idTable.ReadOnly = true;
            this.Col_idTable.Visible = false;
            // 
            // Col_name_table
            // 
            this.Col_name_table.HeaderText = "Tên bàn phục vụ";
            this.Col_name_table.Name = "Col_name_table";
            // 
            // Col_id_status
            // 
            this.Col_id_status.HeaderText = "id_status";
            this.Col_id_status.Name = "Col_id_status";
            this.Col_id_status.Visible = false;
            // 
            // Col_status_name
            // 
            this.Col_status_name.HeaderText = "Trạng thái bàn";
            this.Col_status_name.Name = "Col_status_name";
            // 
            // Col_id_bill_1
            // 
            this.Col_id_bill_1.HeaderText = "Hóa đơn số";
            this.Col_id_bill_1.Name = "Col_id_bill_1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMsg);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(18, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(764, 58);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm bàn";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(88, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(311, 21);
            this.comboBox1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Chọn bàn";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(421, 28);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(54, 16);
            this.lblMsg.TabIndex = 16;
            this.lblMsg.Text = "lblMsg";
            // 
            // Frm_All_Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 491);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_All_Table";
            this.Text = "Các bàn đang phục vụ";
            this.Load += new System.EventHandler(this.Frm_All_Table_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_idTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_name_table;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_id_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_status_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_id_bill_1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMsg;
    }
}