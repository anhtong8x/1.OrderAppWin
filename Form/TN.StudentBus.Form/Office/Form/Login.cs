using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TN.StudentBus.Office.Extention;

namespace TN.StudentBus.Office
{
    public partial class Login : Form
    {
        public string Token = "";
        public int Output = 0;
        public UserInfoModel User;
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            btnLogin.Enabled = true;
            btnLogin.Text = "Đăng nhập";
            //this._UserService = new UserService();
        }
        public void CloseApplication()
        {
            Application.Exit();
        }
        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (_Username.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tài khoản.", "Hệ thống");
                    _Username.Focus();
                    return;
                }
                if (_Password.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu.", "Hệ thống");
                    _Password.Focus();
                    return;
                }
                btnLogin.Enabled = false;
                btnLogin.Text = "Đang xử lý...";

                var dl = await DALContext.LoginAsync(_Username.Text.Trim(), _Password.Text.Trim());
                if(dl==null)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng, vui lòng thử lại.", "Hệ thống");
                    _Username.Focus();
                    return;
                }
                else if(dl.ErrorCode>0)
                {
                    MessageBox.Show("Lỗi kết nối với máy chủ trung tâm.", "Hệ thống");
                    return;
                }
                else
                {
                    btnLogin.Enabled = true;
                    btnLogin.Text = "Đăng nhập";

                    if (dl.Output == 1)
                    {

                        AppSettings.UpdateUserInfo(Newtonsoft.Json.JsonConvert.SerializeObject(dl.Data));
                        User = dl.Data;
                        Output = 1;
                        Close();
                        return;
                    }
                    else
                    {

                        MessageBox.Show(dl.Message, "Hệ thống");
                        _Username.Focus();
                        return;
                    }
                   
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseApplication();
        }

        private void LinkOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CloseApplication();
        }
    }
}
