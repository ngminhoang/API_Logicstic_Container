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
    public class OrderStatusModel
    {
        public int OrderStatusId { get; set; }
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int StatusId { get; set;}
        public bool Status { get; set; }
    }
}
