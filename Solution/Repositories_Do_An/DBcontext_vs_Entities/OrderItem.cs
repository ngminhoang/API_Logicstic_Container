using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    [Table("OrderItem")]
    public class OrderItem
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemId { get; set; }
        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        public Order order { get; set; }
        [StringLength(50)]
        public string? ItemName { get; set; }
        public int? Quantity { get; set; }
        public double? MassPerUnit { get; set; }
        public double? WeightPerUnit { get; set; }
        public double? PricePerUnit { get; set; }
        [StringLength(250)]
        public string? ItemDescription { get; set; }
        [StringLength(50)]
        public string? ItemImage { get; set; }
        public bool? Status { get; set; }
    }
}
