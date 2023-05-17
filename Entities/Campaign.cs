using System;
using System.Collections.Generic;

namespace DoAnTKPMNC.Entities
{
    public partial class Campaign
    {
        public Campaign()
        {
            CampaignVouchers = new HashSet<CampaignVoucher>();
        }

        public int CampaignId { get; set; }
        public string? CpDescrip { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? PartnerId { get; set; }
        public int? MaxTimePaticipant { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Partner? Partner { get; set; }
        public virtual CampaignGame? CampaignGame { get; set; }
        public virtual ICollection<CampaignVoucher> CampaignVouchers { get; set; }
    }
}
