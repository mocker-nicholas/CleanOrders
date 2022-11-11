using CleanOrders.Application.Common.Dtos.Accounts;
using MediatR;

namespace CleanOrders.Application.Queries.Accounts
{
    public record GetAllAccountsQuery : IRequest<GetAllAccountsResponse>;
}
