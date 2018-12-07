using System;
using System.Collections.Generic;

namespace TN.API.EF
{
    public partial class ClassOfSchool
    {
        public ClassOfSchool()
        {
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public int IdSchool { get; set; }
        public string Name { get; set; }

        public ICollection<Student> Student { get; set; }
    }
}
