using CleanOrders.Application.Common.Dtos.Accounts;
using MediatR;
using static OrdersDomain.Core.Enums.AddressEnums;

namespace CleanOrders.Application.Commands.Accounts
{
    public partial class UpdateAccountCommand : IRequest<UpdateAccountResponse>
    {
        public UpdateAccountCommand(string id, string businessName, string email, string streetAddress1, string streetAddress2, Country country, string city, State state, string postalCode)
        {
            Id = id;
            BusinessName = businessName;
            Email = email;
            StreetAddress1 = streetAddress1;
            StreetAddress2 = streetAddress2;
            Country = country;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        public string Id { get; set; }
        public string BusinessName { get; set; }
        public string Email { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public Country Country { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string PostalCode { get; set; }
    }
}
