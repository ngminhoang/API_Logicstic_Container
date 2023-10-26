using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    [Table("OrderStatus")]
    public class OrderStatus
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderStatusId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order order { get; set; }
        public DateTime? Date { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set;}
        public virtual Status status { get; set; }
        public bool? Status { get; set; }
    }
}
