using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    [Table("Message")]
    public class Message
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessId { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("Role")]
        public int? RoleId { get; set; }
        public virtual Role role { get; set; }
        public DateTime? Date { get; set; }
        [ForeignKey("Staff")]
        public int? StaffId { get; set; }
        public virtual Staff staff { get; set; }
        public bool? Status { get; set; }
        public bool? CheckRead { get; set; }
    }
}
