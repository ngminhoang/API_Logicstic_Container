using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
   
    public class NotificationModel
    {
        public int NotificationId { get; set; }
        public string? Content { get; set; }
        public int NotifTypeId { get; set; }
        public DateTime? Date { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public bool? Status {  get; set; }
    }
}
