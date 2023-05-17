using System;
using System.Collections.Generic;

namespace DoAnTKPMNC.Entities
{
    public partial class Store
    {
        public Store()
        {
            Vouchers = new HashSet<Voucher>();
        }

        public int StoreId { get; set; }
        public int? TypeId { get; set; }
        public string? Address { get; set; }
        public int? PartnerId { get; set; }
        public string? StoredName { get; set; }
        public decimal? Long { get; set; }
        public decimal? Lat { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Partner? Partner { get; set; }
        public virtual TypeOfStore? Type { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
