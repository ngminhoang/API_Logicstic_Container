﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    [Table("Driver")]
    public class Driver : User 
    {
        public String? FrontIdentifyImageLink { get; set; }
        public String? BackIdentifyImageLink { get; set; }
        public bool? IsWorked { get; set; } = false;
    }
}
