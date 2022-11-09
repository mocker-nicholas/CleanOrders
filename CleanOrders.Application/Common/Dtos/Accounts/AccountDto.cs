using OrdersDomain.Core.Aggregates.Entities.Accounts;
using OrdersDomain.Core.Aggregates.Entities.Bases;

namespace CleanOrders.Application.Common.Dtos.Accounts
{
    public class AccountDto : BaseEntity
    {
        public AccountDto(Account account)
        {
            Name = account.Name;
            Email = account.Email;
            DateCreated = account.DateCreated;
            DateModified = account.DateModified;
            Id = account.Id;
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
