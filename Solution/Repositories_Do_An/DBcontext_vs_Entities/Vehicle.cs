using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    [Table("Vehicle")]
    public class Vehicle
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleId { get; set; }
        [StringLength(50)]
        public String? VehicleName { get; set; }
        [Range(3,100)]
        public int? Wheel {  get; set; }
        public bool? Status { get; set; }

    }
}
