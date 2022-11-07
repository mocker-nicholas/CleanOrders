using CleanOrders.Application.Commands.Accounts;
using CleanOrders.Infrastructure.Data;
using CleanOrders.Infrastructure.Dtos.Accounts;
using MediatR;
using OrdersDomain.Core.Aggregates.Entities.Accounts;

namespace CleanOrders.Application.Handlers.Accounts
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, CreateAccountResponse>
    {
        private readonly ApplicationContext _context;
        public CreateAccountHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<CreateAccountResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            Account account = new(request.Password, request.Email, request.Name);
            await _context.Accounts.AddAsync(account, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return new CreateAccountResponse(account);
        }
    }
}
