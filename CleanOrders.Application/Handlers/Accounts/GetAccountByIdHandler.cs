﻿using CleanOrders.Application.Common.Dtos.Accounts;
using CleanOrders.Application.Common.Dtos.Users;
using CleanOrders.Application.Common.Exceptions;
using CleanOrders.Application.Interfaces.Repositories;
using CleanOrders.Application.Queries.Accounts;
using MediatR;
using OrdersDomain.Core.Aggregates.Entities.Accounts;

namespace CleanOrders.Application.Handlers.Accounts
{
    public class GetAccountByIdHandler : IRequestHandler<GetAccountByIdQuery, GetAccountByIdResponse>
    {
        private readonly IAccountRepositoryAsync _accountRepositoryAsync;

        public GetAccountByIdHandler(IAccountRepositoryAsync accountsRepository)
        {
            _accountRepositoryAsync = accountsRepository;
        }
        public async Task<GetAccountByIdResponse> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            Account? account = await _accountRepositoryAsync.GetByIdAsync(request.Id);
            if (account == null)
            {
                throw new NotFoundException(request.Id);
            }
            if (request.User.RoleId == "Super" || request.User.AccountId == account.Id)
            {
                List<UserDto> users = new();
                foreach (var user in account.Users)
                {
                    var dto = new UserDto(user);
                    users.Add(dto);
                }
                AccountUsersDto result = new(account, users);
                return new GetAccountByIdResponse(result);
            }
            else
            {
                throw new NotFoundException(request.Id);
            }
        }
    }
}
