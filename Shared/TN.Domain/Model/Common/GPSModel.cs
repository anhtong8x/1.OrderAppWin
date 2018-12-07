using System;
using System.Collections.Generic;
using System.Text;

namespace TN.Domain.Model.Common
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
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
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
    public class GPSPointModel
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public Int32 datetime { get; set; }
    }
    public class DataMapModel
    {
        public string TenNuoc { get; set; }
        public string TenThanhPho { get; set; }
        public string TenQuan { get; set; }
        public string TenHuyen { get; set; }
        public string TenDuong { get; set; }
        public string SoDuong { get; set; }
    }
    public class KeyGoogleMapModel
    {
        public int Id { get; set; }
        public string Key { get; set; }
    }
    public class AddressResponse
    {
        public List<Address> results { get; set; }
        public string status { get; set; }
    }
    public class Address
    {
        public List<AddressComponents> address_components { get; set; }
        public string formatted_address { get; set; }
        public object geometry { get; set; }
        public string placeId { get; set; }
        public List<string> types { get; set; }
    }
    public class AddressComponents
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }
    }
    public class AddressStudent
    {
        public string Key { get; set; }
        public List<AddressComponents> address_components { get; set; }
    }
}
