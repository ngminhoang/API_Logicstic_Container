using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
 
    public class ContractModel
    {
        public int ContractId { get; set; }
        public string? ContractFileLink {  get; set; }
        public int CustomerId { get; set; }
        public int? DeliveryId { get; set; }
        public int RoleId { get; set; }
        public int ContractTypeId { get; set; }
        public bool? Status { get; set; }
    }
}
