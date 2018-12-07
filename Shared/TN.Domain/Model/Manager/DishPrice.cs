using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TN.Domain.Model
{
	public class DishPrice
	{
		public int Id { get; set; }
		[ForeignKey("Dish")]
		public int DishId { get; set; }
		public string Name { get; set; }
		public string Note { get; set; }
		public DateTime Date { get; set; }
		public bool Status { get; set; }
		public virtual Dish Dish { get; set; }
	}
}
