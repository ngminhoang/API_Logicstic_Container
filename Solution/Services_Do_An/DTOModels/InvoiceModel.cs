using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    [Table("Invoice")]
    public class InvoiceModel
    {
        public int InvoiceId { get; set; }
        public int OrderId { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public DateTime Date {  get; set; }
    }
}
