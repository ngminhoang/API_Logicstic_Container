using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    [Table("Counting")]
    public class CountingModel
    { 
        public int CountingId { get; set; }
        public DateTime Date {  get; set; }
        public Double Values { get; set; }
        public bool Status { get; set; }
    }
}
