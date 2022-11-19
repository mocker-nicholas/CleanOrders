using OrdersDomain.Core.Aggregates.Entities.Bases;
using OrdersDomain.Core.Interfaces;
using static OrdersDomain.Core.Enums.AddressEnums;

namespace OrdersDomain.Core.Aggregates.Entities.Orders
{
    public class OrderAddress : BaseEntity, IAuditable
    {
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public Country Country { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string PostalCode { get; set; }
        public DateTime DateModified { get; set; }
    }
}
