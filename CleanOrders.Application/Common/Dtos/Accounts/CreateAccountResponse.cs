using CleanOrders.Application.Common.Dtos.Accounts;

namespace CleanOrders.Application.Dtos.Accounts
{
    public class CreateAccountResponse
    {
        public CreateAccountResponse(AccountDto account)
        {
            Data = account;
        }

        public CreateAccountResponse(string message)
        {
            Status = "error";
            Message = message;
            Data = null;
        }

        public string Status { get; set; } = "success";
        public string Message { get; set; } = "success";
        public AccountDto? Data { get; set; }
    }
}
