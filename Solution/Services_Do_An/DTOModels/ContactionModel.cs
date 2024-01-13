using Repositories_Do_An.DBcontext_vs_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Do_An.DTOModels
{
    public class ContactionModel
    {
        public int ContactionId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Comntent { get; set; }
        public int? StaffId { get; set; }
        public bool? Status { get; set; }
        public bool? CheckRead { get; set; }
    }
}
