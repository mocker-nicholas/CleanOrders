using OrdersDomain.Core.Aggregates.Entities.Orders;
using static OrdersDomain.Core.Enums.AddressEnums;

namespace CleanOrders.API.ApiDtos.Accounts
{
    public class ApiAccountDto
    {
        public string BusinessName { get; set; }
        public string Email { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public Country Country { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string PostalCode { get; set; }
        public IList<Address> BusinessAddresses { get; set; }
    }
}
