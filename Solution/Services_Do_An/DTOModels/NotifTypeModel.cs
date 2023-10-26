using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
 
    public class NotifTypeModel
    {
        public int NotifTypeId { get; set; }
        public string? NotifName { get; set;}
        public string? NotifDescription { get; set;}
        public string? Title { get; set;}
        public bool? Status { get; set; }   
    }
}
