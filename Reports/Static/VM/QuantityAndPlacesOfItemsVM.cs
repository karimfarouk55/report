using System;
using System.Collections.Generic;
using System.Text;

namespace Static.VM
{
    public class Stores
    {
        public int? key { get; set; }
        public string StoreDesc { get; set; }
        public List<BranchsOfStore> ItemsInBranchs { get; set; }
    }

    public class BranchsOfStore
    {
        public string BranchDesc { get; set; }
        public List<QuantityAndPlacesOfItemsVM> Items { get; set; }
    }

    public class QuantityAndPlacesOfItemsVM
    {
        public Nullable<int> StoreId { get; set; }
        public string ItemCatCode { get; set; }
        public string StoreDescA { get; set; }
        public string PartDescA { get; set; }
        public string ItemCatDescA { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescA { get; set; }
        public string ItemDescE { get; set; }
        public Nullable<decimal> QtyPartiation { get; set; }
        public Nullable<decimal> QtyInNotebook { get; set; }

        public List<QuantityAndPlacesOfItemsVM> ItemsWithCategoryCode { get; set; }
    }
}
