using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OfficeOpenXml;
using TN.API.Code;
using TN.API.EF;
using TN.API.Models;
using TN.API.Services;

namespace TN.API.Controllers
{
    public class TongHopTroGiaDuaDonHocSinhModel
    {
        public int Order { get; set; }
        public string Vehicle { get; set; }
        public int Count { get; set; }
        public int Turns { get; internal set; }
    }
    public class BangChamCongHocSinhModel
    {
        public int Order { get; set; }
        public string StudentName { get; set; }
        public List<ValueOfDayModel> Days { get; set; }
    }
    public class ValueOfDayModel
    {
        public int Id { get; set; }
        public int Count { get; set; }
    }
    public class DanhSachHocSinhDiXeTheoNgayModel
    {
        public int IdVehicle { get; set; }
        public int IdStudent { get; set; }
        public string StudentName { get; set; }
        public string SchoolName { get; set; }
        public string ClassOfSchoolName { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
    public class ChiTietDanhSachHocSinhDiXeTheoNgayModel
    {
        public int Id { get; set; }
        public int IdVehicle { get; set; }
        public int IdStudent { get; set; }
        public string StudentName { get; set; }
        public string SchoolName { get; set; }
        public string ClassOfSchoolName { get; set; }
        public DateTime CheckOutDate { get; set; }

        public DateTime? TGLenXeCa1 { get; set; }
        public string DDLenXeCa1 { get; set; }
        public RouteModel TDLenXeCa1 { get; set; }
        public DateTime? TGXuongXeCa1 { get; set; }
        public RouteModel TDXuongXeCa1 { get; set; }
        public string DDXuongXeCa1 { get; set; }
        public int HopLeCa1 { get; set; }

        public DateTime? TGLenXeCa2 { get; set; }
        public string DDLenXeCa2 { get; set; }
        public RouteModel TDLenXeCa2 { get; set; }
        public DateTime? TGXuongXeCa2 { get; set; }
        public string DDXuongXeCa2 { get; set; }
        public RouteModel TDXuongXeCa2 { get; set; }
        public int HopLeCa2 { get; set; }
        public int TongHopLe { get; set; }
        public int TongKhongHopLe { get; set; }

        public int SoLuotDuaDon { get; set; }
        public List<AddressComponents> DataDiaChi { get; internal set; }
    }
    [Produces("application/json")]
    [Route("api/Export")]
    public class ExportController : Controller
    {
        private readonly IHostingEnvironment _iHostingEnvironment;
        private readonly TNFingerContext db;
        private readonly BaseSettings _baseSettings;
        public ExportController(IHostingEnvironment iHostingEnvironment, TNFingerContext context, IOptions<BaseSettings> baseSettings)
        {
            _iHostingEnvironment = iHostingEnvironment;
            db = context;
            _baseSettings = baseSettings.Value;
        }
        [HttpGet("TongHopTroGiaDuaDonHocSinh/{schoolId}/{month}/{year}/{Name}")]
        public async Task<IActionResult> TongHopTroGiaDuaDonHocSinhAsync(int schoolId, int year, int month, string Name)
        {
            var dlSchool = db.School.FirstOrDefault(m => m.Id == schoolId);
            var listObject = new List<TongHopTroGiaDuaDonHocSinhModel>();
            int days = DateTime.DaysInMonth(year, month);
            var listVehicle = db.Vehicle.Where(m => m.Status == true).ToList();
            int order = 1;
            foreach (var item in listVehicle)
            {
                int countTurn1 = 0;
                int countTurn2 = 0;
                var listData = db.StudentCheckOut.Where(m => m.IdDeviceNavigation.IdVehicle == item.Id && m.CheckOutDate.Year == year && m.CheckOutDate.Month == month && m.IdStudentNavigation.IdSchool == schoolId && m.IdStudentNavigation.Disable == false).Select(m => new { m.Id, m.CheckOutDate, m.IdStudent }).ToList();
                var listStudent = listData.GroupBy(m => m.IdStudent);

                foreach (var itemTurn in listStudent)
                {
                    for (int i = 1; i <= days; i++)
                    {
                        countTurn1 += (listData.Any(m => m.IdStudent == itemTurn.FirstOrDefault().IdStudent && m.CheckOutDate.Day == i && m.CheckOutDate.Hour >= 5 && m.CheckOutDate.Hour <= 11) == true ? 1 : 0);
                        countTurn2 += (listData.Any(m => m.IdStudent == itemTurn.FirstOrDefault().IdStudent && m.CheckOutDate.Day == i && m.CheckOutDate.Hour >= 12 && m.CheckOutDate.Hour <= 23) == true ? 1 : 0);
                    }
                }

                var objectx = new TongHopTroGiaDuaDonHocSinhModel
                {
                    Order = order,
                    Vehicle = item.Lpn,
                    Count = listStudent.Count(),
                    Turns = countTurn1 + countTurn2
                };
                listObject.Add(objectx);
                order++;
            }
            string sFileName = $"{Guid.NewGuid()}.xlsx";
            FileInfo existingFile = new FileInfo(Path.Combine(_iHostingEnvironment.ContentRootPath + "/Export/Templates/", "TongHopTroGiaDuaDonHocSinh.xlsx"));
            FileInfo fNewFile = new FileInfo(Path.Combine(_iHostingEnvironment.ContentRootPath + "/Export/Files/", sFileName));
            using (ExcelPackage MyExcel = new ExcelPackage(existingFile))
            {
                ExcelWorksheet MyWorksheet = MyExcel.Workbook.Worksheets[1];
                MyWorksheet.Cells["A1"].Value = Name.ToUpper();
                MyWorksheet.Cells["D3"].Value = $"Thành phố Hồ Chí Minh, ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";
                MyWorksheet.Cells["A5"].Value = $"TỔNG HỢP TRỢ GIÁ ĐƯA ĐÓN HỌC SINH  THÁNG {month}/{year}";
                MyWorksheet.Cells["A6"].Value = $"TRƯỜNG: {dlSchool?.Name.ToUpper()}";

                int StartRow = 8;
                int i = 0;
                int colurm = 1;
                foreach (var item in listObject)
                {

                    MyWorksheet.Cells[StartRow + i, colurm].Value = item.Order;
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;
                    MyWorksheet.Cells[StartRow + i, colurm].Value = item.Vehicle;
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;
                    MyWorksheet.Cells[StartRow + i, colurm].Value = item.Count;
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;
                    if (item.Count > 0)
                    {
                        MyWorksheet.Cells[StartRow + i, colurm].Value = item.Turns;
                    }
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;
                    MyWorksheet.Cells[StartRow + i, colurm].Value = "";
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm = 1;
                    i++;
                }
                MyExcel.SaveAs(fNewFile);
            }
            string path = fNewFile.FullName;
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/x-msdownload", Path.GetFileName(path));
        }
        [HttpGet("BangChamCongHocSinh/{schoolId}/{month}/{year}/{name}")]
        public async Task<IActionResult> BangChamCongHocSinh(int schoolId, int year, int month, string name)
        {
            var dlSchool = db.School.FirstOrDefault(m => m.Id == schoolId);
            var listObject = new List<BangChamCongHocSinhModel>();
            var listCheckOut = db.StudentCheckOut.Where(m => m.IdStudentNavigation.IdSchool == schoolId && m.CheckOutDate.Year == year && m.CheckOutDate.Month == month && m.IdStudentNavigation.Disable == false).ToList();
            var listStudent = db.Student.Where(m => m.IdSchool == schoolId && m.Disable == false).ToList();
            int days = DateTime.DaysInMonth(year, month);
            int order = 1;
            foreach (var item in listStudent)
            {
                var data = new BangChamCongHocSinhModel
                {
                    Order = order,
                    StudentName = item.StudentName,
                    Days = new List<ValueOfDayModel>()
                };
                for (int i = 1; i <= days; i++)
                {
                    var dlNgay = new ValueOfDayModel { Id = i, Count = 0 };
                    var listCheckOutByStudent = listCheckOut.Where(m => m.IdStudent == item.Id && m.CheckOutDate.Day == i).OrderBy(m => m.CheckOutDate);
                    dlNgay.Count += listCheckOutByStudent.Any(m => m.CheckOutDate.Hour >= 5 && m.CheckOutDate.Hour <= 11) == true ? 1 : 0;
                    dlNgay.Count += listCheckOutByStudent.Any(m => m.CheckOutDate.Hour >= 12 && m.CheckOutDate.Hour <= 23) == true ? 1 : 0;
                    data.Days.Add(dlNgay);
                }
                listObject.Add(data);
                order++;
            }

            string sFileName = $"{Guid.NewGuid()}.xlsx";
            FileInfo existingFile = new FileInfo(Path.Combine(_iHostingEnvironment.ContentRootPath + "/Export/Templates/", "BangChamCongHocSinh.xlsx"));
            FileInfo fNewFile = new FileInfo(Path.Combine(_iHostingEnvironment.ContentRootPath + "/Export/Files/", sFileName));
            using (ExcelPackage MyExcel = new ExcelPackage(existingFile))
            {
                ExcelWorksheet MyWorksheet = MyExcel.Workbook.Worksheets[1];
                MyWorksheet.Cells["A1"].Value = name.ToUpper();
                // MyWorksheet.Cells["D3"].Value = $"Thành phố Hồ Chí Minh, ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";
                MyWorksheet.Cells["A3"].Value = $"TỔNG HỢP TRỢ GIÁ ĐƯA ĐÓN HỌC SINH  THÁNG {month}/{year}";
                MyWorksheet.Cells["A4"].Value = $"TRƯỜNG: {dlSchool?.Name.ToUpper()}";

                int StartRow = 6;
                int i = 0;
                int colurm = 3;
                for (int z = 1; z <= days; z++)
                {
                    MyWorksheet.Cells[StartRow + i, colurm].Value = z;
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;
                }
                MyWorksheet.Cells[5, 3, 5, 2 + days].Merge = true;
                MyWorksheet.Cells[5, 3, 5, 2 + days].Value = "NGÀY TRONG THÁNG/ THỨ TRONG TUẦN";
                SetBorder(MyWorksheet, 5, 3, 5, 2 + days);

                MyWorksheet.Column(days + 3).Width = GetTrueColumnWidth(5);
                MyWorksheet.Cells[StartRow + i - 1, colurm, StartRow + i, colurm].Merge = true;
                MyWorksheet.Cells[StartRow + i - 1, colurm].Value = "Tổng số lượt";

                SetBorder(MyWorksheet, StartRow + i - 1, colurm, StartRow + i, colurm);
                MyWorksheet.Cells[StartRow + i - 1, colurm].Style.WrapText = true;

                i++;
                colurm = 1;
                foreach (var item in listObject)
                {
                    MyWorksheet.Cells[StartRow + i, colurm].Value = item.Order;
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;
                    MyWorksheet.Cells[StartRow + i, colurm].Value = item.StudentName;
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;
                    foreach (var day in item.Days)
                    {
                        if (day.Count > 0)
                        {
                            MyWorksheet.Cells[StartRow + i, colurm].Value = day.Count;
                        }
                        SetBorder(MyWorksheet, StartRow + i, colurm);
                        colurm++;
                    }
                    int tongSo = item.Days.Sum(m => m.Count);
                    if (tongSo > 0)
                    {
                        MyWorksheet.Cells[StartRow + i, colurm].Value = tongSo;
                    }
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm = 1;
                    i++;
                }
                colurm = 1;
                MyWorksheet.Cells[StartRow + i, colurm, StartRow + i, colurm + 1].Merge = true;
                SetBorder(MyWorksheet, StartRow + i, colurm, StartRow + i, colurm + 1);

                MyWorksheet.Cells[StartRow + i, colurm].Value = "Tổng số";

                colurm++;
                colurm++;

                for (int j = 1; j <= days; j++)
                {
                    int tongSo = listObject.Sum(m => m.Days.FirstOrDefault(x => x.Id == j).Count);
                    if (tongSo > 0)
                    {
                        MyWorksheet.Cells[StartRow + i, colurm].Value = tongSo;
                    }
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;
                }
                int total = listObject.Sum(m => m.Days.Sum(x => x.Count));
                if (total > 0)
                {
                    MyWorksheet.Cells[StartRow + i, colurm].Value = total;
                }
                SetBorder(MyWorksheet, StartRow + i, colurm);
                MyExcel.SaveAs(fNewFile);
            }
            string path = fNewFile.FullName;
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/x-msdownload", Path.GetFileName(path));
        }
        [HttpGet("DanhSachHocSinhDiTheoNgay/{schoolId}/{date}/{Name}")]
        public async Task<IActionResult> DanhSachHocSinhDiTheoNgayAsync(int schoolId, string date, string name)
        {

            string sFileName = $"{Guid.NewGuid()}.xlsx";
            FileInfo existingFile = new FileInfo(Path.Combine(_iHostingEnvironment.ContentRootPath + "/Export/Templates/", "DanhSachHocSinhDiTheoNgay.xlsx"));
            FileInfo fNewFile = new FileInfo(Path.Combine(_iHostingEnvironment.ContentRootPath + "/Export/Files/", sFileName));
            var _date = Convert.ToDateTime(date.Replace("-", "/"));
            var dlSchool = db.School.FirstOrDefault(m => m.Id == schoolId);
            var listVehicle = db.Vehicle.Where(m => m.Status == true).ToList();
            var listStudent = db.StudentCheckOut.Where(m => m.IdStudentNavigation.Disable == false && m.CheckOutDate.Date == _date && db.Vehicle.Any(x => x.Id == m.IdDeviceNavigation.IdVehicle && x.Status == true))
                .Select(m => new DanhSachHocSinhDiXeTheoNgayModel
                {
                    IdVehicle = m.IdDeviceNavigation.IdVehicle,
                    IdStudent = m.IdStudent,
                    StudentName = m.IdStudentNavigation.StudentName,
                    SchoolName = m.IdStudentNavigation.IdSchoolNavigation.Name,
                    ClassOfSchoolName = m.IdStudentNavigation.IdClassOfSchoolNavigation.Name,
                    CheckOutDate = m.CheckOutDate
                }).ToList();
            using (ExcelPackage MyExcel = new ExcelPackage(existingFile))
            {
                ExcelWorksheet MyWorksheet = MyExcel.Workbook.Worksheets[1];
                MyWorksheet.Cells["A1"].Value = name.ToUpper();
                // MyWorksheet.Cells["D3"].Value = $"Thành phố Hồ Chí Minh, ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}";
                MyWorksheet.Cells["A5"].Value = $"DANH SÁCH HỌC SINH ĐI THEO NGÀY {_date.ToString("dd/MM/yyyy")}";
                MyWorksheet.Cells["A6"].Value = $"TRƯỜNG: {dlSchool?.Name.ToUpper()}";

                int StartRow = 8;
                int i = 0;

                foreach (var item in listVehicle)
                {
                    MyWorksheet.Cells[StartRow + i, 1, StartRow + i, 6].Merge = true;
                    SetBorder(MyWorksheet, StartRow + i, 1, StartRow + i, 6);
                    MyWorksheet.Cells[StartRow + i, 1].Value = item.Lpn;
                    MyWorksheet.Row(StartRow + i).Height = 20;
                    MyWorksheet.Cells[StartRow + i, 1].Style.Font.Bold = true;
                    MyWorksheet.Cells[StartRow + i, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    i++;
                    var listStudentVehicle = listStudent.Where(m => m.IdVehicle == item.Id);
                    int sttHocSinh = 1;
                    int colurm = 1;
                    foreach (var itemHocSinh in listStudentVehicle.GroupBy(m => m.IdStudent).Select(m => m.FirstOrDefault()))
                    {
                        var dlHocSinhCa1 = listStudent.Where(m => m.IdStudent == itemHocSinh.IdStudent && m.CheckOutDate.Hour >= 5 && m.CheckOutDate.Hour <= 11).OrderBy(m => m.CheckOutDate).FirstOrDefault();
                        var dlHocSinhCa2 = listStudent.Where(m => m.IdStudent == itemHocSinh.IdStudent && m.CheckOutDate.Hour >= 12 && m.CheckOutDate.Hour <= 19).OrderBy(m => m.CheckOutDate).FirstOrDefault();

                        MyWorksheet.Cells[StartRow + i, colurm].Value = sttHocSinh;
                        SetBorder(MyWorksheet, StartRow + i, colurm);
                        colurm++;

                        MyWorksheet.Cells[StartRow + i, colurm].Value = itemHocSinh.StudentName;
                        SetBorder(MyWorksheet, StartRow + i, colurm);
                        colurm++;

                        MyWorksheet.Cells[StartRow + i, colurm].Value = itemHocSinh.SchoolName;
                        SetBorder(MyWorksheet, StartRow + i, colurm);
                        colurm++;

                        MyWorksheet.Cells[StartRow + i, colurm].Value = itemHocSinh.ClassOfSchoolName;
                        SetBorder(MyWorksheet, StartRow + i, colurm);
                        colurm++;

                        if (dlHocSinhCa1 != null)
                        {
                            MyWorksheet.Cells[StartRow + i, colurm].Value = dlHocSinhCa1.CheckOutDate.ToString("HH:mm:ss");
                        }
                        SetBorder(MyWorksheet, StartRow + i, colurm);
                        colurm++;
                        if (dlHocSinhCa2 != null)
                        {
                            MyWorksheet.Cells[StartRow + i, colurm].Value = dlHocSinhCa2.CheckOutDate.ToString("HH:mm:ss");
                        }
                        SetBorder(MyWorksheet, StartRow + i, colurm);
                        colurm++;
                        sttHocSinh++;
                        i++;
                        colurm = 1;
                    }

                }
                MyExcel.SaveAs(fNewFile);
            }
            string path = fNewFile.FullName;
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/x-msdownload", Path.GetFileName(path));
        }
        private async Task<ValueTripsModel> ListStudentTrip(string lpn,string date,int groupId)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(new { lpn, date, groupId });
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var t = await httpClient.PostAsync(_baseSettings.ServiceStudentTripAllByDate, stringContent);
                var data = await t.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ValueTripsModel>(data);
            }
        }
        [HttpGet("ChiTietDuaDonHocSinhTrongNgay/{lpn}/{date}/{Name}")]
        public async Task<IActionResult> ChiTietDuaDonHocSinhTrongNgayAsync(string lpn, string date, string name)
        {
            var _date = Convert.ToDateTime(date.Replace("-", "/"));
            var listDiaDiem = new List<DataMapModel>();
            var dataRS = await ListStudentTrip(lpn, date, 31);
            var listCa = dataRS.D.Result;
            if (listCa.Count == 0)
            {
                return Content($"Dữ liệu GPS cho xe {lpn} ngày {date} chưa có. Không thể xuất báo cáo này");
            }

            var newOBject = new List<ChiTietDanhSachHocSinhDiXeTheoNgayModel>();
            string sFileName = $"{Guid.NewGuid()}.xlsx";
            FileInfo existingFile = new FileInfo(Path.Combine(_iHostingEnvironment.ContentRootPath + "/Export/Templates/", "ChiTietDuaDonHocSinhTrongNgay.xlsx"));
            FileInfo fNewFile = new FileInfo(Path.Combine(_iHostingEnvironment.ContentRootPath + "/Export/Files/", sFileName));

            var dlVehicle = db.Vehicle.FirstOrDefault(m => m.Lpn == lpn && m.Status == true);
            if (dlVehicle == null)
            {
                return null;
            }
            var listCheckoutStudent = db.StudentCheckOut.Where(m => m.IdStudentNavigation.Disable == false && m.CheckOutDate.Date == _date && db.Vehicle.Any(x => x.Id == m.IdDeviceNavigation.IdVehicle && x.Status == true && x.Lpn == lpn))
                .Select(m => new ChiTietDanhSachHocSinhDiXeTheoNgayModel
                {

                    IdVehicle = m.IdDeviceNavigation.IdVehicle,
                    Id = m.Id,
                    IdStudent = m.IdStudent,
                    StudentName = m.IdStudentNavigation.StudentName,
                    SchoolName = m.IdStudentNavigation.IdSchoolNavigation.Name,
                    ClassOfSchoolName = m.IdStudentNavigation.IdClassOfSchoolNavigation.Name,
                    CheckOutDate = m.CheckOutDate
                }).ToList();
            var listStudent = listCheckoutStudent.GroupBy(m => m.IdStudent).Select(m => m.FirstOrDefault());
            using (var _httpClient = new HttpClient())
            {
                List<string> lstToaDo = new List<string>();

                foreach (var item in listStudent)
                {
                    var addObject = new ChiTietDanhSachHocSinhDiXeTheoNgayModel
                    {
                        Id = item.Id,
                        IdStudent = item.IdStudent,
                        SchoolName = item.SchoolName,
                        ClassOfSchoolName = item.ClassOfSchoolName,
                        IdVehicle = item.IdVehicle,
                        StudentName = item.StudentName
                    };
                    var listHocSinhCa1 = listCheckoutStudent.Where(m => m.IdStudent == item.IdStudent && m.CheckOutDate.Hour >= 5 && m.CheckOutDate.Hour <= 10).OrderBy(m => m.CheckOutDate);
                    var dlLenXeCa1 = listHocSinhCa1.FirstOrDefault();
                    if (dlLenXeCa1 != null)
                    {
                        addObject.SoLuotDuaDon++;
                        addObject.TGLenXeCa1 = dlLenXeCa1.CheckOutDate;

                        // Hợp lệ khung thời gian
                        if (addObject.TGLenXeCa1 != null)
                        {
                            var ticLenXeCa1 = TIT.Core.Utilities.DateTimeToUnixTimestamp(addObject.TGLenXeCa1 ?? DateTime.Now);
                            var IsHopLe = listCa.Any(m => m.RealTimeStart <= ticLenXeCa1 && ticLenXeCa1 <= m.RealTimeEnd);
                            if (IsHopLe)
                            {
                                addObject.HopLeCa1++;
                            }
                            else
                            {
                                addObject.TongKhongHopLe++;
                            }
                        }

                        var dlXuongXeCa1 = listHocSinhCa1.LastOrDefault(m => m.Id != dlLenXeCa1.Id && m.CheckOutDate >= dlLenXeCa1.CheckOutDate.AddMinutes(_baseSettings.MTimesMiss));
                        if (dlXuongXeCa1 != null)
                        {
                            addObject.TGXuongXeCa1 = dlXuongXeCa1.CheckOutDate;
                        }
                    }

                    var listHocSinhCa2 = listCheckoutStudent.Where(m => m.IdStudent == item.IdStudent && m.CheckOutDate.Hour >= 13 && m.CheckOutDate.Hour <= 19).OrderBy(m => m.CheckOutDate);
                    var dlLenXeCa2 = listHocSinhCa2.FirstOrDefault();
                    if (dlLenXeCa2 != null)
                    {
                        addObject.SoLuotDuaDon++;
                        addObject.TGLenXeCa2 = dlLenXeCa2.CheckOutDate;

                        // Hợp lệ khung thời gian
                        if (addObject.TGLenXeCa2 != null)
                        {
                            var ticLenXeCa2 = TIT.Core.Utilities.DateTimeToUnixTimestamp(addObject.TGLenXeCa2 ?? DateTime.Now);
                            var IsHopLe = listCa.Any(m => m.RealTimeStart <= ticLenXeCa2 && ticLenXeCa2 <= m.RealTimeEnd);
                            if (IsHopLe)
                            {
                                addObject.HopLeCa2++;
                            }
                            else
                            {
                                addObject.TongKhongHopLe++;
                            }
                        }

                        var dlXuongXeCa2 = listHocSinhCa2.LastOrDefault(m => m.Id != dlLenXeCa2.Id && m.CheckOutDate >= dlLenXeCa2.CheckOutDate.AddMinutes(_baseSettings.MTimesMiss));
                        if (dlXuongXeCa2 != null)
                        {
                            addObject.TGXuongXeCa2 = dlXuongXeCa2.CheckOutDate;

                        }
                    }
                    addObject.TDLenXeCa1 = GetTaoDoHocSinh(addObject.TGLenXeCa1, listCa);
                    addObject.TDXuongXeCa1 = GetTaoDoHocSinh(addObject.TGXuongXeCa1, listCa);
                    addObject.TDLenXeCa2 = GetTaoDoHocSinh(addObject.TGLenXeCa2, listCa);
                    addObject.TDXuongXeCa2 = GetTaoDoHocSinh(addObject.TGXuongXeCa2, listCa);

                    if (addObject.TDLenXeCa1 != null)
                        lstToaDo.Add($"{addObject.TDLenXeCa1.y},{addObject.TDLenXeCa1.x}");
                    if (addObject.TDXuongXeCa1 != null)
                        lstToaDo.Add($"{addObject.TDXuongXeCa1.y},{addObject.TDXuongXeCa1.x}");
                    if (addObject.TDLenXeCa2 != null)
                        lstToaDo.Add($"{addObject.TDLenXeCa2.y},{addObject.TDLenXeCa2.x}");
                    if (addObject.TDXuongXeCa2 != null)
                        lstToaDo.Add($"{addObject.TDXuongXeCa2.y},{addObject.TDXuongXeCa2.x}");
                    addObject.TongHopLe = addObject.HopLeCa2 + addObject.HopLeCa1;
                    newOBject.Add(addObject);
                }

                lstToaDo = lstToaDo.Distinct().ToList();
                Dictionary<string, string> dicToaDo = lstToaDo.ToDictionary(x => x);
                var listAddressStudent = new List<AddressStudent>();
                foreach (string toado in lstToaDo)
                {
                    var dataMap = await Functions.GetLatLngOfAddress(toado, _httpClient);
                    dicToaDo[toado] = dataMap.results.FirstOrDefault().formatted_address;
                    listAddressStudent.Add(new AddressStudent { Key = toado, address_components = dataMap.results.FirstOrDefault().address_components });
                }

                foreach (var addObject in newOBject)
                {
                    string key = $"{addObject.TDLenXeCa1?.y},{addObject.TDLenXeCa1?.x}";
                    if (addObject.TDLenXeCa1 != null && dicToaDo.ContainsKey(key))
                    {
                        addObject.DDLenXeCa1 = dicToaDo[key];
                        listDiaDiem.Add(FormatDiaDiem(addObject.IdStudent,1,0, listAddressStudent.FirstOrDefault(m => m.Key == key)?.address_components));
                    }

                    key = $"{addObject.TDXuongXeCa1?.y},{addObject.TDXuongXeCa1?.x}";
                    if (addObject.TDXuongXeCa1 != null && dicToaDo.ContainsKey(key))
                    {
                        addObject.DDXuongXeCa1 = dicToaDo[key];
                        addObject.DataDiaChi = listAddressStudent.FirstOrDefault(m => m.Key == key)?.address_components;
                        listDiaDiem.Add(FormatDiaDiem(addObject.IdStudent, 1, 1, listAddressStudent.FirstOrDefault(m => m.Key == key)?.address_components));

                    }

                    key = $"{addObject.TDLenXeCa2?.y},{addObject.TDLenXeCa2?.x}";
                    if (addObject.TDLenXeCa2 != null && dicToaDo.ContainsKey(key))
                    {
                        addObject.DDLenXeCa2 = dicToaDo[key];
                        addObject.DataDiaChi = listAddressStudent.FirstOrDefault(m => m.Key == key)?.address_components;
                        listDiaDiem.Add(FormatDiaDiem(addObject.IdStudent, 2, 0, listAddressStudent.FirstOrDefault(m => m.Key == key)?.address_components));
                    }

                    key = $"{addObject.TDXuongXeCa2?.y},{addObject.TDXuongXeCa2?.x}";
                    if (addObject.TDXuongXeCa2 != null && dicToaDo.ContainsKey(key))
                    {
                        addObject.DDXuongXeCa2 = dicToaDo[key];
                        addObject.DataDiaChi = listAddressStudent.FirstOrDefault(m => m.Key == key)?.address_components;
                        listDiaDiem.Add(FormatDiaDiem(addObject.IdStudent, 2, 1, listAddressStudent.FirstOrDefault(m => m.Key == key)?.address_components));
                    }
                }
            }

            using (ExcelPackage MyExcel = new ExcelPackage(existingFile))
            {
                ExcelWorksheet MyWorksheet = MyExcel.Workbook.Worksheets[1];
                MyWorksheet.Cells["C1"].Value = lpn;
                MyWorksheet.Cells["C2"].Value = _date.ToString("dd/MM/yyyy");
                MyWorksheet.Cells["C3"].Value = $"{newOBject.Count()}/{dlVehicle.Capacity}";


                string ThoiGianHopLe = "";
                var dlHopLeCa1 = listCa.Where(m => TIT.Core.Utilities.UnixTimeStampToDateTime(m.RealTimeStart).Hour >= 5 && TIT.Core.Utilities.UnixTimeStampToDateTime(m.RealTimeStart).Hour <= 11);
                if (dlHopLeCa1.Count() > 0)
                {
                    ThoiGianHopLe += $"Ca sáng: {string.Join(",", dlHopLeCa1.Select(m => TIT.Core.Utilities.UnixTimeStampToDateTime(m.RealTimeStart).ToString("HH:mm") + " - " + TIT.Core.Utilities.UnixTimeStampToDateTime(m.RealTimeEnd).ToString("HH:mm")).ToList())}";
                }
                var dlHopLeCa2 = listCa.Where(m => TIT.Core.Utilities.UnixTimeStampToDateTime(m.RealTimeStart).Hour >= 12 && TIT.Core.Utilities.UnixTimeStampToDateTime(m.RealTimeStart).Hour <= 21);
                if (dlHopLeCa2.Count() > 0)
                {
                    ThoiGianHopLe += $"Ca chiều: {string.Join(",", dlHopLeCa2.Select(m => TIT.Core.Utilities.UnixTimeStampToDateTime(m.RealTimeStart).ToString("HH:mm") + " - " + TIT.Core.Utilities.UnixTimeStampToDateTime(m.RealTimeEnd).ToString("HH:mm")).ToList())}";
                }
                MyWorksheet.Cells["C4"].Value = ThoiGianHopLe;
                MyWorksheet.Cells["C5"].Value = $"{newOBject.Count()}";
                MyWorksheet.Cells["C6"].Value = newOBject.Sum(m => m.SoLuotDuaDon);
                MyWorksheet.Cells["C7"].Value = newOBject.Sum(m => m.TongHopLe);
                MyWorksheet.Cells["C8"].Value = newOBject.Sum(m => m.TongKhongHopLe);

                int StartRow = 13;
                int i = 0;
                int colurm = 1;
                foreach (var item in newOBject)
                {
                    MyWorksheet.Cells[StartRow + i, colurm].Value = i + 1;
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;

                    MyWorksheet.Cells[StartRow + i, colurm].Value = item.StudentName;
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;

                    MyWorksheet.Cells[StartRow + i, colurm].Value = item.SchoolName;
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;

                    MyWorksheet.Cells[StartRow + i, colurm].Value = item.ClassOfSchoolName;
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;

                    MyWorksheet.Cells[StartRow + i, colurm].Value = item.TGLenXeCa1?.ToString("HH:mm:ss");
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;

                    MyWorksheet.Cells[StartRow + i, colurm].Value = item.DDLenXeCa1??"x";
                    if(item.DDLenXeCa1 == null)
                    {
                        MyWorksheet.Cells[StartRow + i, colurm].Style.Font.Color.SetColor(Color.Red);
                    }

                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;

                    MyWorksheet.Cells[StartRow + i, colurm].Value = item.TGXuongXeCa1?.ToString("HH:mm:ss");
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;

                    MyWorksheet.Cells[StartRow + i, colurm].Value = item.DDXuongXeCa1 ?? "x";
                    if (item.DDXuongXeCa1 == null)
                    {
                        MyWorksheet.Cells[StartRow + i, colurm].Style.Font.Color.SetColor(Color.Red);
                    }
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;

                    MyWorksheet.Cells[StartRow + i, colurm].Value = item.HopLeCa1;
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;

                    MyWorksheet.Cells[StartRow + i, colurm].Value = item.TGLenXeCa2?.ToString("HH:mm:ss");
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;

                    MyWorksheet.Cells[StartRow + i, colurm].Value = item.DDLenXeCa2 ?? "x";
                    if (item.DDLenXeCa2 == null)
                    {
                        MyWorksheet.Cells[StartRow + i, colurm].Style.Font.Color.SetColor(Color.Red);
                    }
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;

                    MyWorksheet.Cells[StartRow + i, colurm].Value = item.TGXuongXeCa2?.ToString("HH:mm:ss");
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;

                    MyWorksheet.Cells[StartRow + i, colurm].Value = item.DDXuongXeCa2 ?? "x";
                    if (item.DDXuongXeCa2 == null)
                    {
                        MyWorksheet.Cells[StartRow + i, colurm].Style.Font.Color.SetColor(Color.Red);
                    }
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;

                    MyWorksheet.Cells[StartRow + i, colurm].Value = item.HopLeCa2;
                    SetBorder(MyWorksheet, StartRow + i, colurm);
                    colurm++;

                    MyWorksheet.Cells[StartRow + i, colurm].Value = item.TongHopLe;
                    SetBorder(MyWorksheet, StartRow + i, colurm);

                    i++;
                    colurm = 1;
                }

                int i2 = 0;
                int colurm2 = 17;
                var listQuan = listDiaDiem.GroupBy(m => m.TenQuan).Select(m => m.FirstOrDefault());
                var listHuyenTrongQuan = listDiaDiem.GroupBy(m => m.TenHuyen).Select(m => m.FirstOrDefault());
                var listDuong = listDiaDiem.GroupBy(m => m.TenDuong).Select(m => m.FirstOrDefault());

                foreach (var itemQuan in listQuan)
                {
                    
                    foreach (var itemHuyen in listHuyenTrongQuan.Where(m=>m.TenQuan==itemQuan.TenQuan))
                    {
                        foreach (var itemDuong in listDuong.Where(m => m.TenHuyen == itemHuyen.TenHuyen))
                        {
                            
                            MyWorksheet.Cells[StartRow + i2, colurm2].Value = i2 + 1;
                            SetBorder(MyWorksheet, StartRow + i2, colurm2);
                            colurm2++;

                            MyWorksheet.Cells[StartRow + i2, colurm2].Value = itemQuan.TenQuan;
                            SetBorder(MyWorksheet, StartRow + i2, colurm2);
                            colurm2++;

                            MyWorksheet.Cells[StartRow + i2, colurm2].Value = itemHuyen.TenHuyen;
                            SetBorder(MyWorksheet, StartRow + i2, colurm2);
                            colurm2++;

                            MyWorksheet.Cells[StartRow + i2, colurm2].Value = itemDuong.TenDuong;
                            SetBorder(MyWorksheet, StartRow + i2, colurm2);
                            colurm2++;

                            MyWorksheet.Cells[StartRow + i2, colurm2].Value = listDiaDiem.Count(m=>m.TenDuong== itemDuong.TenDuong && m.Ca==1 && m.Loai==0);
                            SetBorder(MyWorksheet, StartRow + i2, colurm2);
                            colurm2++;

                            MyWorksheet.Cells[StartRow + i2, colurm2].Value = listDiaDiem.Count(m => m.TenDuong == itemDuong.TenDuong && m.Ca == 1 && m.Loai == 1);
                            SetBorder(MyWorksheet, StartRow + i2, colurm2);
                            colurm2++;

                            MyWorksheet.Cells[StartRow + i2, colurm2].Value = listDiaDiem.Count(m => m.TenDuong == itemDuong.TenDuong && m.Ca == 2 && m.Loai == 0);
                            SetBorder(MyWorksheet, StartRow + i2, colurm2);
                            colurm2++;

                            MyWorksheet.Cells[StartRow + i2, colurm2].Value = listDiaDiem.Count(m => m.TenDuong == itemDuong.TenDuong && m.Ca == 2 && m.Loai == 1);
                            SetBorder(MyWorksheet, StartRow + i2, colurm2);
                            colurm2++;

                            colurm2 = 17;
                            i2++;
                        }
                    }
                }
                MyExcel.SaveAs(fNewFile);
            }


            string path = fNewFile.FullName;
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/x-msdownload", Path.GetFileName(path));
        }
        public DataMapModel FormatDiaDiem(int StudentId,int Ca,int Loai,List<AddressComponents> data)
        {
            try
            {
                return new DataMapModel()
                {
                    StudentId= StudentId,
                    Ca= Ca,
                    Loai = Loai,
                    TenNuoc = data.FirstOrDefault(m=>m.types.Any(x=>x== "country"))?.long_name,
                    TenThanhPho = data.FirstOrDefault(m => m.types.Any(x => x == "administrative_area_level_1"))?.long_name,
                    TenQuan = data.FirstOrDefault(m => m.types.Any(x => x == "administrative_area_level_2"))?.long_name,
                    TenHuyen = data.FirstOrDefault(m => m.types.Any(x => x == "administrative_area_level_3"))?.long_name,
                    TenDuong = data.FirstOrDefault(m => m.types.Any(x => x == "route"))?.long_name,
                    SoDuong = data.FirstOrDefault(m => m.types.Any(x => x == "street_number"))?.long_name
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static RouteModel GetTaoDoHocSinh(DateTime? date, List<StudentTripModel> listToaDo)
        {
            if (date == null) return null;
            var Ticks = TIT.Core.Utilities.DateTimeToUnixTimestamp(date ?? DateTime.Now);
            var dlGPS = listToaDo.FirstOrDefault(item => item.RealTimeStart <= Ticks && Ticks <= item.RealTimeEnd);
            if (dlGPS != null)
            {
                if (dlGPS.Route != null && dlGPS.Route.Count > 0)
                {
                    var data1 = dlGPS.Route.Where(m => m.datetime <= Ticks).OrderByDescending(m=>m.datetime);
                    //return data1;
                    var data2 = dlGPS.Route.Where(m => m.datetime >= Ticks).OrderBy(m => m.datetime).FirstOrDefault();
                    return data2;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }
        public DataMapModel XuLyDiaDiem(int StudentId,string DiaDiem,int Ca,int Loai)
        {
            try
            {
                if(string.IsNullOrEmpty(DiaDiem))
                {
                    return null;
                }
                string[] arrayDiaDiem = DiaDiem.Split(',');
                return new DataMapModel
                {
                    Loai = Loai,
                    Ca=Ca,
                    StudentId = StudentId,
                    TenNuoc = arrayDiaDiem[arrayDiaDiem.Length],
                    TenThanhPho = arrayDiaDiem.Count() >= 2 ? arrayDiaDiem[arrayDiaDiem.Length - 1] : null,
                    TenQuan = arrayDiaDiem.Count() >= 3 ? arrayDiaDiem[arrayDiaDiem.Length - 2] : null,
                    TenHuyen = arrayDiaDiem.Count() >= 4 ? arrayDiaDiem[arrayDiaDiem.Length - 3] : null,
                    TenDuong = arrayDiaDiem.Count() >= 5 ? arrayDiaDiem[arrayDiaDiem.Length - 4] : null
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
        public class DataMapModel
        {
            public int StudentId { get; set; }
            public string TenNuoc { get; set; }
            public string TenThanhPho { get; set; }
            public string TenQuan { get; set; }
            public string TenHuyen { get; set; }
            public string TenDuong { get; set; }
            public string SoDuong { get; set; }
            public int Loai { get; set;}
            public int Ca { get; set; }
        }
        public class LatLng
        {
            public double Lat { get; set; }
            public double Lng { get; set; }
        }
        public static double GetTrueColumnWidth(double width)
        {
            //DEDUCE WHAT THE COLUMN WIDTH WOULD REALLY GET SET TO
            double z = 1d;
            if (width >= (1 + 2 / 3))
            {
                z = Math.Round((Math.Round(7 * (width - 1 / 256), 0) - 5) / 7, 2);
            }
            else
            {
                z = Math.Round((Math.Round(12 * (width - 1 / 256), 0) - Math.Round(5 * width, 0)) / 12, 2);
            }

            //HOW FAR OFF? (WILL BE LESS THAN 1)
            double errorAmt = width - z;

            //CALCULATE WHAT AMOUNT TO TACK ONTO THE ORIGINAL AMOUNT TO RESULT IN THE CLOSEST POSSIBLE SETTING 
            double adj = 0d;
            if (width >= (1 + 2 / 3))
            {
                adj = (Math.Round(7 * errorAmt - 7 / 256, 0)) / 7;
            }
            else
            {
                adj = ((Math.Round(12 * errorAmt - 12 / 256, 0)) / 12) + (2 / 12);
            }

            //RETURN A SCALED-VALUE THAT SHOULD RESULT IN THE NEAREST POSSIBLE VALUE TO THE TRUE DESIRED SETTING
            if (z > 0)
            {
                return width + adj;
            }

            return 0d;
        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        private ExcelWorksheet SetBorder(ExcelWorksheet ws, int row, int col)
        {
            ws.Cells[row, col].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            ws.Cells[row, col].Style.Border.Bottom.Color.SetColor(Color.Black);
            ws.Cells[row, col].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            ws.Cells[row, col].Style.Border.Right.Color.SetColor(Color.Black);
            ws.Cells[row, col].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            ws.Cells[row, col].Style.Border.Left.Color.SetColor(Color.Black);
            ws.Cells[row, col].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            ws.Cells[row, col].Style.Border.Top.Color.SetColor(Color.Black);
            return ws;
        }
        private ExcelWorksheet SetBorder(ExcelWorksheet ws, int startRow, int StartCol, int endRow, int endCol)
        {
            ws.Cells[startRow, StartCol, endRow, endCol].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            ws.Cells[startRow, StartCol, endRow, endCol].Style.Border.Bottom.Color.SetColor(Color.Black);
            ws.Cells[startRow, StartCol, endRow, endCol].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            ws.Cells[startRow, StartCol, endRow, endCol].Style.Border.Right.Color.SetColor(Color.Black);
            ws.Cells[startRow, StartCol, endRow, endCol].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            ws.Cells[startRow, StartCol, endRow, endCol].Style.Border.Left.Color.SetColor(Color.Black);
            ws.Cells[startRow, StartCol, endRow, endCol].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            ws.Cells[startRow, StartCol, endRow, endCol].Style.Border.Top.Color.SetColor(Color.Black);
            return ws;
        }
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/x-msdownload"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}