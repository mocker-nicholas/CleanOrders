using OrdersDomain.Core.Aggregates.Entities.Bases;
using OrdersDomain.Core.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using static OrdersDomain.Core.Enums.AddressEnums;

namespace OrdersDomain.Core.Aggregates.Entities.Orders
{
    public class BusinessAddress : BaseEntity, IAuditable
    {
        public BusinessAddress(string accountId, string streetAddress1, string streetAddress2, Country country, string city, State state, string postalCode)
        {
            AccountId = accountId;
            StreetAddress1 = streetAddress1;
            StreetAddress2 = streetAddress2;
            Country = country;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        [ForeignKey("Account")]
        public string AccountId { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public Country Country { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string PostalCode { get; set; }
        public DateTime DateModified { get; set; }
    }
}
