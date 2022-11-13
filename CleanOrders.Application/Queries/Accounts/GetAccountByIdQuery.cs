using CleanOrders.Application.Common.Dtos.Accounts;
using MediatR;

namespace CleanOrders.Application.Queries.Accounts
{
    public record GetAccountByIdQuery(string Id) : IRequest<GetAccountByIdResponse>;
}
