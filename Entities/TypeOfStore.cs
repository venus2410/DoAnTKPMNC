using System;
using System.Collections.Generic;

namespace DoAnTKPMNC.Entities
{
    public partial class TypeOfStore
    {
        public TypeOfStore()
        {
            Stores = new HashSet<Store>();
        }

        public int TypeId { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Store> Stores { get; set; }
    }
}
