using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TN.API.Models
{
    public class ValueTripsModel
    {
        public DModel D { get; set; }
    }
    public class DModel
    {
        public List<StudentTripModel> Result { get; set; }
        public object Id { get; set; }
        public object Exception { get; set; }
        public object Status { get; set; }
        public object IsCanceled { get; set; }
        public object IsCompleted { get; set; }
        public object CreationOptions { get; set; }
        public object AsyncState { get; set; }
        public object IsFaulted { get; set; }
    }

    public class StudentTripModel
    {
        public object __type { get; set; }
        public object _id { get; set; }
        public string VehiclePlate { get; set; }
        public int PlanTimeStart { get; set; }
        public int PlanTimeEnd { get; set; }
        public Int32 RealTimeStart { get; set; }
        public Int32 RealTimeEnd { get; set; }
        public bool IsGo { get; set; }
        public int GroupId { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public int CustomerCount { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLostTrip { get; set; }
        public int Status { get; set; }
        public int SchoolId { get; set; }
        public string SchoolCode { get; set; }
        public string SchoolName { get; set; }
        public string SchoolLocation { get; set; }
        public double Distance { get; set; }
        public string UserName { get; set; }
        public object Comment { get; set; }
        public List<RouteModel> Route { get; set; }
    }
    public class RouteModel
    {
        public object __type { get; set; }
        public object _id { get; set; }
        public string vehicle { get; set; }
        public string driver { get; set; }
        public double speed { get; set; }
        public Int32 datetime { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public double heading { get; set; }
        public bool ignition { get; set; }
        public bool aircon { get; set; }
        public bool door_up { get; set; }
        public bool door_down { get; set; }
        public bool sos { get; set; }
        public bool working { get; set; }
        public double analog1 { get; set; }
        public double analog2 { get; set; }
    }
}
