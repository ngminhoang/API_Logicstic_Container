using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    [Table("OwnedVehicleInfor")]
    public class OwnedVehicleInfor
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OVIId { get; set; }
        [ForeignKey("Driver")]
        public int DriverId { get; set; }
        public virtual Driver driver{ get; set; }
        [ForeignKey("Vihcle")]
        public int VehicleId { get; set; }
        public virtual Vehicle vehicle { get; set; }
        public string LicenceImageLink { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        public bool Status { get; set; }
        public double Cargo {  get; set; }
        public double FuelEfficiency { get; set; }

    }
}
