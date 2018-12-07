namespace TN.StudentBus.Office
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this._Username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._Password = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.LinkChangePassword = new System.Windows.Forms.LinkLabel();
            this.LinkOut = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // _Username
            // 
            this._Username.Location = new System.Drawing.Point(16, 69);
            this._Username.Name = "_Username";
            this._Username.Size = new System.Drawing.Size(324, 20);
            this._Username.TabIndex = 0;
            this._Username.Text = "taikhoantruong2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐĂNG NHẬP HỆ THỐNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tài khoản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mật khẩu";
            // 
            // _Password
            // 
            this._Password.Location = new System.Drawing.Point(16, 116);
            this._Password.Name = "_Password";
            this._Password.PasswordChar = '*';
            this._Password.Size = new System.Drawing.Size(324, 20);
            this._Password.TabIndex = 1;
            this._Password.Text = "Matkhau@168168";
            // 
            // btnLogin
            // 
            this.btnLogin.Image = global::TN.StudentBus.Office.Properties.Resources.login;
            this.btnLogin.Location = new System.Drawing.Point(16, 151);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(324, 26);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "&Đăng nhập";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // LinkChangePassword
            // 
            this.LinkChangePassword.AutoSize = true;
            this.LinkChangePassword.Location = new System.Drawing.Point(15, 183);
            this.LinkChangePassword.Name = "LinkChangePassword";
            this.LinkChangePassword.Size = new System.Drawing.Size(86, 13);
            this.LinkChangePassword.TabIndex = 4;
            this.LinkChangePassword.TabStop = true;
            this.LinkChangePassword.Text = "Quên mật khẩu?";
            // 
            // LinkOut
            // 
            this.LinkOut.AutoSize = true;
            this.LinkOut.Location = new System.Drawing.Point(237, 183);
            this.LinkOut.Name = "LinkOut";
            this.LinkOut.Size = new System.Drawing.Size(103, 13);
            this.LinkOut.TabIndex = 5;
            this.LinkOut.TabStop = true;
            this.LinkOut.Text = "Thoát khỏi hệ thống";
            this.LinkOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkOut_LinkClicked);
            // 
            // Login
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 214);
            this.ControlBox = false;
            this.Controls.Add(this.LinkOut);
            this.Controls.Add(this.LinkChangePassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this._Password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._Username);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _Username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _Password;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel LinkChangePassword;
        private System.Windows.Forms.LinkLabel LinkOut;
    }
}