namespace TN.StudentBus.Office
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFullName = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUserManager = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSerting = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDisconect = new System.Windows.Forms.Button();
            this.PBar = new System.Windows.Forms.ProgressBar();
            this.btnKetNoiLai = new System.Windows.Forms.Button();
            this.LblInfo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnLichSu = new System.Windows.Forms.Button();
            this._Status = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this._Class = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this._School = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this._key = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gr = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchoolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassOfSchoolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.F2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Disable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblType = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnTrangTiep = new System.Windows.Forms.Button();
            this.BtnTrangTruoc = new System.Windows.Forms.Button();
            this.TxtSoTrang = new System.Windows.Forms.Label();
            this.SensorDriver = new AxZKFPEngXControl.AxZKFPEngX();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gr)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SensorDriver)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLogOut,
            this.menuFullName,
            this.menuHeThong});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1168, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuLogOut
            // 
            this.menuLogOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuLogOut.Name = "menuLogOut";
            this.menuLogOut.Size = new System.Drawing.Size(50, 20);
            this.menuLogOut.Text = "Thoát";
            this.menuLogOut.Click += new System.EventHandler(this.MenuLogOut_Click);
            // 
            // menuFullName
            // 
            this.menuFullName.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuFullName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuFullName.Name = "menuFullName";
            this.menuFullName.Size = new System.Drawing.Size(84, 20);
            this.menuFullName.Text = "Xin chào : ...";
            this.menuFullName.Click += new System.EventHandler(this.MenuFullName_Click);
            // 
            // menuHeThong
            // 
            this.menuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUserManager,
            this.menuSerting,
            this.BtnThoat});
            this.menuHeThong.Name = "menuHeThong";
            this.menuHeThong.Size = new System.Drawing.Size(69, 20);
            this.menuHeThong.Text = "Hệ thống";
            // 
            // menuUserManager
            // 
            this.menuUserManager.Image = global::TN.StudentBus.Office.Properties.Resources.user;
            this.menuUserManager.Name = "menuUserManager";
            this.menuUserManager.Size = new System.Drawing.Size(145, 22);
            this.menuUserManager.Text = "Đổi mật khẩu";
            this.menuUserManager.Click += new System.EventHandler(this.MenuUserManager_Click);
            // 
            // menuSerting
            // 
            this.menuSerting.Image = global::TN.StudentBus.Office.Properties.Resources.automatic;
            this.menuSerting.Name = "menuSerting";
            this.menuSerting.Size = new System.Drawing.Size(145, 22);
            this.menuSerting.Text = "Cấu hình";
            this.menuSerting.Click += new System.EventHandler(this.MenuSerting_Click);
            // 
            // BtnThoat
            // 
            this.BtnThoat.Image = global::TN.StudentBus.Office.Properties.Resources.undo;
            this.BtnThoat.Name = "BtnThoat";
            this.BtnThoat.Size = new System.Drawing.Size(145, 22);
            this.BtnThoat.Text = "Thoát";
            this.BtnThoat.Click += new System.EventHandler(this.BtnThoat_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(149, 2438);
            this.panel1.TabIndex = 33;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDisconect);
            this.groupBox2.Controls.Add(this.PBar);
            this.groupBox2.Controls.Add(this.btnKetNoiLai);
            this.groupBox2.Controls.Add(this.LblInfo);
            this.groupBox2.Location = new System.Drawing.Point(8, 99);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(131, 131);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thiết bị vân tay";
            // 
            // btnDisconect
            // 
            this.btnDisconect.Enabled = false;
            this.btnDisconect.Image = global::TN.StudentBus.Office.Properties.Resources.disconect;
            this.btnDisconect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDisconect.Location = new System.Drawing.Point(7, 94);
            this.btnDisconect.Margin = new System.Windows.Forms.Padding(2);
            this.btnDisconect.Name = "btnDisconect";
            this.btnDisconect.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnDisconect.Size = new System.Drawing.Size(118, 26);
            this.btnDisconect.TabIndex = 36;
            this.btnDisconect.Text = "Ngắt kết nối";
            this.btnDisconect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDisconect.UseVisualStyleBackColor = true;
            this.btnDisconect.Click += new System.EventHandler(this.Button1_Click);
            // 
            // PBar
            // 
            this.PBar.Location = new System.Drawing.Point(7, 42);
            this.PBar.Margin = new System.Windows.Forms.Padding(2);
            this.PBar.Name = "PBar";
            this.PBar.Size = new System.Drawing.Size(118, 21);
            this.PBar.TabIndex = 34;
            // 
            // btnKetNoiLai
            // 
            this.btnKetNoiLai.Image = global::TN.StudentBus.Office.Properties.Resources.connect;
            this.btnKetNoiLai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKetNoiLai.Location = new System.Drawing.Point(7, 66);
            this.btnKetNoiLai.Margin = new System.Windows.Forms.Padding(2);
            this.btnKetNoiLai.Name = "btnKetNoiLai";
            this.btnKetNoiLai.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnKetNoiLai.Size = new System.Drawing.Size(118, 26);
            this.btnKetNoiLai.TabIndex = 35;
            this.btnKetNoiLai.Text = "Kết nối thiết bị";
            this.btnKetNoiLai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKetNoiLai.UseVisualStyleBackColor = true;
            this.btnKetNoiLai.Click += new System.EventHandler(this.BtnKetNoiLai_Click);
            // 
            // LblInfo
            // 
            this.LblInfo.AutoSize = true;
            this.LblInfo.Location = new System.Drawing.Point(9, 21);
            this.LblInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(16, 13);
            this.LblInfo.TabIndex = 33;
            this.LblInfo.Text = "...";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCheck);
            this.groupBox1.Controls.Add(this.btnLichSu);
            this.groupBox1.Location = new System.Drawing.Point(8, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(133, 90);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quản lý";
            // 
            // btnCheck
            // 
            this.btnCheck.Image = global::TN.StudentBus.Office.Properties.Resources.finger;
            this.btnCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheck.Location = new System.Drawing.Point(7, 50);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCheck.Size = new System.Drawing.Size(118, 26);
            this.btnCheck.TabIndex = 33;
            this.btnCheck.Text = "Kiểm tra vân tay";
            this.btnCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.BtnCheck_Click_1);
            // 
            // btnLichSu
            // 
            this.btnLichSu.Image = global::TN.StudentBus.Office.Properties.Resources.machine;
            this.btnLichSu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLichSu.Location = new System.Drawing.Point(7, 20);
            this.btnLichSu.Margin = new System.Windows.Forms.Padding(2);
            this.btnLichSu.Name = "btnLichSu";
            this.btnLichSu.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnLichSu.Size = new System.Drawing.Size(118, 26);
            this.btnLichSu.TabIndex = 31;
            this.btnLichSu.Text = "Lịch sử đi xe";
            this.btnLichSu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLichSu.UseVisualStyleBackColor = true;
            this.btnLichSu.Click += new System.EventHandler(this.BtnLichSu_Click);
            // 
            // _Status
            // 
            this._Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Status.FormattingEnabled = true;
            this._Status.Location = new System.Drawing.Point(678, 20);
            this._Status.Name = "_Status";
            this._Status.Size = new System.Drawing.Size(87, 21);
            this._Status.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(617, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Trạng thái:";
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Image = global::TN.StudentBus.Office.Properties.Resources.add;
            this.btnAddStudent.Location = new System.Drawing.Point(881, 19);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(84, 23);
            this.btnAddStudent.TabIndex = 17;
            this.btnAddStudent.Text = "Thêm mới";
            this.btnAddStudent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddStudent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.BtnAddStudent_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::TN.StudentBus.Office.Properties.Resources.search;
            this.btnSearch.Location = new System.Drawing.Point(790, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 23);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // _Class
            // 
            this._Class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Class.FormattingEnabled = true;
            this._Class.Location = new System.Drawing.Point(525, 20);
            this._Class.Name = "_Class";
            this._Class.Size = new System.Drawing.Size(76, 21);
            this._Class.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(467, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Chọn lớp:";
            // 
            // _School
            // 
            this._School.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._School.FormattingEnabled = true;
            this._School.Location = new System.Drawing.Point(275, 20);
            this._School.Name = "_School";
            this._School.Size = new System.Drawing.Size(183, 21);
            this._School.TabIndex = 13;
            this._School.SelectedIndexChanged += new System.EventHandler(this._School_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Chọn trường:";
            // 
            // _key
            // 
            this._key.Location = new System.Drawing.Point(72, 20);
            this._key.Name = "_key";
            this._key.Size = new System.Drawing.Size(121, 20);
            this._key.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ khóa:";
            // 
            // gr
            // 
            this.gr.AllowUserToAddRows = false;
            this.gr.AllowUserToDeleteRows = false;
            this.gr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Code,
            this.StudentName,
            this.Birthday,
            this.Sex,
            this.Address,
            this.Phone,
            this.SchoolName,
            this.ClassOfSchoolName,
            this.F1,
            this.F2,
            this.Disable});
            this.gr.Location = new System.Drawing.Point(160, 126);
            this.gr.MultiSelect = false;
            this.gr.Name = "gr";
            this.gr.ReadOnly = true;
            this.gr.Size = new System.Drawing.Size(990, 433);
            this.gr.TabIndex = 36;
            this.gr.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gr_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 70;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Mã học sinh";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Width = 80;
            // 
            // StudentName
            // 
            this.StudentName.DataPropertyName = "FullName";
            this.StudentName.HeaderText = "Họ và tên";
            this.StudentName.Name = "StudentName";
            this.StudentName.ReadOnly = true;
            this.StudentName.Width = 180;
            // 
            // Birthday
            // 
            this.Birthday.DataPropertyName = "Birthday";
            this.Birthday.HeaderText = "Ngày sinh";
            this.Birthday.Name = "Birthday";
            this.Birthday.ReadOnly = true;
            // 
            // Sex
            // 
            this.Sex.DataPropertyName = "Sex";
            this.Sex.HeaderText = "Giới tính";
            this.Sex.Name = "Sex";
            this.Sex.ReadOnly = true;
            this.Sex.Width = 70;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Địa chỉ";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Visible = false;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.HeaderText = "Số điện thoại";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            this.Phone.Visible = false;
            // 
            // SchoolName
            // 
            this.SchoolName.DataPropertyName = "SchoolName";
            this.SchoolName.HeaderText = "Trường";
            this.SchoolName.Name = "SchoolName";
            this.SchoolName.ReadOnly = true;
            this.SchoolName.Width = 200;
            // 
            // ClassOfSchoolName
            // 
            this.ClassOfSchoolName.DataPropertyName = "ClassName";
            this.ClassOfSchoolName.HeaderText = "Lớp";
            this.ClassOfSchoolName.Name = "ClassOfSchoolName";
            this.ClassOfSchoolName.ReadOnly = true;
            this.ClassOfSchoolName.Width = 80;
            // 
            // F1
            // 
            this.F1.DataPropertyName = "StatusFinger1";
            this.F1.HeaderText = "Vân tay 1";
            this.F1.Name = "F1";
            this.F1.ReadOnly = true;
            this.F1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.F1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.F1.Width = 60;
            // 
            // F2
            // 
            this.F2.DataPropertyName = "StatusFinger2";
            this.F2.HeaderText = "Vân tay 2";
            this.F2.Name = "F2";
            this.F2.ReadOnly = true;
            this.F2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.F2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.F2.Width = 60;
            // 
            // Disable
            // 
            this.Disable.DataPropertyName = "StatusName";
            this.Disable.HeaderText = "Trạng thái";
            this.Disable.Name = "Disable";
            this.Disable.ReadOnly = true;
            this.Disable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Disable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Disable.Width = 80;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(159, 33);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(194, 22);
            this.lblType.TabIndex = 35;
            this.lblType.Text = "QUẢN LÝ HỌC SINH";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this._Status);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnAddStudent);
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Controls.Add(this._Class);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this._School);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this._key);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(160, 66);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(990, 52);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tìm kiếm theo";
            // 
            // BtnTrangTiep
            // 
            this.BtnTrangTiep.Location = new System.Drawing.Point(1075, 569);
            this.BtnTrangTiep.Name = "BtnTrangTiep";
            this.BtnTrangTiep.Size = new System.Drawing.Size(75, 23);
            this.BtnTrangTiep.TabIndex = 37;
            this.BtnTrangTiep.Text = "Trang tiếp";
            this.BtnTrangTiep.UseVisualStyleBackColor = true;
            this.BtnTrangTiep.Click += new System.EventHandler(this.BtnTrangTiep_Click);
            // 
            // BtnTrangTruoc
            // 
            this.BtnTrangTruoc.Location = new System.Drawing.Point(994, 569);
            this.BtnTrangTruoc.Name = "BtnTrangTruoc";
            this.BtnTrangTruoc.Size = new System.Drawing.Size(75, 23);
            this.BtnTrangTruoc.TabIndex = 38;
            this.BtnTrangTruoc.Text = "Trang trước";
            this.BtnTrangTruoc.UseVisualStyleBackColor = true;
            this.BtnTrangTruoc.Click += new System.EventHandler(this.BtnTrangTruoc_Click);
            // 
            // TxtSoTrang
            // 
            this.TxtSoTrang.AutoSize = true;
            this.TxtSoTrang.Location = new System.Drawing.Point(160, 574);
            this.TxtSoTrang.Name = "TxtSoTrang";
            this.TxtSoTrang.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtSoTrang.Size = new System.Drawing.Size(0, 13);
            this.TxtSoTrang.TabIndex = 39;
            // 
            // SensorDriver
            // 
            this.SensorDriver.Enabled = true;
            this.SensorDriver.Location = new System.Drawing.Point(1101, 36);
            this.SensorDriver.Name = "SensorDriver";
            this.SensorDriver.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SensorDriver.OcxState")));
            this.SensorDriver.Size = new System.Drawing.Size(24, 24);
            this.SensorDriver.TabIndex = 40;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1168, 635);
            this.Controls.Add(this.SensorDriver);
            this.Controls.Add(this.TxtSoTrang);
            this.Controls.Add(this.BtnTrangTruoc);
            this.Controls.Add(this.BtnTrangTiep);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gr);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý vân tay";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gr)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SensorDriver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuHeThong;
        private System.Windows.Forms.ToolStripMenuItem menuUserManager;
        private System.Windows.Forms.ToolStripMenuItem menuSerting;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem menuFullName;
        private System.Windows.Forms.ToolStripMenuItem menuLogOut;
        private System.Windows.Forms.Button btnLichSu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblInfo;
        private System.Windows.Forms.ProgressBar PBar;
        private System.Windows.Forms.Button btnKetNoiLai;
        private System.Windows.Forms.Button btnDisconect;
        private System.Windows.Forms.ToolStripMenuItem BtnThoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.ComboBox _Status;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox _Class;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox _School;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _key;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gr;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnTrangTiep;
        private System.Windows.Forms.Button BtnTrangTruoc;
        private System.Windows.Forms.Label TxtSoTrang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchoolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassOfSchoolName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn F1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn F2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Disable;
        private AxZKFPEngXControl.AxZKFPEngX SensorDriver;
    }
}