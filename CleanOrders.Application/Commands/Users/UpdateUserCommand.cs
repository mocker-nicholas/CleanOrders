using CleanOrders.Application.Common.Dtos.Users;
using MediatR;
using System.ComponentModel.DataAnnotations;
using static OrdersDomain.Core.Enums.RoleEnums;

namespace CleanOrders.Application.Commands.Users
{
    public class UpdateUserCommand : IRequest<UpdateUserResponse>
    {
        public UpdateUserCommand(string userId, string email, Role roleId)
        {
            if (userId.Length > 100)
                throw new ArgumentException("your name is too long yo");

            Id = userId;
            Email = email;
            RoleId = roleId;
        }

        [Required]
        public string Id { get; private set; }
        [Required]
        public string Email { get; private set; }
        [Required]
        public Role RoleId { get; private set; }
    }
}
