using System;
using System.Collections.Generic;

namespace DoAnTKPMNC.Entities
{
    public partial class Account
    {
        public Account()
        {
            Customers = new HashSet<Customer>();
            Partners = new HashSet<Partner>();
        }

        public int AccountId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Partner> Partners { get; set; }
    }
}
