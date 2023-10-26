using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    [Table("Notification")]
    public class Notification
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotificationId { get; set; }
        [StringLength(250)]
        public string? Content { get; set; }
        [ForeignKey("NotifType")]
        public int NotifTypeId { get; set; }
        public virtual NotifType notifType { get; set; }
        public DateTime? Date { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public virtual Role role { get; set; }
        public bool? Status {  get; set; }
    }
}
