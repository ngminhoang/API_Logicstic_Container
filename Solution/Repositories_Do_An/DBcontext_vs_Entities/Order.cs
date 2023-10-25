using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    [Table("Order")]
    public class Order
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer customer { get; set; }


        //[ForeignKey("Staff")]
        //public int? StaffId { get; set; }
        //public virtual Staff staff { get; set; }


        [ForeignKey("OwnedVehicleInfor")]
        public int? OVIId { get; set; }
        public virtual OwnedVehicleInfor ownedVehicleInfor { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime ArrivedDate { get; set; }
        public BigInteger? TotalAmount { get; set; }



        public int PostionComeId { get; set; }


        public int PostionGoId { get; set; }


        //public string paymentMethod { get; set; } = "Tài xế và khách hàng tự làm việc với nhau";
        public bool Status { get; set; }
    }
}
