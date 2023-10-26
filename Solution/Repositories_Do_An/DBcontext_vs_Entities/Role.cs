using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    [Table("Role")]
    public  class Role
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId {  get; set; }
        [StringLength(50)]
        public string? RoleName { get; set; }
        public bool? Status { get; set; }
    }
}
