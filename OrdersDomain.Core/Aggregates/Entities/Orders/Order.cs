using OrdersDomain.Core.Aggregates.Entities.Bases;
using OrdersDomain.Core.Interfaces;

namespace OrdersDomain.Core.Aggregates.Entities.Orders
{
    public class Order : BaseEntity, IDateCreateable, IAuditable
    {
        public string AccountId { get; set; }
        public decimal Total { get; set; }
        public DateTime DateCreated { get; set; }
        // Why does intellisense trow exceptions
        public DateTime DateModified { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public OrderAddress PayableToAddress { get; set; }
        public OrderAddress PayeeAddress { get; set; }
        public OrderAddress ShipToAddress { get; set; }
        public List<LineItem> LineItems { get; set; }
    }
}
