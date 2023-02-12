using OrdersDomain.Core.Aggregates.Entities.Bases;
using OrdersDomain.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using static OrdersDomain.Core.Enums.AddressEnums;

namespace OrdersDomain.Core.Aggregates.Entities.Orders
{
    public class Address : BaseEntity, IAuditable
    {
        [Required]
        public string FirstName { get; set; } = "";
        [Required]
        public string LastName { get; set; } = "";
        [Required]
        public string StreetAddress1 { get; set; } = "";
        public string StreetAddress2 { get; set; } = "";
        [Required]
        public Country Country { get; set; }
        [Required]
        public string City { get; set; } = "";
        [Required]
        public State State { get; set; }
        [Required]
        public string PostalCode { get; set; } = "";
        public DateTime DateModified { get; set; }
    }
}
