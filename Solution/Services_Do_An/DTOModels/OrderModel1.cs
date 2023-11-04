using Repositories_Do_An.DBcontext_vs_Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Do_An.DTOModels
{
    public class OrderModel1
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public virtual Customer customer { get; set; }
        public int? OVIId { get; set; }
        public virtual OwnedVehicleInfor ownedVehicleInfor { get; set; }

        public DateTime? OrderedDate { get; set; }
        public DateTime? ArrivedDate { get; set; }
        public Double? TotalAmount { get; set; }
        public int? PostionComeId { get; set; }
        public int? PostionGoId { get; set; }
        [ForeignKey("Bussiness")]

        public int? BussinessId { get; set; }
        public virtual Bussiness bussiness { get; set; }
        public bool? Status { get; set; }
    }
}
