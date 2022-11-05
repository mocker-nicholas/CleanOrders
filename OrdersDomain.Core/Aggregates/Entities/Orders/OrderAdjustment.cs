using OrdersDomain.Core.Aggregates.Entities.Bases;

namespace OrdersDomain.Core.Aggregates.Entities.Orders
{
    public class OrderAdjustment : BaseEntity
    {
        public decimal? OrderAdjustmentFlatAmount { get; set; }
        public decimal? OrderAdjustmentFlatPercentage { get; set; }
    }
}
