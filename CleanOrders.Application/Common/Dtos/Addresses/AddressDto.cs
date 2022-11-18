using static OrdersDomain.Core.Enums.AddressEnums;

namespace CleanOrders.Application.Common.Dtos.Addresses
{
    public class AddressDto
    {
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public Country Country { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string PostalCode { get; set; }
    }
}
