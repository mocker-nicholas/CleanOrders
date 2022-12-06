using CleanOrders.Application.Dtos.Accounts;
using MediatR;

namespace CleanOrders.Application.Commands.Accounts
{
    public class DeleteAccountCommand : IRequest<DeleteAccountResponse>
    {
        public DeleteAccountCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
