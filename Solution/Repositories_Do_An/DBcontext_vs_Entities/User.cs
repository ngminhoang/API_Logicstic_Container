using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    
    public class User
    {
        public String? AvatarImageLink { get; set; }
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [StringLength(50)]
        public string? Password { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        [StringLength(50)]
        public string? Address { get; set; }
        [StringLength(10), Required, RegularExpression(@"\d")]
        public string? PhoneNumber { get; set; }
        public DateOnly? Birthday { get; set; }
        public bool? Gender { get; set; }
        [StringLength(50)]
        public string? FullName { get; set; }
        public DateTime? DateCreatedAccount { get; set; }
        public DateTime? DateUpdatedAccount { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public virtual Role role { get; set; }
        public bool? Status { get; set; }
    }
}
