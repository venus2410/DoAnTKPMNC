using System;
using System.Collections.Generic;

namespace DoAnTKPMNC.Entities
{
    public partial class Partner
    {
        public Partner()
        {
            Campaigns = new HashSet<Campaign>();
            Stores = new HashSet<Store>();
        }

        public int PartnerId { get; set; }
        public string? PhoneNumber { get; set; }
        public int AccountId { get; set; }
        public string? PartnerName { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<Campaign> Campaigns { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
