﻿using CleanOrders.Application.Common.Dtos.Accounts;
using MediatR;
using static OrdersDomain.Core.Enums.AddressEnums;

namespace CleanOrders.Application.Commands.Accounts
{
    public partial class UpdateAccountCommand : IRequest<UpdateAccountResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public Country Country { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string PostalCode { get; set; }
    }
}
