using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    [Table("WishedAcceptedDriverList")]
    public class WishedAcceptedDriverList
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WADLId { get; set; }
        /// </summary>
        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        public virtual Order order { get; set; }
        public bool? Status { get; set; }
        [ForeignKey("OwnedVehicleInfor")]
        public int? OVIId { get; set; }
        public virtual OwnedVehicleInfor ownedVehicleInfor { get; set; }  //=> lỗi không taọ đươc khóa ngoai jtheo ý phải dùng one creating

    }
}
