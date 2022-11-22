using OrdersDomain.Core.Aggregates.Entities.Bases;
using OrdersDomain.Core.Aggregates.Entities.Users;
using OrdersDomain.Core.Interfaces;
using static OrdersDomain.Core.Enums.AddressEnums;

namespace OrdersDomain.Core.Aggregates.Entities.Accounts
{
    public class Account : BaseEntity, IDateCreateable, IAuditable
    {
        public Account(
            string businessName,
            string email,
            string streetAddress1,
            string streetAddress2,
            Country country,
            string city,
            State state,
            string postalCode
            )
        {
            BusinessName = businessName;
            Email = email;
            StreetAddress1 = streetAddress1;
            StreetAddress2 = streetAddress2;
            Country = country;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        public Account(Account account)
        {
            BusinessName = account.BusinessName;
            Email = account.Email;
            StreetAddress1 = account.StreetAddress1;
            StreetAddress2 = account.StreetAddress2;
            Country = account.Country;
            City = account.City;
            State = account.State;
            PostalCode = account.PostalCode;
            Users = account.Users;
        }

        public string BusinessName { get; set; }
        public string Email { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public Country Country { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string PostalCode { get; set; }
        public List<User> Users { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateModified { get; set; } = DateTime.Now;
    }
}
