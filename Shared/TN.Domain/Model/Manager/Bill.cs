using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TN.Domain.Seedwork;

namespace TN.Domain.Model.Manager
{
    public class Bill : IAggregateRoot
    {
		public int Id { get; set; }
		public int CashierId { get; set; }
		public string CashierName { get; set; }
		public int WaitersId { get; set; }
		public string WaiterName { get; set; }
		[DefaultValue("false")]
		public bool Paid { get; set; }
		public float Money { get; set; }
		[DefaultValue("DateTime.Now")]
		public DateTime CreateDate { get; set; }
		public string Note { get; set; }
		[ForeignKey("Table")]
		public int TableId { get; set; }
		public virtual Table Table { get; set; }
	}
    public class BillModel
	{
		public int Id { get; set; }
		public int CashierId { get; set; }
		public string CashierName { get; set; }
		public int WaitersId { get; set; }
		public string WaiterName { get; set; }
		[DefaultValue("false")]
		public bool Paid { get; set; }
		public float Money { get; set; }
		[DefaultValue("DateTime.Now")]
		public DateTime CreateDate { get; set; }
		public string Note { get; set; }		
		public int TableId { get; set; }
	}
}
