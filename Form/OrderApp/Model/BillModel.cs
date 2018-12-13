using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Model
{
	public class BillModel
	{
		public int Id { get; set; }
		public int CashierId { get; set; }
		public string CashierName { get; set; }
		public int WaitersId { get; set; }
		public string WaiterName { get; set; }
		public bool Paid { get; set; }
		public float Money { get; set; }
		public DateTime CreateDate { get; set; }
		public string Note { get; set; }
		public int TableId { get; set; }
	}
}
