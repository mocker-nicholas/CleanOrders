using OrdersDomain.Core.Aggregates.Entities.Accounts;

namespace CleanOrders.Application.Dtos.Accounts
{
    public class CreateAccountResponse
    {
        public CreateAccountResponse(Account account)
        {
            Data = account;
        }

        public string Status { get; set; } = "success";
        public string Message { get; set; } = "success";
        public Account Data { get; set; }
    }
}
