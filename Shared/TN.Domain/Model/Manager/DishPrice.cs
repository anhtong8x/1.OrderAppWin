using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TN.Domain.Seedwork;

namespace TN.Domain.Model.Manager
{
    public class DishPrice : IAggregateRoot
    {
        public int Id { get; set; }
        [ForeignKey("Dish")]
        public int DishId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Note { get; set; }
        [DefaultValue("DateTime.Now")]
        public DateTime Date { get; set; }
        [DefaultValue("false")]
        public bool Status { get; set; }
        public virtual Dish Dish { get; set; }
    }

    public class DishPriceModel
    {
        public int Id { get; set; }
        [ForeignKey("Dish")]
        public int DishId { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Name { get; set; }
        public float Price { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public virtual Dish Dish { get; set; }
    }
}
