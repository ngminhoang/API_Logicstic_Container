using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    [Table("Vihcle")]
    public class Vihcle
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VihcleId { get; set; }
        [StringLength(50)]
        public String VihcleName { get; set; }
        [Range(3,100)]
        public int Cicle {  get; set; }
        public bool Status { get; set; }

    }
}
