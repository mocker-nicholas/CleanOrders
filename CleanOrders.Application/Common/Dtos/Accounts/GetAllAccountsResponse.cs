namespace CleanOrders.Application.Common.Dtos.Accounts
{
    public class GetAllAccountsResponse
    {
        public GetAllAccountsResponse(List<AccountDto> accounts)
        {
            Data = accounts;
        }

        public GetAllAccountsResponse(string message)
        {
            Status = "error";
            Message = message;
            Data = new List<AccountDto>() { };
        }

        public string Status { get; set; } = "success";
        public string Message { get; set; } = "success";
        public List<AccountDto> Data { get; set; }
    }
}
