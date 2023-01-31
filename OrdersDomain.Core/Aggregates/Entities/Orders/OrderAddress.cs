using OrdersDomain.Core.Aggregates.Entities.Bases;
using OrdersDomain.Core.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using static OrdersDomain.Core.Enums.AddressEnums;

namespace OrdersDomain.Core.Aggregates.Entities.Orders
{
    public class OrderAddress : BaseEntity, IAuditable
    {
        [ForeignKey("Order")]
        public string OrderId { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public Country Country { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string PostalCode { get; set; }
        public bool IsPayTo { get; set; }
        public bool IsBillTo { get; set; }
        public bool IsShipTo { get; set; }
        public DateTime DateModified { get; set; }
    }
}
