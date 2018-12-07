using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TN.Domain.Seedwork;

namespace TN.Domain.Model
{
    public enum LogStatus
    {
        Data,
        Default
    }
    public enum LogType
    {
        [Display(Name = "Trung bình")]
        Normal,
        [Display(Name = "Cao")]
        Warning,
        [Display(Name = "Rất cao")]
        Danger
    }
    public enum LogCustomObject
    {
        Default = 0,
        VehicleRegistryEndDate = 1,
        VehicleUnderwriteEndDate = 2,
        VehicleContractEndDate = 3,
        VehicleUpdateDeviceGPS = 4,
        VehicleChangeTransportCompany = 5,
        VehicleChangeRoute = 6,
        VehicleChangeSchool = 7
    }
    public class Log : IAggregateRoot
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Action { get; set; }
        public double Note { get; set; }
        [MaxLength(50)]
        public string Object { get; set; }
        public int ObjectId { get; set; }
        [MaxLength(50)]
        public string ObjectType { get; set; }
        public long Timestamp { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SystemUser { get; set; }
        public int SystemUserId { get; set; }
        public string ValueBefore { get; set; }
        public string ValueAfter { get; set; }
        public LogType Type { get; set; }
        public LogStatus Status { get; set; }
        public LogCustomObject CustomObject { get; set; }
    }
    public class BaseLogDataModel<T> where T : class
    {
        public T DataBefore { get; set; }
        public T DataAfter { get; set; }
    }
    public class BaseLogModel<T> where T : class
    {
        public T DataBefore { get; set; }
        public T DataAfter { get; set; }
        public Log Log { get; set; }
    }
    public class WriteLogModel
    {
        //string name,int objectId,object valueBefore, object valueAfter, string table=null
        public string Name { get; set; }
        public int ObjectId { get; set; }
    }
    public class LogModel
    {
        public string Action { get; set; }
        public string ControllerName { get; set; }
        public int ObjectId { get; set; }
        public string TableName { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime CreatedDate { get; set; }
        public object ValueBefore
        {
            set
            {
                if (value == null)
                {
                    StrValueBefore = null;
                }
                else
                {
                    string json = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    StrValueBefore = json;
                }
            }
        }
        public object ValueAfter
        {
            set
            {
                if (value == null)
                {
                    StrValueAfter = null;
                }
                else
                {
                    string json = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    StrValueAfter = json;
                }
            }
        }
        public LogType Type { get; set; } = LogType.Normal;
        public LogStatus Status { get; set; } = LogStatus.Data;
        public string StrValueBefore { get; set; }
        public string StrValueAfter { get; set; }
        public LogCustomObject CustomObject { get; set; }
    }
    public class LogUserModel
    {
        public int UserId { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
