using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class StockPortfolioStocks
    {
        public StockPortfolioStocks()
        {
            StockPortfolioStockArchives = new HashSet<StockPortfolioStockArchives>();
        }

        public int StockPortJoinId { get; set; }
        public int? StockPortfolioId { get; set; }
        public int? StockId { get; set; }
        public int? StockQuantity { get; set; }
        public decimal? CostAverage { get; set; }

        public virtual StockStocks Stock { get; set; }
        public virtual StockPortfolio StockPortfolio { get; set; }
        public virtual ICollection<StockPortfolioStockArchives> StockPortfolioStockArchives { get; set; }
    }
}
