using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{

    public class AppRateModel
    {
       
        public int RateId { get; set; }
        public int? Rate { get; set; }
        public String? Commnent { get; set; }
        public int? UserId { get; set; }
        public DateTime? CommentDate { get; set; }
        public int? RoleId { get; set; }
        public bool? Status { get; set; }
    }
}
