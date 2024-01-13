using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Do_An.DTOModels
{
    public class OrderModel2
    {
        public int OrderId { get; set; }
        public string? OrderName { get; set; }
        public int CustomerId { get; set; }
        //public int StaffIdId { get; set; }
        public int? OVIId { get; set; }
        public DateOnly? OrderedDate { get; set; }
        public DateOnly? ArrivedDate { get; set; }
        public Double? TotalAmount { get; set; }
        public Double? TotalWeight { get; set; }
        public Double? TotalMass { get; set; }
        public Double? Distance { get; set; }
        public string? ProvinceGo { get; set; }
        public string? DistrictGo { get; set; }
        public string? WardGo { get; set; }
        public string? DetailPositionGo { get; set; }
        public string? ProvinceCome { get; set; }
        public string? DistrictCome { get; set; }
        public string? WardCome { get; set; }
        public string? DetailPositionCome { get; set; }
        public int? BussinessId { get; set; }
        public bool? Status { get; set; }
    }
}
