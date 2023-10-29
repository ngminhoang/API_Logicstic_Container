using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    [Table("DriverRate")]
    public class DriverRate
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RateId { get; set; }
        public int? Rate {  get; set; }
        [StringLength(250)]
        public String? Commnent { get; set; }
        [ForeignKey("Driver")]
        public int? DriverId { get; set; }
        public virtual Driver driver { get; set; }
        public DateTime? CommentDate { get; set; }
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public virtual Customer customer { get; set; }
        public bool? Status { get; set; }
        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        public virtual Order order { get; set; }
    }
}
