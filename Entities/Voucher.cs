using System;
using System.Collections.Generic;

namespace DoAnTKPMNC.Entities
{
    public partial class Voucher
    {
        public Voucher()
        {
            CampaignVouchers = new HashSet<CampaignVoucher>();
        }

        public int VoucherId { get; set; }
        public int? StoreId { get; set; }
        public bool? Pcent { get; set; }
        public bool? Vnd { get; set; }
        public int Value { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ImgUrl { get; set; }

        public virtual Store? Store { get; set; }
        public virtual ICollection<CampaignVoucher> CampaignVouchers { get; set; }
    }
}
