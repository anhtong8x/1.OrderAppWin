namespace TN.StudentBus.Office
{
    partial class EditStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditStudent));
            this._Class = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this._School = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this._Phone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._Address = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._StudentName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this._Sex = new System.Windows.Forms.ComboBox();
            this._Status = new System.Windows.Forms.CheckBox();
            this._Birthday = new System.Windows.Forms.DateTimePicker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEditF2 = new System.Windows.Forms.LinkLabel();
            this._InfoF2 = new System.Windows.Forms.Label();
            this.btnEditF1 = new System.Windows.Forms.LinkLabel();
            this.label13 = new System.Windows.Forms.Label();
            this._InfoF1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelExe = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Code = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Class
            // 
            this._Class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Class.FormattingEnabled = true;
            this._Class.Location = new System.Drawing.Point(113, 79);
            this._Class.Name = "_Class";
            this._Class.Size = new System.Drawing.Size(192, 21);
            this._Class.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Chọn lớp:";
            // 
            // _School
            // 
            this._School.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._School.FormattingEnabled = true;
            this._School.Location = new System.Drawing.Point(113, 53);
            this._School.Name = "_School";
            this._School.Size = new System.Drawing.Size(192, 21);
            this._School.TabIndex = 13;
            this._School.SelectedIndexChanged += new System.EventHandler(this._School_SelectedIndexChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Chọn trường:";
            // 
            // _Phone
            // 
            this._Phone.Location = new System.Drawing.Point(113, 185);
            this._Phone.Name = "_Phone";
            this._Phone.Size = new System.Drawing.Size(192, 20);
            this._Phone.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Số điện thoại:";
            // 
            // _Address
            // 
            this._Address.Location = new System.Drawing.Point(113, 159);
            this._Address.Name = "_Address";
            this._Address.Size = new System.Drawing.Size(192, 20);
            this._Address.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Địa chỉ:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(11, 12);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(212, 22);
            this.lblType.TabIndex = 7;
            this.lblType.Text = "THÊM MỚI HỌC SINH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Giới tính:";
            // 
            // btnBack
            // 
            this.btnBack.Image = global::TN.StudentBus.Office.Properties.Resources.undo;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.Location = new System.Drawing.Point(60, 15);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(76, 26);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Thoát";
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày sinh:";
            // 
            // _StudentName
            // 
            this._StudentName.Location = new System.Drawing.Point(113, 25);
            this._StudentName.Name = "_StudentName";
            this._StudentName.Size = new System.Drawing.Size(120, 20);
            this._StudentName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ và tên:";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::TN.StudentBus.Office.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(140, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 26);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Lưu thay đổi";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_ClickAsync);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this._Sex);
            this.groupBox1.Controls.Add(this._Status);
            this.groupBox1.Controls.Add(this._Birthday);
            this.groupBox1.Controls.Add(this._Class);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this._School);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this._Phone);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this._Address);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._StudentName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 247);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(86, 82);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 13);
            this.label15.TabIndex = 40;
            this.label15.Text = "(*)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(86, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "(*)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(86, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "(*)";
            // 
            // _Sex
            // 
            this._Sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Sex.FormattingEnabled = true;
            this._Sex.Location = new System.Drawing.Point(113, 105);
            this._Sex.Name = "_Sex";
            this._Sex.Size = new System.Drawing.Size(192, 21);
            this._Sex.TabIndex = 18;
            // 
            // _Status
            // 
            this._Status.AutoSize = true;
            this._Status.Location = new System.Drawing.Point(113, 214);
            this._Status.Name = "_Status";
            this._Status.Size = new System.Drawing.Size(120, 17);
            this._Status.TabIndex = 17;
            this._Status.Text = "Sử dụng dữ liệu này";
            this._Status.UseVisualStyleBackColor = true;
            // 
            // _Birthday
            // 
            this._Birthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._Birthday.Location = new System.Drawing.Point(113, 133);
            this._Birthday.MaxDate = new System.DateTime(2198, 12, 31, 0, 0, 0, 0);
            this._Birthday.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this._Birthday.Name = "_Birthday";
            this._Birthday.Size = new System.Drawing.Size(192, 20);
            this._Birthday.TabIndex = 16;
            this._Birthday.Value = new System.DateTime(2018, 3, 13, 0, 0, 0, 0);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FloralWhite;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 303);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(651, 22);
            this.statusStrip1.TabIndex = 24;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(16, 17);
            this.lblStatus.Text = "...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Azure;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(194, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // btnEditF2
            // 
            this.btnEditF2.AutoSize = true;
            this.btnEditF2.Location = new System.Drawing.Point(120, 51);
            this.btnEditF2.Name = "btnEditF2";
            this.btnEditF2.Size = new System.Drawing.Size(54, 13);
            this.btnEditF2.TabIndex = 38;
            this.btnEditF2.TabStop = true;
            this.btnEditF2.Text = "Chỉnh sửa";
            this.btnEditF2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnEditF2_LinkClicked);
            // 
            // _InfoF2
            // 
            this._InfoF2.AutoSize = true;
            this._InfoF2.Location = new System.Drawing.Point(64, 51);
            this._InfoF2.Name = "_InfoF2";
            this._InfoF2.Size = new System.Drawing.Size(59, 13);
            this._InfoF2.TabIndex = 36;
            this._InfoF2.Text = "Chưa nhập";
            // 
            // btnEditF1
            // 
            this.btnEditF1.AutoSize = true;
            this.btnEditF1.Location = new System.Drawing.Point(121, 26);
            this.btnEditF1.Name = "btnEditF1";
            this.btnEditF1.Size = new System.Drawing.Size(54, 13);
            this.btnEditF1.TabIndex = 35;
            this.btnEditF1.TabStop = true;
            this.btnEditF1.Text = "Chỉnh sửa";
            this.btnEditF1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnEditF1_LinkClicked);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "Vân tay 2:";
            // 
            // _InfoF1
            // 
            this._InfoF1.AutoSize = true;
            this._InfoF1.Location = new System.Drawing.Point(65, 26);
            this._InfoF1.Name = "_InfoF1";
            this._InfoF1.Size = new System.Drawing.Size(59, 13);
            this._InfoF1.TabIndex = 33;
            this._InfoF1.Text = "Chưa nhập";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Vân tay 1:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.labelExe);
            this.groupBox3.Controls.Add(this.btnEditF1);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.btnEditF2);
            this.groupBox3.Controls.Add(this._InfoF1);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this._InfoF2);
            this.groupBox3.Location = new System.Drawing.Point(339, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(299, 188);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nhập vân tay";
            // 
            // labelExe
            // 
            this.labelExe.ForeColor = System.Drawing.Color.Red;
            this.labelExe.Location = new System.Drawing.Point(9, 82);
            this.labelExe.Name = "labelExe";
            this.labelExe.Size = new System.Drawing.Size(163, 30);
            this.labelExe.TabIndex = 39;
            this.labelExe.Text = "Lưu thông tin học sinh trước khi quét vân tay";
            this.labelExe.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Location = new System.Drawing.Point(339, 237);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 55);
            this.panel1.TabIndex = 40;
            // 
            // _Code
            // 
            this._Code.Location = new System.Drawing.Point(251, 70);
            this._Code.Name = "_Code";
            this._Code.ReadOnly = true;
            this._Code.Size = new System.Drawing.Size(66, 20);
            this._Code.TabIndex = 41;
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.DarkGreen;
            this.label11.Location = new System.Drawing.Point(9, 154);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(277, 30);
            this.label11.TabIndex = 41;
            this.label11.Text = "Nếu quét vân tay lỗi hay chất lượng thấp hay đã tồn tại, vui lòng click vào thêm " +
    "hoặc chỉnh sửa ở trên.";
            this.label11.Visible = false;
            // 
            // EditStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 325);
            this.Controls.Add(this._Code);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditStudent_FormClosing);
            this.Load += new System.EventHandler(this.EditStudent_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox _Class;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox _School;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _Phone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _Address;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _StudentName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker _Birthday;
        private System.Windows.Forms.CheckBox _Status;
        private System.Windows.Forms.ComboBox _Sex;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel btnEditF2;
        private System.Windows.Forms.Label _InfoF2;
        private System.Windows.Forms.LinkLabel btnEditF1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label _InfoF1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelExe;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox _Code;
        private System.Windows.Forms.Label label11;
    }
}