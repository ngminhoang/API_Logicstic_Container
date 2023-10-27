using Repositories_Do_An.DBcontext_vs_Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Do_An.DTOModels
{
    public class WishedAcceptedDriverListModel
    {
        public int WADLId { get; set; }
        public int OrderId { get; set; }
        public int OVIId { get; set; }
        public bool Status { get; set; }
    }
}
