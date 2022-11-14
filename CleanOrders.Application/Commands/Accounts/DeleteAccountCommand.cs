using CleanOrders.Application.Dtos.Accounts;
using MediatR;

namespace CleanOrders.Application.Commands.Accounts
{
    public class DeleteAccountCommand : IRequest<DeleteAccountResponse>
    {
        public string Id { get; set; }
    }
}
