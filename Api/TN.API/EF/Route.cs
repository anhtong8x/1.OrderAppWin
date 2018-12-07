using System;
using System.Collections.Generic;

namespace TN.API.EF
{
    public partial class Route
    {
        public Route()
        {
            Device = new HashSet<Device>();
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double? TotalDistance { get; set; }

        public ICollection<Device> Device { get; set; }
        public ICollection<Student> Student { get; set; }
    }
}
