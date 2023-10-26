using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    public class ContractTypeModel
    {
        public int ContractTypeId { get; set; }
        public string? text { get; set; }
        public bool? Status { get; set; }
    }
}
