namespace OrderApp.Functions
{
    partial class Frm_Pay_Detail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtGrid = new System.Windows.Forms.DataGridView();
            this.Col_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_id_bill_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_id_waiter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_name_waiter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_id_dish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_name_dish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_dish_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_quanity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTinhTien = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.txtTraKhach = new System.Windows.Forms.TextBox();
            this.txtKhachTra = new System.Windows.Forms.TextBox();
            this.txtKM = new System.Windows.Forms.TextBox();
            this.txtTongHD = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_Id_Bill_1 = new System.Windows.Forms.Label();
            this.lblSumMoney = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtGrid);
            this.groupBox2.Location = new System.Drawing.Point(12, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(682, 383);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết hóa đơn";
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
            this.Col_TT,
            this.Col_id,
            this.Col_id_bill_1,
            this.Col_id_waiter,
            this.Col_name_waiter,
            this.Col_id_dish,
            this.Col_name_dish,
            this.Col_dish_value,
            this.Col_quanity,
            this.Col_Money});
            this.dtGrid.Location = new System.Drawing.Point(6, 19);
            this.dtGrid.Name = "dtGrid";
            this.dtGrid.ReadOnly = true;
            this.dtGrid.Size = new System.Drawing.Size(670, 358);
            this.dtGrid.TabIndex = 0;
            // 
            // Col_TT
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Col_TT.DefaultCellStyle = dataGridViewCellStyle2;
            this.Col_TT.HeaderText = "TT";
            this.Col_TT.Name = "Col_TT";
            this.Col_TT.ReadOnly = true;
            // 
            // Col_id
            // 
            this.Col_id.HeaderText = "id_bill_2";
            this.Col_id.Name = "Col_id";
            this.Col_id.ReadOnly = true;
            this.Col_id.Visible = false;
            // 
            // Col_id_bill_1
            // 
            this.Col_id_bill_1.HeaderText = "id_bill_1";
            this.Col_id_bill_1.Name = "Col_id_bill_1";
            this.Col_id_bill_1.ReadOnly = true;
            this.Col_id_bill_1.Visible = false;
            // 
            // Col_id_waiter
            // 
            this.Col_id_waiter.HeaderText = "id_waiter";
            this.Col_id_waiter.Name = "Col_id_waiter";
            this.Col_id_waiter.ReadOnly = true;
            this.Col_id_waiter.Visible = false;
            // 
            // Col_name_waiter
            // 
            this.Col_name_waiter.HeaderText = "Phục vụ";
            this.Col_name_waiter.Name = "Col_name_waiter";
            this.Col_name_waiter.ReadOnly = true;
            // 
            // Col_id_dish
            // 
            this.Col_id_dish.HeaderText = "id_dish";
            this.Col_id_dish.Name = "Col_id_dish";
            this.Col_id_dish.ReadOnly = true;
            this.Col_id_dish.Visible = false;
            // 
            // Col_name_dish
            // 
            this.Col_name_dish.HeaderText = "Tên món";
            this.Col_name_dish.Name = "Col_name_dish";
            this.Col_name_dish.ReadOnly = true;
            // 
            // Col_dish_value
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Col_dish_value.DefaultCellStyle = dataGridViewCellStyle3;
            this.Col_dish_value.HeaderText = "Đơn giá";
            this.Col_dish_value.Name = "Col_dish_value";
            this.Col_dish_value.ReadOnly = true;
            // 
            // Col_quanity
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Col_quanity.DefaultCellStyle = dataGridViewCellStyle4;
            this.Col_quanity.HeaderText = "Số lượng";
            this.Col_quanity.Name = "Col_quanity";
            this.Col_quanity.ReadOnly = true;
            // 
            // Col_Money
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Col_Money.DefaultCellStyle = dataGridViewCellStyle5;
            this.Col_Money.HeaderText = "Thành tiền";
            this.Col_Money.Name = "Col_Money";
            this.Col_Money.ReadOnly = true;
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.Location = new System.Drawing.Point(250, 160);
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.Size = new System.Drawing.Size(75, 23);
            this.btnTinhTien.TabIndex = 2;
            this.btnTinhTien.Text = "Tính tiền";
            this.btnTinhTien.UseVisualStyleBackColor = true;
            this.btnTinhTien.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnLuu);
            this.groupBox3.Controls.Add(this.txtTraKhach);
            this.groupBox3.Controls.Add(this.txtKhachTra);
            this.groupBox3.Controls.Add(this.txtKM);
            this.groupBox3.Controls.Add(this.txtTongHD);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnTinhTien);
            this.groupBox3.Location = new System.Drawing.Point(700, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(338, 201);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thanh toán";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(169, 160);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtTraKhach
            // 
            this.txtTraKhach.Enabled = false;
            this.txtTraKhach.Location = new System.Drawing.Point(141, 122);
            this.txtTraKhach.Name = "txtTraKhach";
            this.txtTraKhach.Size = new System.Drawing.Size(184, 20);
            this.txtTraKhach.TabIndex = 4;
            // 
            // txtKhachTra
            // 
            this.txtKhachTra.Location = new System.Drawing.Point(141, 94);
            this.txtKhachTra.Name = "txtKhachTra";
            this.txtKhachTra.Size = new System.Drawing.Size(184, 20);
            this.txtKhachTra.TabIndex = 4;
            // 
            // txtKM
            // 
            this.txtKM.Location = new System.Drawing.Point(141, 63);
            this.txtKM.Name = "txtKM";
            this.txtKM.Size = new System.Drawing.Size(184, 20);
            this.txtKM.TabIndex = 4;
            // 
            // txtTongHD
            // 
            this.txtTongHD.Enabled = false;
            this.txtTongHD.Location = new System.Drawing.Point(141, 33);
            this.txtTongHD.Name = "txtTongHD";
            this.txtTongHD.Size = new System.Drawing.Size(184, 20);
            this.txtTongHD.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Tiền trả lại khách";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tiền khách trả";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Khuyễn mại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tổng tiền  hóa đơn";
            // 
            // lbl_Id_Bill_1
            // 
            this.lbl_Id_Bill_1.AutoSize = true;
            this.lbl_Id_Bill_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Id_Bill_1.Location = new System.Drawing.Point(151, 12);
            this.lbl_Id_Bill_1.Name = "lbl_Id_Bill_1";
            this.lbl_Id_Bill_1.Size = new System.Drawing.Size(228, 25);
            this.lbl_Id_Bill_1.TabIndex = 4;
            this.lbl_Id_Bill_1.Text = "Hóa đơn B1_05 bàn số 1";
            // 
            // lblSumMoney
            // 
            this.lblSumMoney.AutoSize = true;
            this.lblSumMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumMoney.Location = new System.Drawing.Point(13, 431);
            this.lblSumMoney.Name = "lblSumMoney";
            this.lblSumMoney.Size = new System.Drawing.Size(239, 25);
            this.lblSumMoney.TabIndex = 4;
            this.lblSumMoney.Text = "Tổng tiền: 5.000.000 VNĐ";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(701, 260);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(54, 16);
            this.lblMsg.TabIndex = 17;
            this.lblMsg.Text = "lblMsg";
            // 
            // Frm_Pay_Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 471);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblSumMoney);
            this.Controls.Add(this.lbl_Id_Bill_1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Pay_Detail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin hóa đơn";
            this.Load += new System.EventHandler(this.Frm_Pay_Detail_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTinhTien;
        private System.Windows.Forms.DataGridView dtGrid;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTongHD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_Id_Bill_1;
        private System.Windows.Forms.Label lblSumMoney;
        private System.Windows.Forms.TextBox txtTraKhach;
        private System.Windows.Forms.TextBox txtKhachTra;
        private System.Windows.Forms.TextBox txtKM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_id_bill_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_id_waiter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_name_waiter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_id_dish;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_name_dish;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_dish_value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_quanity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Money;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label lblMsg;
    }
}