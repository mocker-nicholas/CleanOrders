namespace CleanOrders.Application.Common.Dtos.Accounts
{
    public class UpdateAccountResponse
    {
        public UpdateAccountResponse(AccountDto account)
        {
            Data = account;
        }

        public UpdateAccountResponse(string message)
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
