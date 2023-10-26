using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{

    public  class RoleModel
    {
        public int RoleId {  get; set; }
        public string? RoleName { get; set; }
        public bool? Status { get; set; }
    }
}
