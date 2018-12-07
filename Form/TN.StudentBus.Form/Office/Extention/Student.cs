namespace TN.StudentBus.Office.Extention
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class StudentModel
    {
        public enum StudentSex
        {
            Orthe = -1,
            Female = 0,
            Male = 1
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public int? SchoolId { get; set; }
        public int? ClassOfSchoolId { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public bool Status { get; set; }
        public StudentSex Sex { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Finger1Id { get; set; }
        public int Finger2Id { get; set; }
        public string FingerTemplate1 { get; set; }
        public string FingerTemplate2 { get; set; }
        public int? Finger1UpdatedUser { get; set; }
        public int? Finger2UpdatedUser { get; set; }
        public DateTime? Finger1UpdatedDate { get; set; }
        public DateTime? Finger2UpdatedDate { get; set; }
        public string Note { get; set; }
        public bool? Unlimited { get; set; }
        public bool IsDelete { get; set; } = false;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ClassOfSchoolModel ClassOfSchool { get; set; }
        public virtual SchoolModel School { get; set; }
    }
}
