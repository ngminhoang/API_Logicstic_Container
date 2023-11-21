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
        public string? OrderName { get; set; }
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public virtual Customer customer { get; set; }
        [ForeignKey("OwnedVehicleInfor")]
        public int? OVIId { get; set; }
        public virtual OwnedVehicleInfor ownedVehicleInfor { get; set; }

        public DateOnly? OrderedDate { get; set; }
        public DateOnly? ArrivedDate { get; set; }
        public Double? TotalAmount { get; set; }


        public string? ProvinceGo { get; set; }
        public string? DistrictGo { get; set; }
        public string? WardGo { get; set; }
        public string? DetailPositionGo { get; set; }
        public string? ProvinceCome { get; set; }
        public string? DistrictCome { get; set; }
        public string? WardCome { get; set; }
        public string? DetailPositionCome { get; set; }

        [ForeignKey("Bussiness")]

        public int? BussinessId {  get; set; }
        public virtual Bussiness bussiness {  get; set; }
        //public string paymentMethod { get; set; } = "Tài xế và khách hàng tự làm việc với nhau";
        public bool? Status { get; set; }
    }
}
