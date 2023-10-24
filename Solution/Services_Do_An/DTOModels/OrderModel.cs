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

    public class OrderModel
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int StaffIdId { get; set; }
        public int OwnerId { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime ArrivedDate { get; set; }
        public BigInteger TotalAmount { get; set; }
        public int PostionComeId { get; set; }
        public int PostionGoId { get; set; }
        public string paymentMethod { get; set; } = "Tài xế và khách hàng tự làm việc với nhau";
        public bool Status { get; set; }
    }
}
