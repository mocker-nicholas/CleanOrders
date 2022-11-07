using CleanOrders.Infrastructure.Dtos.Accounts;
using MediatR;

namespace CleanOrders.Application.Commands.Accounts
{
    public partial class CreateAccountCommand : IRequest<CreateAccountResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
