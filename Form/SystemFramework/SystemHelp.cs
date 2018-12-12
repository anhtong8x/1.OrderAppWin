using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemFramework
{
    public class SystemHelp
    {
        private static string EncryptionKey = "TollStation";
        public static string Encrypt(string clearText)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public static bool CheckExitForm(string _frmName, Form _frmMain)
        {
            // Design phai doi ten form khac text form
            bool check = false;
            foreach (Form frm in _frmMain.MdiChildren)
            {
                if (frm.Name == _frmName)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        public static void ActiveChildForm(string _frmName, Form _frmMain)
        {
            foreach (Form frm in _frmMain.MdiChildren)
            {
                if (frm.Name == _frmName)
                {
                    frm.Activate();
                    break;
                }
            }
        }
        public static void ShowChildForm(Form _frm, Form _frmMain)
        {
            _frm.MdiParent = _frmMain;
            _frm.Show();
        }
        public static void ClosedAllChild(Form _frmMain)
        {
            foreach (Form f in _frmMain.MdiChildren)
            {
                f.Close();
            }
        }

    }
}
