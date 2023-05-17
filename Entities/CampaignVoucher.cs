using System;
using System.Collections.Generic;

namespace DoAnTKPMNC.Entities
{
    public partial class CampaignVoucher
    {
        public CampaignVoucher()
        {
            CpVchCustomers = new HashSet<CpVchCustomer>();
        }

        public int Id { get; set; }
        public int? VoucherId { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public int? CampaignId { get; set; }
        public int? Quantity { get; set; }
        public int? UsedQuantity { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Campaign? Campaign { get; set; }
        public virtual Voucher? Voucher { get; set; }
        public virtual ICollection<CpVchCustomer> CpVchCustomers { get; set; }
    }
}
