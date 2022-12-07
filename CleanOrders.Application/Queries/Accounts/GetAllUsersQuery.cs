using CleanOrders.Application.Common.Dtos.Users;
using MediatR;

namespace CleanOrders.Application.Queries.Accounts
{
    public record GetAllUsersQuery(string AccountId) : IRequest<GetAllUsersResponse>
    {

    }
}
