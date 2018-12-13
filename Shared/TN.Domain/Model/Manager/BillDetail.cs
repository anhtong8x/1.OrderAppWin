using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TN.Domain.Seedwork;

namespace TN.Domain.Model.Manager
{
	public class BillDetail : IAggregateRoot
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string UseName { get; set; }
		public int DishId { get; set; }
		public string DishName { get; set; }
		public float Price { get; set; }
		public int Quanity { get; set; }
		public DateTime dateTime { get; set; }
		public bool Status { get; set; }
		public string Note { get; set; }
		[ForeignKey("Bill")]
		public int BillId { get; set; }
		public virtual Bill Bill { get; set; }
	}

	public class BillDetailModel {
		public int Id { get; set; }
		public int UserId { get; set; }
		public string UseName { get; set; }
		public int DishId { get; set; }
		public string DishName { get; set; }
		public float Price { get; set; }
		public int Quanity { get; set; }
		public DateTime dateTime { get; set; }
		public bool Status { get; set; }
		public string Note { get; set; }
		public int BillId { get; set; }
	}
}
