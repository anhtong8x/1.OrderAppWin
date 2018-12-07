using System;
using System.Collections.Generic;

namespace TN.API.EF
{
    public partial class Device
    {
        public Device()
        {
            StudentCheckOut = new HashSet<StudentCheckOut>();
        }

        public int Id { get; set; }
        public int IdRoute { get; set; }
        public int IdVehicle { get; set; }
        public string Name { get; set; }
        public string Imei { get; set; }
        public bool Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedUser { get; set; }

        public Route IdRouteNavigation { get; set; }
        public Vehicle IdVehicleNavigation { get; set; }
        public ICollection<StudentCheckOut> StudentCheckOut { get; set; }
    }
}
