using CleanOrders.Application.Common.Dtos.Orders;
using MediatR;
using System.ComponentModel.DataAnnotations;
using static OrdersDomain.Core.Enums.AddressEnums;

namespace CleanOrders.Application.Commands.Orders
{
    public class CreateOrderCommand : IRequest<CreateOrderResponse>
    {
        public string AccountId { get; set; }
        public decimal Total { get; set; }
        public ApiAddressDto? BillToAddress { get; set; }
        public ApiAddressDto? ShipToAddress { get; set; }
        public ApiAddressDto? PayToAddress { get; set; }

        [Required]
        public ICollection<ApiLineItemDto> LineItems { get; set; }
    }

    public class ApiAddressDto
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string StreetAddress1 { get; set; } = "";
        public string StreetAddress2 { get; set; } = "";
        public Country Country { get; set; }
        public string City { get; set; } = "";
        public State State { get; set; }
        public string PostalCode { get; set; } = "";
    }

    public class ApiLineItemDto
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public int BaseAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
