using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Repositories_Do_An.DBcontext_vs_Entities
{
    
    public class UserModel
    {
        public String AvatarImageLink { get; set; }
        public int UserId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly Birthday { get; set; }
        public bool Gender { get; set; }
        public string FullName { get; set; }
        public DateTime DateCreatedAccount { get; set; }
        public DateTime DateUpdatedAccount { get; set; }
        public int RoleId { get; set; }
        public bool Status { get; set; }
    }
}
