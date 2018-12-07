using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TN.API.EF;
using TN.API.Models;

namespace TN.API.Controllers
{
    [Produces("application/json")]
    [Route("api/StudentTrecking")]
    public class StudentTreckingController : Controller
    {
        private readonly TNFingerContext db;
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        public StudentTreckingController(TNFingerContext context, ILogger<StudentTreckingController> logger)
        {
            db = context;
            _logger = logger;
        }
        [HttpGet("{lpn}/{startTime}/{endTime}")]
        public async Task<ApiResponseModel> Get(string lpn, string startTime, string endTime)
        {
            try
            {
                var _startTime = Convert.ToDateTime(startTime.Replace("-", "/"));
                var _endTime = Convert.ToDateTime(endTime.Replace("-", "/"));

                var newList = new List<object>();
                var listHeckout = await db.StudentCheckOut.Where(m => m.CheckOutDate >= _startTime && m.CheckOutDate <= _endTime && m.IdDeviceNavigation.IdVehicleNavigation.Lpn== lpn)
                    .Select(x => new {
                        x.Id,
                        student = new
                        {
                            x.IdStudent,
                            x.IdStudentNavigation.StudentName,
                            ClassOfSchool = x.IdStudentNavigation.IdClassOfSchoolNavigation.Name,
                            School = x.IdStudentNavigation.IdSchoolNavigation.Name
                        },
                        date = x.CheckOutDate
                    }).ToListAsync();
                listHeckout = listHeckout.OrderBy(m => m.date).ToList();
                var listStudent = listHeckout.GroupBy(m => m.student.IdStudent).Select(x => x.FirstOrDefault()).ToList();
                foreach (var item in listStudent)
                {
                    var dataLenXe = listHeckout.Where(m=>m.student.IdStudent==item.student.IdStudent).OrderBy(m=>m.date).FirstOrDefault();
                    if (dataLenXe != null)
                    {
                        newList.Add(new
                        {
                            dataLenXe.Id,
                            dataLenXe.student,
                            date = dataLenXe.date.ToString("dd-MM-yyyy HH:mm:ss"),
                            Direction = 0,
                            Type = 0
                        });
                        var dataXuongXe = listHeckout.Where(m => m.student.IdStudent == item.student.IdStudent&& m.Id != dataLenXe.Id && m.date >= dataLenXe.date.AddMinutes(3)).OrderBy(m => m.date).LastOrDefault();
                        if (dataXuongXe != null)
                        {
                            newList.Add(new
                            {
                                dataXuongXe.Id,
                                dataXuongXe.student,
                                date = dataXuongXe.date.ToString("dd-MM-yyyy HH:mm:ss"),
                                Direction = 0,
                                Type = 1
                            });
                        }
                    }
                }
                return new ApiResponseModel
                {
                    Data = newList
                };
            }
            catch
            {
                return new ApiResponseModel
                {
                    Status = false
                };
            }
        }
        [HttpGet("StudentCount/{lpn}/{startTime}/{endTime}")]
        public async Task<int> StudentCount(string lpn, string startTime, string endTime)
        {
            try
            {
                var _startTime = Convert.ToDateTime(startTime.Replace("-", "/"));
                var _endTime = Convert.ToDateTime(endTime.Replace("-", "/"));

                var newList = new List<object>();
                var listHeckout = await db.StudentCheckOut.Where(m => m.CheckOutDate >= _startTime && m.CheckOutDate <= _endTime && m.IdDeviceNavigation.IdVehicleNavigation.Lpn==lpn)
                    .Select(x => new {
                        x.Id,
                        student = new
                        {
                            x.IdStudent,
                            ClassOfSchool = x.IdStudentNavigation.IdClassOfSchoolNavigation.Name
                        },
                        date = x.CheckOutDate
                    }).ToListAsync();
                listHeckout = listHeckout.OrderBy(m => m.date).ToList();
                var listStudent = listHeckout.GroupBy(m => m.student.IdStudent).Select(x => x.FirstOrDefault());
                return listStudent.Count();
            }
            catch
            {
                return 0;
            }
        }
        //[HttpGet("{lpn}/{startTime}/{endTime}")]
        //public async Task<ApiResponseModel> Get(string lpn, string startTime, string endTime)
        //{
        //    try
        //    {
        //        var _startTime = Convert.ToDateTime(startTime.Replace("-", "/"));
        //        var _endTime = Convert.ToDateTime(endTime.Replace("-", "/"));

        //        var newList = new List<object>();
        //        var listHeckout =await  db.StudentCheckOut.Where(m => m.CheckOutDate >= _startTime && m.CheckOutDate <= _endTime && db.Device.Any(x => x.IdVehicleNavigation.Lpn == lpn))
        //            .Select(x => new {
        //                                x.Id,
        //                                student = new
        //                                {
        //                                    x.IdStudent,
        //                                    x.IdStudentNavigation.StudentName,
        //                                    ClassOfSchool = x.IdStudentNavigation.IdClassOfSchoolNavigation.Name,
        //                                    School = x.IdStudentNavigation.IdSchoolNavigation.Name
        //                                },
        //                                date = x.CheckOutDate
        //                             }).ToListAsync();
        //        var listStudent = listHeckout.GroupBy(m => m.student.IdStudent).Select(x => x.FirstOrDefault()).ToList();
        //        foreach (var item in listStudent)
        //        {
        //            var listLenXe = listHeckout.Where(m => m.student.IdStudent == item.student.IdStudent && m.date.Hour >= 6 && m.date.Hour <= 11).OrderBy(m => m.date).ToList();
        //            var dataLenXe = listLenXe.FirstOrDefault();
        //            if (dataLenXe != null)
        //            {
        //                newList.Add(new
        //                {
        //                    dataLenXe.Id,
        //                    dataLenXe.student,
        //                    date = dataLenXe.date.ToString("dd-MM-yyyy HH:mm:ss"),
        //                    Direction = 0,
        //                    Type = 0
        //                });
        //                var dataXuongXe = listLenXe.Where(m => m.Id != dataLenXe.Id && m.date >= dataLenXe.date.AddMinutes(3)).OrderBy(m => m.date).LastOrDefault();
        //                if (dataXuongXe != null)
        //                {
        //                    newList.Add(new
        //                    {
        //                        dataXuongXe.Id,
        //                        dataXuongXe.student,
        //                        date = dataXuongXe.date.ToString("dd-MM-yyyy HH:mm:ss"),
        //                        Direction = 0,
        //                        Type = 1
        //                    });
        //                }
        //            }
        //            // Lượt về
        //            var listLuotVe = listHeckout.Where(m => m.student.IdStudent == item.student.IdStudent && m.date.Hour >= 12 && m.date.Hour <= 22).OrderBy(m => m.date);
        //            var dataVeLenXe = listLuotVe.FirstOrDefault();
        //            if (dataVeLenXe != null)
        //            {
        //                newList.Add(new
        //                {
        //                    dataVeLenXe.Id,
        //                    dataVeLenXe.student,
        //                    date=dataVeLenXe.date.ToString("dd-MM-yyyy HH:mm:ss"),
        //                    Direction = 1,
        //                    Type = 0
        //                });
        //                var dataXuongXe = listLuotVe.Where(m => m.Id != dataVeLenXe.Id && m.date >= dataVeLenXe.date.AddMinutes(3)).OrderBy(m => m.date).LastOrDefault();
        //                if (dataXuongXe != null)
        //                {
        //                    newList.Add(new
        //                    {
        //                        dataXuongXe.Id,
        //                        dataXuongXe.student,
        //                        date = dataXuongXe.date.ToString("dd-MM-yyyy HH:mm:ss"),
        //                        Direction = 1,
        //                        Type = 1
        //                    });
        //                }
        //            }
        //        }
        //        return new ApiResponseModel
        //        {
        //            Data = newList
        //        };
        //    }
        //    catch
        //    {
        //        return new ApiResponseModel
        //        {
        //            Status = false
        //        };
        //    }
        //}
    }
}