using System;
using System.Collections.Generic;

namespace DoAnTKPMNC.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            CpVchCustomers = new HashSet<CpVchCustomer>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int AccountId { get; set; }
        public string? Email { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<CpVchCustomer> CpVchCustomers { get; set; }
    }
}
