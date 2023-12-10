using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    [Table("Contaction")]
    public class Contaction
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactionId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Comntent { get; set; }
        [ForeignKey("Staff")]
        public int? StaffId { get; set; }
        public Staff staff { get; set; }
        public bool? Status { get; set; }
        public bool? CheckRead { get; set; }
    }
}
