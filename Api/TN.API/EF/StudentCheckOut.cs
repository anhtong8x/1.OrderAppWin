using System;
using System.Collections.Generic;

namespace TN.API.EF
{
    public partial class StudentCheckOut
    {
        public int Id { get; set; }
        public int IdFinger { get; set; }
        public int? IdDevice { get; set; }
        public int IdStudent { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public Device IdDeviceNavigation { get; set; }
        public Student IdStudentNavigation { get; set; }
    }
}
