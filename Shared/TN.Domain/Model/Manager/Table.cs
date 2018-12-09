using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TN.Domain.Seedwork;

namespace TN.Domain.Model.Manager
{
    public class Table : IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }
    }

    public class TableModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Name { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }
    }
}
