using System;
using System.Collections.Generic;

namespace TN.API.EF
{
    public partial class Student
    {
        public Student()
        {
            StudentCheckOut = new HashSet<StudentCheckOut>();
        }

        public int Id { get; set; }
        public int? IdSchool { get; set; }
        public int? IdClassOfSchool { get; set; }
        public int? IdRouter { get; set; }
        public string StudentName { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? Disable { get; set; }
        public int? Sex { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int IdFinger1 { get; set; }
        public int IdFinger2 { get; set; }
        public string FingerTemplate1 { get; set; }
        public string FingerTemplate2 { get; set; }
        public int? Finger1UpdatedUser { get; set; }
        public int? Finger2UpdatedUser { get; set; }
        public DateTime? Finger1UpdatedDate { get; set; }
        public DateTime? Finger2UpdatedDate { get; set; }
        public bool? Unlimited { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedUser { get; set; }

        public ClassOfSchool IdClassOfSchoolNavigation { get; set; }
        public Route IdRouterNavigation { get; set; }
        public School IdSchoolNavigation { get; set; }
        public ICollection<StudentCheckOut> StudentCheckOut { get; set; }
    }
}
