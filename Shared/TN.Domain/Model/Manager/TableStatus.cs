using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TN.Domain.Seedwork;

namespace TN.Domain.Model
{
	public class TableStatus : IAggregateRoot
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Note { get; set; }
	}

	public class TableStatusModel
	{
		public int Id { get; set; }
		[Required]
		[StringLength(200, MinimumLength = 1)]
		public string Name { get; set; }
		public string Note { get; set; }
	}
}
