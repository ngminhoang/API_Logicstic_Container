using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Repositories_Do_An.DBcontext_vs_Entities
{

    public  class Comment_DriverModel
    {
        public DriverModel driver { set; get; }
        public List<DriverRateModel> driverRateList { set; get; }
    }
}
