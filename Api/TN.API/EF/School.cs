using System;
using System.Collections.Generic;

namespace TN.API.EF
{
    public partial class School
    {
        public School()
        {
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }

        public ICollection<Student> Student { get; set; }
    }
}
