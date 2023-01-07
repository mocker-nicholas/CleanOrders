using CleanOrders.Application.Common.Dtos.Accounts;
using MediatR;
using OrdersDomain.Core.Aggregates.Entities.Users;

namespace CleanOrders.Application.Queries.Accounts
{
    public record GetAccountByIdQuery(string Id, LoggedInUser User) : IRequest<GetAccountByIdResponse>;
}
