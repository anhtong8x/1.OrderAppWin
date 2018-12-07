using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TN.StudentBus.Office.Extention;

namespace TN.StudentBus.Office
{
    public partial class Main : Form
    {
        public static int FMatchType;
        public static int fpcHandle;
        public static string sRegTemplate;
        public static string dataPath = "data";
        public int TotalRows = 0;
        public int Page = 1;
        public int Limit = 50;

        public Main()
        {
            InitializeComponent();
       
        }
        private void MenuAddStudent_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    EditStudent control = new EditStudent(0)
            //    {
            //        SensorDriver = this.SensorDriver
            //    };
            //    control.Show();
            //}
            //catch (Exception)
            //{
            //   // Utilities.WriteErrorLog("menuAddStudent_Click", ex.ToString());
            //    return;
            //}
        }

        private void MenuStudentManager_Click(object sender, EventArgs e)
        {
        }

        private void MenuUserManager_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    panelMain.Controls.Clear();
            //    UserManager control = new UserManager
            //    {
            //        Dock = DockStyle.Fill
            //    };
            //    panelMain.Controls.Add(control);
            //}
            //catch (Exception)
            //{
            //    //Utilities.WriteErrorLog("menuUserManager_Click", ex.ToString());
            //    return;
            //}
        }

        private void MenuSerting_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cấu hình hiện là mặc định!", "Hệ thống");
        }

        private void MenuFullName_Click(object sender, EventArgs e)
        {

        }

        private void MenuLogOut_Click(object sender, EventArgs e)
        {
            try
            {
                SensorDriver.EndEngine();
                AppSettings.RemoveToken();
                this.Close();
           
            }
            catch (Exception)
            {
                //Utilities.WriteErrorLog("menuLogOut_Click", ex.ToString());
                return;
            }
        }
        
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    var form = new TestFinger
            //    {
            //        SensorDriver = this.SensorDriver
            //    };
            //    form.Show();
            //}
            //catch (Exception)
            //{
            //   // Utilities.WriteErrorLog("BtnCheck_Click", ex.ToString());
            //    return;
            //}
        }

        private void BtnUpdateData_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn kết nối đến thiết bị quét vân tay không?", "Hệ thống", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    SensorDriver.EndEngine();
                    ConnectSensor(PBar);
                }
            }
            catch (Exception)
            {
                //Utilities.WriteErrorLog("BtnUpdateData_Click_1", ex.ToString());
                return;
            }
        }

        private void BtnDisconect_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn ngắt kết nối đến thiết bị quét vân tay không?", "Hệ thống", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    SensorDriver.EndEngine();
                    MessageBox.Show("Ngắt kết nối đến thiết bị quét vân tay thành công?", "Hệ thống");
                    LblInfo.Text = "Không kết nối";
                    LblInfo.ForeColor = Color.Red;
                }
            }
            catch (Exception)
            {
                //Utilities.WriteErrorLog("BtnDisconect_Click", ex.ToString());
                return;
            }
        }

        public async void ConnectSensor(ProgressBar PBarX)
        {
            SensorDriver.FakeFunOn = 1;
            if (SensorDriver.InitEngine() == 0)
            {
                SensorDriver.FPEngineVersion = "10";
                fpcHandle = SensorDriver.CreateFPCacheDB();
                LblInfo.Text = "Đang kết nối";
                LblInfo.ForeColor = Color.Green;
                //// green light
                //SensorDriver.ControlSensor(11, 1);
                //Thread.Sleep(100);
                //SensorDriver.ControlSensor(11, 0);
                //// beep
                //SensorDriver.ControlSensor(13, 1);
                //Thread.Sleep(100);
                //SensorDriver.ControlSensor(13, 0);
                //// update
                SensorDriver.FreeFPCacheDB(fpcHandle);
                var list = await DALContext.StudentFingerPrints(AppSettings.UserInfo?.Token);
                PBarX.Maximum = list.Count() == 0 ? 1 : list.Count();
                PBarX.Step = 1;
                if (list.Count() == 0)
                {
                    PBarX.Maximum = 1;
                    PBarX.PerformStep();
                    return;
                }
                foreach (var item in list)
                {
                    if (item.Finger1Id > 0 && !string.IsNullOrEmpty(item.FingerTemplate1) && item.FingerTemplate1!="")
                    {
                        SensorDriver.AddRegTemplateStrToFPCacheDB(fpcHandle, item.Finger1Id, item.FingerTemplate1);
                    }
                    if (item.Finger2Id > 0 && !string.IsNullOrEmpty(item.FingerTemplate2) && item.FingerTemplate2 != "")
                    {
                        SensorDriver.AddRegTemplateStrToFPCacheDB(fpcHandle, item.Finger2Id, item.FingerTemplate2);
                    }
                    PBarX.PerformStep();
                }
              
                PBarX.Maximum = list.Count() == 0 ? 1 : list.Count();
                PBarX.Step = 1;
                if (list.Count() == 0)
                {
                    PBarX.Maximum = 1;
                    PBarX.PerformStep();
                    return;
                }
                btnKetNoiLai.Enabled = false;
                btnDisconect.Enabled = true;
            }
            else
            {
                SensorDriver.EndEngine();
                LblInfo.Text = "Không kết nối";
                LblInfo.ForeColor = Color.Red;
                btnKetNoiLai.Enabled = true;
                btnDisconect.Enabled = false;
            }
        }
        private async void Main_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in this.Controls)
                {
                    c.Enabled = false;
                }

                await CheckedNotifileRole();
                LoadDisplay();
                InitBind();
                // init vân tay
                if (MessageBox.Show("Bạn có muốn bật thiết bị quét vân tay ngay không?", "Hệ thống", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    SensorDriver.EndEngine();
                    ConnectSensor(PBar);
                }
                foreach (Control c in this.Controls)
                {
                    c.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("BtnThoat_Click", ex.ToString());
                MessageBox.Show("Không có kết nối đến máy chủ.", "Hệ thống");
                return;
            }
        }
        private void LoadDisplay()
        {
            menuFullName.Text = AppSettings.UserInfo.DisplayName;
        }
        
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SensorDriver != null)
            {
                SensorDriver.EndEngine();
            }
        }


        private void BtnThoat_Click(object sender, EventArgs e)
        {
            try
            {
                SensorDriver.EndEngine();
                this.Close();
                var form = new Login();
                form.Show();
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("BtnThoat_Click", ex.ToString());
                return;
            }
        }
        
        private void BtnKetNoiLai_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn kết nối đến thiết bị quét vân tay không?", "Hệ thống", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    SensorDriver.EndEngine();
                    ConnectSensor(PBar);
                }
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("BtnKetNoiLai_Click", ex.ToString());
                return;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn ngắt kết nối đến thiết bị quét vân tay không?", "Hệ thống", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    SensorDriver.EndEngine();
                    MessageBox.Show("Ngắt kết nối đến thiết bị quét vân tay thành công?", "Hệ thống");
                    LblInfo.Text = "Không kết nối";
                    LblInfo.ForeColor = Color.Red;
                    btnKetNoiLai.Enabled = true;
                    btnDisconect.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("Button1_Click", ex.ToString());
                return;
            }
        }

        private async void InitBind()
        {
            try
            {
                BindStatus();
                await BindSchoolAsync();
                await BindClass(Convert.ToInt32(_School.SelectedValue));
                BindStudent();
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("InitBind", ex.ToString());
                return;
            }
        }

        private void BtnLichSu_Click(object sender, EventArgs e)
        {
            //panelMain.Controls.Clear();
            //StudentCheckOutManager control = new StudentCheckOutManager
            //{
            //    Dock = DockStyle.Fill
            //};
            //panelMain.Controls.Add(control);
        }

        private void BtnCheck_Click_1(object sender, EventArgs e)
        {
            try
            {
                SensorDriver.EndEngine();
                ConnectSensor(PBar);
                var form = new TestFinger
                {
                    SensorDriver = this.SensorDriver
                };
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("BtnCheck_Click_1", ex.ToString());
                return;
            }
        }
        public async Task BindSchoolAsync()
        {
            var list = new List<SchoolModel>
            {
                new SchoolModel { Id = -1, Name = "Tất cả" }
            };
            var apiData = await DALContext.FindSchool(AppSettings.UserInfo?.Token);
            list.AddRange(apiData);
            _School.DataSource = list;
            _School.DisplayMember = "Name";
            _School.ValueMember = "Id";
        }
        private async Task CheckedNotifileRole()
        {
            if (!(await DALContext.IsLoginAsync(AppSettings.UserInfo?.Token)))
            {
                var form = new Login();
                form.ShowDialog();
            }
        }
        public void BindStatus()
        {
            var arrayList = new ArrayList
            {
                new { Id = -1, Name = "Tất cả..." },
                new { Id = 1, Name = "Sử dụng" },
                new { Id = 0, Name = "Không sử dụng" }
            };

            _Status.DataSource = arrayList;
            _Status.DisplayMember = "Name";
            _Status.ValueMember = "Id";
            _Status.SelectedIndex = 1;

        }
        public async Task BindClass(int schoolId)
        {
            await CheckedNotifileRole();
            var list = new List<ClassOfSchoolModel>
            {
                new ClassOfSchoolModel { Id = -1, Name = "Tất cả",SchoolId = schoolId }
            };
            if (schoolId > 0)
            {
                list.AddRange(await DALContext.FindClassOfSchool(AppSettings.UserInfo?.Token, schoolId));
            }
            _Class.DataSource = list.OrderBy(m => m.Id).Select(m => new { m.Id, m.Name }).ToList();
            _Class.DisplayMember = "Name";
            _Class.ValueMember = "Id";
        }
        
        private async void BindStudent()
        {
            try
            {
                int schoolId = Convert.ToInt32(_School.SelectedValue);
                int classOfSchoolId = Convert.ToInt32(_Class.SelectedValue);
                bool? status = null;
                if (_Status.SelectedValue.ToString() == "1")
                {
                    status = true;
                }
                if (_Status.SelectedValue.ToString() == "0")
                {
                    status = false;
                }
                Page = Page > 0 ? Page : 1;
                var list = await DALContext.FindStudent(AppSettings.UserInfo?.Token, Page, Limit, _key.Text, schoolId, classOfSchoolId, status);
                var newList = list.Data.Select(m => new {
                    m.Id,
                    m.FullName,
                    Sex = (m.Sex == StudentModel.StudentSex.Male ? "Nam" : m.Sex == StudentModel.StudentSex.Male ? "Nữ" : "---"),
                    m.Birthday,
                    m.Code,
                    m.Address,
                    m.Phone,
                    ClassName = m.ClassOfSchool?.Name,
                    SchoolName = m.School?.Name,
                    StatusFinger1 = m.FingerTemplate1 != null ? true : false,
                    StatusFinger2 = m.FingerTemplate2 != null ? true : false,
                    StatusName = m.Status,
                }).ToList();
                gr.DataSource = newList;

                TotalRows = list.TotalRecord;
                Limit = list.Limit;
                Page = list.Page;
                var totalPage = (TotalRows % Limit > 0) ? (TotalRows / Limit + 1) : (TotalRows / Limit);
                var listPage = new List<object>();
                totalPage = totalPage <= 0 ? 1 : totalPage;
                TxtSoTrang.Text = $"Bản ghi từ {((Page - 1) * Limit) + 1 } đến {((Page != totalPage) ? (Page * Limit) : (TotalRows))}, tìm thấy {TotalRows} bản ghi, trang {Page}/{totalPage}";
                if (Page == 1)
                {
                    BtnTrangTruoc.Enabled = false;
                }
                else
                {
                    BtnTrangTruoc.Enabled = true;
                }
                if (Page == totalPage)
                {
                    BtnTrangTiep.Enabled = false;
                }
                else
                {
                    BtnTrangTiep.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("BtnCheck_Click_1", ex.ToString());
                return;
            }
            
        }
       
        private async void _School_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                await CheckedNotifileRole();
                if (_School.SelectedValue.IsNumber())
                {
                    await BindClass(Convert.ToInt32(_School.SelectedValue));
                }
                else
                {
                    await BindClass(Convert.ToInt32(Functions.GetPropertyInObject(_School.SelectedValue, "Id")));
                }
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("_School_SelectedIndexChanged", ex.ToString());
                return;
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Page = 1;
                BindStudent();
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("_School_SelectedIndexChanged", ex.ToString());
                return;
            }
        }

        private void BtnTrangTiep_Click(object sender, EventArgs e)
        {
            try
            {
                Page = Page + 1;
                BindStudent();
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("BtnTrangTiep_Click", ex.ToString());
                return;
            }
        }

        private void BtnTrangTruoc_Click(object sender, EventArgs e)
        {
            try
            {
                Page = Page - 1;
                BindStudent();
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("BtnTrangTiep_Click", ex.ToString());
                return;
            }
        }


        private void Gr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gr.Rows[e.RowIndex].Cells[0].Value);
                var editStudent = new EditStudent(id)
                {
                    SensorDriver = SensorDriver
                };
                editStudent.ShowDialog();
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("gr_CellClick", ex.ToString());
                return;
            }
        }

        private void BtnAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                var editStudent = new EditStudent(0)
                {
                    SensorDriver = SensorDriver,
                };
                editStudent.ShowDialog();
                BindStudent();
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("gr_CellClick", ex.ToString());
                return;
            }
        }
    }
}
