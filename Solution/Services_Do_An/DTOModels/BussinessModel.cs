using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    [Table("Bussiness")]
    public class BussinessModel
    {
        public int BussinessId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessLicenseNumber {  get; set; }
        public string Address { get; set; }
        public string ContactEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string BusinessWebsite {  get; set; }
        public bool CoopStatus { get; set; }
        public DateTime DateCreatedAccount { get; set; }
        public DateTime DateUpdatedAccount { get; set; }
        public int Status { get; set; }
    }
}
