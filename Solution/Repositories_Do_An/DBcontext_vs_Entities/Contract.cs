using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    [Table("Contract")]
    public class Contract
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractId { get; set; }
        public string ContractFileLink {  get; set; }
        [ForeignKey("Cusustomer")]
        public int CustomerId { get; set; }
        public virtual Customer customer { get; set; }
        [ForeignKey("DriverId")]
        public int DriverId { get; set; }
        public virtual Driver driver { get; set; }
        [ForeignKey("ContractType")]
        public int ContractTypeId { get; set; }
        public virtual ContractType contractType { get; set; }
        public bool Status { get; set; }
    }
}
