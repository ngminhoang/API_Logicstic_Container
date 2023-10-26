using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{

    public class WarehouseModel
    {
        public int WarehouseId { get; set; }
        public string? WarehouseName { get; set; }
        public string? WarehouseDescription { get; set; }
        public int? BussinessId { get; set; }
        public string? Province {  get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public bool? Status { get; set; }
    }
}
