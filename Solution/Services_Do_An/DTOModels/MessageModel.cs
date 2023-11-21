using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
   
    public class MessageModel
    {
        public int MessId { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime? Date { get; set; }
        public int StaffId { get; set; }
        public bool? Status { get; set; }
        public bool? CheckRead { get; set; }
    }
}
