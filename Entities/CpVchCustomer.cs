using System;
using System.Collections.Generic;

namespace DoAnTKPMNC.Entities
{
    public partial class CpVchCustomer
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? CpVchId { get; set; }
        public DateTime? PaticipantDate { get; set; }
        public bool? IsUsed { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual CampaignVoucher? CpVch { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
