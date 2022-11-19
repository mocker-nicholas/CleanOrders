using OrdersDomain.Core.Aggregates.Entities.Accounts;
using OrdersDomain.Core.Aggregates.Entities.Bases;
using static OrdersDomain.Core.Enums.AddressEnums;

namespace CleanOrders.Application.Common.Dtos.Accounts
{
    public class AccountDto : BaseEntity
    {
        public AccountDto(Account account)
        {
            Name = account.BusinessName;
            Email = account.Email;
            DateCreated = account.DateCreated;
            DateModified = account.DateModified;
            Id = account.Id;
            StreetAddress1 = account.StreetAddress1;
            StreetAddress2 = account.StreetAddress2;
            Country = account.Country;
            City = account.City;
            State = account.State;
            PostalCode = account.PostalCode;
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public Country Country { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string PostalCode { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
