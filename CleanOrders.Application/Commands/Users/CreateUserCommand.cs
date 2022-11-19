using CleanOrders.Application.Common.Dtos.Users;
using MediatR;
using System.ComponentModel.DataAnnotations;
using static OrdersDomain.Core.Enums.RoleEnums;

namespace CleanOrders.Application.Commands.Users
{
    public partial class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public string AccountId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Role RoleId { get; set; }
    }
}
