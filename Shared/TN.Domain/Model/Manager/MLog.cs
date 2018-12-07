using System;
using System.Collections.Generic;
using System.Text;
using TN.Domain.Seedwork;

namespace TN.Domain.Model.Manager
{
    public class MLog : IAggregateRoot
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Action { get; set; }
        public string Note { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
