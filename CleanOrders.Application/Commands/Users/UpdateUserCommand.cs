using CleanOrders.Application.Common.Dtos.Users;
using MediatR;
using System.ComponentModel.DataAnnotations;
using static OrdersDomain.Core.Enums.RoleEnums;

namespace CleanOrders.Application.Commands.Users
{
    public class UpdateUserCommand : IRequest<UpdateUserResponse>
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Role RoleId { get; set; }
    }
}
