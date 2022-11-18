using CleanOrders.Application.Common.Dtos.Accounts;

namespace CleanOrders.Application.Dtos.Accounts
{
    public class DeleteAccountResponse
    {
        public DeleteAccountResponse(AccountDto account)
        {
            Data = account;
        }

        public DeleteAccountResponse(string message)
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
