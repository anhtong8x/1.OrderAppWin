using System;
using System.Collections.Generic;

namespace TN.API.EF
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Device = new HashSet<Device>();
        }

        public int Id { get; set; }
        public int? IdRoute { get; set; }
        public string Lpn { get; set; }
        public int? Capacity { get; set; }
        public string Organization { get; set; }
        public string VehicleOwner { get; set; }
        public string Brand { get; set; }
        public int? NumOfSeat { get; set; }
        public float? Degree { get; set; }
        public float? Lat { get; set; }
        public float? Lng { get; set; }
        public int? Speed { get; set; }
        public string Note { get; set; }
        public bool? Status { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? CreatedDate { get; set; }

        public ICollection<Device> Device { get; set; }
    }
}
