using OrdersDomain.Core.Aggregates.Entities.Bases;
using OrdersDomain.Core.Interfaces;
using static OrdersDomain.Core.Enums.AddressEnums;

namespace OrdersDomain.Core.Aggregates.Entities.Accounts
{
    public class Account : BaseEntity, IDateCreateable, IAuditable
    {
        public Account(
            string name,
            string email,
            string password,
            string streetAddress1,
            string streetAddress2,
            Country country,
            string city,
            State state,
            string postalCode
            )
        {
            Name = name;
            Email = email;
            Password = password;
            StreetAddress1 = streetAddress1;
            StreetAddress2 = streetAddress2;
            Country = country;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public Country Country { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string PostalCode { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateModified { get; set; } = DateTime.Now;
    }
}
