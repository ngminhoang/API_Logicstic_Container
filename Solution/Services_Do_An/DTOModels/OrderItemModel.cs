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
   
    public class OrderItemModel
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double MassPerUnit { get; set; }
        public double weightPerUnit { get; set; }
        public double PricePerUnit { get; set; }
        public int ItemDescription { get; set; }
        public int ItemImage { get; set; }
        public bool Status { get; set; }
    }
}
