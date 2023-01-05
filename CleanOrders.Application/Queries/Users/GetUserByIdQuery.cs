using CleanOrders.Application.Common.Dtos.Users;
using MediatR;

namespace CleanOrders.Application.Queries.Users
{
    public record GetUserByIdQuery(string id, string userId) : IRequest<GetUserByIdResponse>
    {
    }
}
