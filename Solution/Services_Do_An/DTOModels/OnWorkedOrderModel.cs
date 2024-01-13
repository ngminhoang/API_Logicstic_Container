using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories_Do_An.DBcontext_vs_Entities;

namespace Services_Do_An.DTOModels
{
    public class OnWorkedOrderModel
    {
        public Order order { set; get; }
        public List<OrderStatus> status { set; get; }
        public int newStatus { get; set; }
    }
}
