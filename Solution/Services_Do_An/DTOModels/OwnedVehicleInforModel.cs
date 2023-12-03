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

    public class OwnedVehicleInforModel
    {
        public int OVIId { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public string? LicenceImageLink { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public double? Cargo {  get; set; }
        public double? FuelEfficiency { get; set; }

    }
}
