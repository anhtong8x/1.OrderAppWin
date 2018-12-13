using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Model
{
	public class BillDetailModel
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string UserName { get; set; }
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
