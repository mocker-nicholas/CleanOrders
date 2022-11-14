using CleanOrders.Application.Common.Dtos.Accounts;
using MediatR;

namespace CleanOrders.Application.Commands.Accounts
{
    public partial class UpdateAccountCommand : IRequest<UpdateAccountResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
