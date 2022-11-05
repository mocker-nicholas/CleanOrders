using OrdersDomain.Core.Aggregates.Entities.Bases;
using OrdersDomain.Core.Interfaces;

namespace OrdersDomain.Core.Aggregates.Entities.Orders
{
    public class Order : BaseEntity, IDateCreateable, IAuditable
    {
        public decimal Total { get; set; }
        public DateTime DateCreated { get; set; }
        // Why does intellisense trow exceptions
        public DateTime DateModified { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Address PayableToAddress { get; set; }
        public Address PayeeAddress { get; set; }
        public Address ShipToAddress { get; set; }


    }
}
