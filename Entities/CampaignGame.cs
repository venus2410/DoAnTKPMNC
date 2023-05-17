using System;
using System.Collections.Generic;

namespace DoAnTKPMNC.Entities
{
    public partial class CampaignGame
    {
        public int CampaignGameId { get; set; }
        public int? GameId { get; set; }
        public int? CampaignId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Campaign CampaignGameNavigation { get; set; } = null!;
        public virtual Game? Game { get; set; }
    }
}
