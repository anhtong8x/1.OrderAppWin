using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TN.StudentBus.Office.Extention;

namespace TN.StudentBus.Office
{
    public partial class EditStudent : Form
    {
        private int id;
        private int Stt = 0;
        private List<SchoolModel> ListSchool = new List<SchoolModel>();
        public AxZKFPEngXControl.AxZKFPEngX SensorDriver;

        private int _IdFinger1 = 0;
        private int _IdFinger2 = 0;
        public EditStudent(int id)
        {
            InitializeComponent();
            this.id = id;
            if (id > 0)
            {
                lblType.Text = "CHỈNH SỬA HỌC SINH";
            }
            else
            {
                lblType.Text = "THÊM MỚI HỌC SINH";
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            SensorDriver.OnCapture -= new AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEventHandler(SensorDriver_OnCapture);
            SensorDriver.OnImageReceived -= new AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEventHandler(SensorDriver_OnImageReceived);
            SensorDriver.OnFeatureInfo -= new AxZKFPEngXControl.IZKFPEngXEvents_OnFeatureInfoEventHandler(SensorDriver_OnFeatureInfo);
            SensorDriver.OnImageReceived -= new AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEventHandler(SensorDriver_OnImageReceived);
            SensorDriver.OnEnroll -= new AxZKFPEngXControl.IZKFPEngXEvents_OnEnrollEventHandler(SensorDriver_OnEnrollAsync);
            this.Close();
        }
        private async Task ShowData()
        {

            var kt = await DALContext.StudentById(AppSettings.UserInfo?.Token, id);
            if (kt != null)
            {
                lblType.Text = "CHỈNH SỬA HỌC SINH";
                _StudentName.Text = kt.FullName;
                _School.SelectedValue = kt.SchoolId;
                if(_Class.Items.Count>1)
                {
                    _Class.SelectedValue = kt.ClassOfSchoolId;
                }
               else
                {
                    var a = await BindClass(Convert.ToInt32(_School.SelectedValue));
                    _Class.SelectedValue = kt.ClassOfSchoolId;
                }
                _Birthday.Value = kt.Birthday ?? DateTime.Now;
                _Status.Checked = kt.Status;
                _Code.Text = kt.Code;
                _Address.Text = kt.Address;
                _Phone.Text = kt.Phone;
                _Code.Text = kt.Code;
                int gt = (int)kt.Sex;
                _Sex.SelectedValue = gt;
                if (string.IsNullOrEmpty(kt.FingerTemplate1))
                {
                    _InfoF1.Text = "Chưa có";
                    btnEditF1.Text = "Thêm";
                }
                else
                {
                    _InfoF1.Text = "Đã có";
                    btnEditF1.Text = "Chỉnh sửa";
                }
                if (string.IsNullOrEmpty(kt.FingerTemplate2))
                {
                    _InfoF2.Text = "Chưa có";
                    btnEditF2.Text = "Thêm";
                }
                else
                {
                    _InfoF2.Text = "Đã có";
                    btnEditF2.Text = "Chỉnh sửa";
                }
                btnEditF1.Visible = true;
                btnEditF2.Visible = true;
                _IdFinger1 = kt.Finger1Id;
                _IdFinger2 = kt.Finger2Id;

            }
            else
            {
                lblType.Text = "THÊM MỚI HỌC SINH";
                _InfoF1.Text = "Lưu thay đổi để sử dụng chức năng này";
                _InfoF2.Text = "Lưu thay đổi để sử dụng chức năng này";
                btnEditF1.Visible = false;
                btnEditF2.Visible = false;
            }
            if(id>0)
            {
                labelExe.Visible = false;
            }
            else
            {
                labelExe.Visible = true;
            }
        }
        private void OnStart()
        {
            if (SensorDriver.IsRegister)
            {
                SensorDriver.CancelEnroll();
            }
            SensorDriver.EnrollCount = 3;
            SensorDriver.BeginEnroll();
            lblStatus.Text = "  Bắt đầu đăng ký quét vân tay 3 lần.";
            lblStatus.ForeColor = Color.Green;
        }

        private async void BtnSave_ClickAsync(object sender, EventArgs e)
        {

            try
            {
                if (_StudentName.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên học sinh", "Hệ thống");
                    _StudentName.Focus();
                    return;
                }
                if (_School.SelectedValue.ToString() == "-1")
                {
                    MessageBox.Show("Bạn chưa chọn trường", "Hệ thống");
                    _School.Focus();
                    return;
                }
                if (_Class.SelectedValue.ToString() == "-1")
                {
                    MessageBox.Show("Bạn chưa chọn lớp", "Hệ thống");
                    _Class.Focus();
                    return;
                }

                var kt = await DALContext.StudentById(AppSettings.UserInfo?.Token, id);
                if (kt == null)
                {
                    kt = new StudentModel();
                }
                kt.FullName = _StudentName.Text;
                kt.ClassOfSchoolId = Convert.ToInt32(_Class.SelectedValue);
                kt.SchoolId = Convert.ToInt32(_School.SelectedValue);
                kt.Birthday = _Birthday.Value;
                kt.Status = _Status.Checked;
                kt.Sex = (StudentModel.StudentSex)_Sex.SelectedValue;
                kt.Phone = _Phone.Text;
                kt.Address = _Address.Text;
                if (id <= 0)
                {
                    var output =   await DALContext.StudentCreate(AppSettings.UserInfo?.Token, kt);
                    if(output >0)
                    {
                        id = output;
                        MessageBox.Show("Thêm mới học sinh thành công!", "Hệ thống");
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới học sinh thất bại!", "Hệ thống");
                    }
                }
                else
                {
                    var output = await DALContext.StudentUpdate(AppSettings.UserInfo?.Token, kt);
                    if (output > 0)
                    {
                        MessageBox.Show("Cập nhật học sinh thành công!", "Hệ thống");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật học sinh thất bại!", "Hệ thống");
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("BtnSave_ClickAsync", ex.ToString());
                return;
            }
        }

        #region "Functions"
        public async Task<bool> BindSchoolAsync()
        {
            try
            {
                CheckedNotifileRole();
                var arrayList = new ArrayList();
                var list = new List<SchoolModel>
            {
               new SchoolModel{Id=-1,Name="Chọn trường"}
            };
                var apiData = await DALContext.FindSchool(AppSettings.UserInfo?.Token);
                list.AddRange(apiData);
                foreach (var item in list)
                {
                    arrayList.Add(new { Id = item.Id, Name = item.Name });
                }

                _School.DisplayMember = "Name";
                _School.ValueMember = "Id";
                _School.DataSource = arrayList;
                return true;
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("BindSchoolAsync", ex.ToString());
                return false;
            }
           
        }
        public void BindSex()
        {
            var arrayList = new ArrayList
            {
                new { Id = -1, Name = "Chọn giới tính..." },
                new { Id = 0, Name = "Nữ" },
                new { Id = 1, Name = "Nam" }
            };
            _Sex.DataSource = arrayList;
            _Sex.DisplayMember = "Name";
            _Sex.ValueMember = "Id";
        }
        public async Task<bool> BindClass(int schoolId)
        {
            CheckedNotifileRole();
            var list = new List<ClassOfSchoolModel>
            {
                new ClassOfSchoolModel { Id = -1, Name = "Tất cả"}
            };
            if (schoolId > 0)
            {
                list.AddRange(await DALContext.FindClassOfSchool(AppSettings.UserInfo?.Token, schoolId));
            }
            _Class.DataSource = list.OrderBy(m => m.Id).Select(m => new { m.Id, m.Name }).ToList();
            _Class.DisplayMember = "Name";
            _Class.ValueMember = "Id";
            return true;
        }

        #endregion

        private async void CheckedNotifileRole()
        {
            if (!(await DALContext.IsLoginAsync(AppSettings.UserInfo?.Token)))
            {
                var form = new Login();
                form.ShowDialog();
            }
        }

        private void _School_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnEditF1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                OnStart();
                Stt = 1;
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("BtnEditF1_LinkClicked", ex.ToString());
                return ;
            }
        }

        private void BtnEditF2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                OnStart();
                Stt = 2;
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("BtnEditF2_LinkClicked", ex.ToString());
                return;
            }
        }
        private void SensorDriver_OnCapture(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEvent e)
        {
            try
            {
                if (Main.FMatchType == 1)
                {
                    bool RegChanged = false;
                    string sTemp = SensorDriver.GetTemplateAsString();
                    string sVerTemplate;

                    sVerTemplate = Main.sRegTemplate;
                    if (SensorDriver.VerFingerFromStr(ref sVerTemplate, sTemp, false, ref RegChanged))
                    {
                        lblStatus.Text = "  Xác thực thành công.";
                        lblStatus.ForeColor = Color.Green;

                    }
                    else
                    {
                        lblStatus.Text = "  Xác thực thất bại.";
                        lblStatus.ForeColor = Color.Red;
                    }
                }
                else if (Main.FMatchType == 2)
                {
                    int score = 8;
                    int processedNum = 1;
                    int ID = SensorDriver.IdentificationInFPCacheDB(Main.fpcHandle, e.aTemplate, ref score, ref processedNum);
                    if (ID == -1)
                        lblStatus.Text = "Nhận dạng thất bại";
                    else
                    {
                        lblStatus.Text = $"Nhận dạng thành công ID = {ID} - Score = {score}  Processed Number = {processedNum}";
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("SensorDriver_OnCapture", ex.ToString());
                return;
            }
        }
        private async void SensorDriver_OnEnrollAsync(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnEnrollEvent e)
        {
            try
            {
                if (!e.actionResult)
                {
                    MessageBox.Show("Chất lượng vân tay thấp vui lòng thử lại!", "Hệ thống");
                }
                else
                {
                    Main.sRegTemplate = SensorDriver.GetTemplateAsString();

                    if (Main.sRegTemplate.Length > 0 && Stt > 0)
                    {
                        int score = 8;
                        int processedNum = 1;
                        object pTemplate = SensorDriver.DecodeTemplate1(Main.sRegTemplate);
                        int ID = SensorDriver.IdentificationInFPCacheDB(Main.fpcHandle, pTemplate, ref score, ref processedNum);
                        if (ID == -1)
                        {
                            int thisIdFinger = Stt == 1 ? _IdFinger1 : _IdFinger2;
                            SensorDriver.AddRegTemplateStrToFPCacheDB(Main.fpcHandle, thisIdFinger, Main.sRegTemplate);
                            var kt = await DALContext.StudentUpdateFinger(AppSettings.UserInfo?.Token, id, Stt, Main.sRegTemplate);
                            if(kt>0)
                            {
                                MessageBox.Show("Đăng ký vân tay thành công.", "Hệ thống");
                            }
                            else
                            {
                                MessageBox.Show("Đăng ký vân tay thất bại, lỗi server.", "Hệ thống");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Đăng ký thất bại, mẫu đã tồn tại", "Hệ thống");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký thất bại, dữ liệu không hợp lệ", "Hệ thống");
                    };
                }
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("SensorDriver_OnEnrollAsync", ex.ToString());
                return;
            }
        }
        private void SensorDriver_OnImageReceived(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            int dc = g.GetHdc().ToInt32();
            SensorDriver.PrintImageAt(dc, 0, 0, 95, 130);
        }
        private void SensorDriver_OnFeatureInfo(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnFeatureInfoEvent e)
        {
            try
            {
                string sTemp = "";
                if (SensorDriver.IsRegister)
                    sTemp = "Vân tay: " + Stt + ", lần " + (SensorDriver.EnrollIndex == 1 ? 3 : (SensorDriver.EnrollIndex == 2 ? 2 : 1)).ToString() + "!";
                sTemp = sTemp + " Chất lượng ";
                int lastq = SensorDriver.LastQuality;
                if (e.aQuality == -1)
                    sTemp = sTemp + lastq.ToString();
                else if (e.aQuality != 0)
                    sTemp = sTemp + lastq.ToString();
                else
                    sTemp = sTemp + lastq.ToString();
                lblStatus.Text = sTemp;
                lblStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("SensorDriver_OnFeatureInfo", ex.ToString());
                return;
            }
        }

        private void EditStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SensorDriver.OnCapture -= new AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEventHandler(SensorDriver_OnCapture);
                SensorDriver.OnImageReceived -= new AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEventHandler(SensorDriver_OnImageReceived);
                SensorDriver.OnFeatureInfo -= new AxZKFPEngXControl.IZKFPEngXEvents_OnFeatureInfoEventHandler(SensorDriver_OnFeatureInfo);
                SensorDriver.OnImageReceived -= new AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEventHandler(SensorDriver_OnImageReceived);
                SensorDriver.OnEnroll -= new AxZKFPEngXControl.IZKFPEngXEvents_OnEnrollEventHandler(SensorDriver_OnEnrollAsync);
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("EditStudent_FormClosing", ex.ToString());
                return;
            }
        }

        private async void EditStudent_Load(object sender, EventArgs e)
        {

            BindSex();
            var a = await BindSchoolAsync();
            if(a)
            {
              await  ShowData();
            }
            try
            {
                SensorDriver.OnCapture += new AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEventHandler(SensorDriver_OnCapture);
                SensorDriver.OnImageReceived += new AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEventHandler(SensorDriver_OnImageReceived);
                SensorDriver.OnFeatureInfo += new AxZKFPEngXControl.IZKFPEngXEvents_OnFeatureInfoEventHandler(SensorDriver_OnFeatureInfo);
                SensorDriver.OnImageReceived += new AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEventHandler(SensorDriver_OnImageReceived);
                SensorDriver.OnEnroll += new AxZKFPEngXControl.IZKFPEngXEvents_OnEnrollEventHandler(SensorDriver_OnEnrollAsync);
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("EditStudent_Load", ex.ToString());
                return;
            }
        }
       
        private async void _School_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CheckedNotifileRole();
            var thisval = _School.SelectedValue;
            if (thisval != null)
            {
                if (thisval.IsNumber())
                {
                    var a = await BindClass(Convert.ToInt32(_School.SelectedValue));
                }
                else
                {
                    var a = await BindClass(Convert.ToInt32(Functions.GetPropertyInObject(thisval, "Id")));
                }
            }
        }
        
        public void BindC(object id)
        {
            _Class.SelectedValue = id;
        }
    }
}
