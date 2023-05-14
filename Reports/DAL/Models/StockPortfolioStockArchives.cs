using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class StockPortfolioStockArchives
    {
        public int StockArchivesId { get; set; }
        public int? StockPortJoinId { get; set; }
        public int? StockArchId { get; set; }
        public int? StockQuantity { get; set; }

        public virtual StockArchives StockArch { get; set; }
        public virtual StockPortfolioStocks StockPortJoin { get; set; }
    }
}
