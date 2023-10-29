using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    [Table("Bussiness")]
    public class Bussiness
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BussinessId { get; set; }
        [StringLength(50),Required]
        public string? BusinessName { get; set; }
        [StringLength(20),Required]
        public string? BusinessLicenseNumber {  get; set; }
        [StringLength(50), Required]
        public string? BussinessPassword { get; set; }
        [StringLength(50),Required]
        public string? Address { get; set; }
        [StringLength(30), Required]
        public string? ContactEmail { get; set; }
        [StringLength(10), RegularExpression(@"\d")]
        public string? PhoneNumber { get; set; }
        public string? BusinessWebsite {  get; set; }
        public bool? CoopStatus { get; set; }
        public DateTime? DateCreatedAccount { get; set; }
        public DateTime? DateUpdatedAccount { get; set; }
        public bool? Status { get; set; }
        [ForeignKey("Role")]
        public int? RoleId { get; set; }
        public virtual Role role { get; set; }
    }
}
