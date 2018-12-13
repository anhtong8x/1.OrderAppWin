using OrderApp.Extention;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemFramework;

namespace OrderApp.Systems
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }
                
        // Khai bao delegate
        public delegate void GetUserLogin(UserInfoModel userInfoModel);
        public GetUserLogin _getUserLogin;

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            txtUserName.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string uName = txtUserName.Text.Trim();
            string pWord = txtPassWord.Text.Trim();

            #region "CheckInput"
            if (uName == "")
            {
                txtUserName.Focus();
                lblMsg.Text = SystemMessage.WarningUsername;
                return;
            }

            if (pWord == "")
            {
                txtPassWord.Focus();
                lblMsg.Text = SystemMessage.WarningPassword;
                return;
            }
            #endregion

            #region "Login"
            try
            {
                var dl = await DALContext.LoginAsync(uName, pWord);
                if (dl == null)
                {
                    lblMsg.Text = SystemMessage.WarningErrorUsername;
                    return;
                }
                else if (dl.ErrorCode > 0) {
                    lblMsg.Text = SystemMessage.WarningConnection;
                    return;
                }
                else
                {
                    _getUserLogin(dl.Data);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                lblMsg.Text = SystemMessage.WarningConnection;
            }
            #endregion
        }
    }
}
