using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    [Table("NotifType")]
    public class NotifType
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotifTypeId { get; set; }
        [StringLength(50)]
        public string? NotifName { get; set;}
        [StringLength(250)]
        public string? NotifDescription { get; set;}
        [StringLength(100)]
        public string? Title { get; set;}
        public bool? Status { get; set; }
    }
}
