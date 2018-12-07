using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TN.Domain.Seedwork;

namespace TN.Domain.Model
{
	public class DishPrice : IAggregateRoot
    {
		public int Id { get; set; }
		[ForeignKey("Dish")]
		public int DishId { get; set; }
		public string Name { get; set; }
        public float Price { get; set; }
        public string Note { get; set; }
		public DateTime CreateDate { get; set; }
		public bool Status { get; set; }
		public virtual Dish Dish { get; set; }
	}
}
