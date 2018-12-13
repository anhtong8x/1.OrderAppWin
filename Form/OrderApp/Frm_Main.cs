using OrderApp.Extention;
using OrderApp.Functions;
using OrderApp.Systems;
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

namespace OrderApp
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region "variable"

        private UserInfoModel _userInfoModel;
        public void GetUserLogin(UserInfoModel userInfoModel) { _userInfoModel = userInfoModel; }// delegate in FrmLogin
        #endregion

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Frm_Login _frmLogin = new Frm_Login();                                
                _frmLogin._getUserLogin = new Frm_Login.GetUserLogin(GetUserLogin); // goi delegate traong form login

                if (_frmLogin.ShowDialog(this) == DialogResult.OK)
                {                    
                    this.Show();
                    toolStripStatusLabel1.Text = string.Format(SystemMessage.StatusInfo, _userInfoModel.DisplayName);

					// goi form ban hang
					báoCáoToolStripMenuItem_Click(sender, e);

				}
				else {
                    SystemHelp.ClosedAllChild(this);
                    Application.Exit();
                }
                
            }
            catch (Exception ex)
            {
                Console.Write(ex + "");
            }
        }
		
		private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!SystemHelp.CheckExitForm("Frm_Sales", this))
			{
				Frm_Sales frm = new Frm_Sales();
				frm._UserInfoModel = _userInfoModel;				
				SystemHelp.ShowChildForm(frm, this);
			}
			else
			{
				SystemHelp.ActiveChildForm("Frm_Sales", this);
			}
		}

		/*
		         private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!SystemHelp.CheckExitForm("Frm_Pay", this))
            {
                Frm_All_Table frm = new Frm_All_Table();
                //frm.Employee = _employee;
                SystemHelp.ShowChildForm(frm, this);
            }
            else
            {
                SystemHelp.ActiveChildForm("Frm_All_Table", this);
            }
        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!SystemHelp.CheckExitForm("Frm_Sales", this))
            {
                Frm_Sales frm = new Frm_Sales();
                //frm.Employee = _employee;
                SystemHelp.ShowChildForm(frm, this);
            }
            else
            {
                SystemHelp.ActiveChildForm("Frm_Sales", this);
            }
        }
		 */

	}
}
