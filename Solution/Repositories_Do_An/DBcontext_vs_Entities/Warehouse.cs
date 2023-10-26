using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    [Table("Warehouse")]
    public class Warehouse
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WarehouseId { get; set; }
        [StringLength(50)]
        public string? WarehouseName { get; set; }
        [StringLength(250)]
        public string? WarehouseDescription { get; set; }
        [ForeignKey("Bussiness")]
        public int BussinessId { get; set; }
        public virtual Bussiness bussiness { get; set; }
        [StringLength(50)]
        public string? Province {  get; set; }
        [StringLength(50)]
        public string? District { get; set; }
        [StringLength(50)]
        public string? Ward { get; set; }
        [StringLength(50)]
        public string? Street { get; set; }
        [StringLength(50)]
        public string? Number { get; set; }
        public bool? Status { get; set; }
    }
}
