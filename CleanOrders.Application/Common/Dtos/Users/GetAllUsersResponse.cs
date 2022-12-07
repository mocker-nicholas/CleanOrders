namespace CleanOrders.Application.Common.Dtos.Users
{
    public class GetAllUsersResponse
    {
        public GetAllUsersResponse(List<UserDto> users)
        {
            Data = users;
        }

        public GetAllUsersResponse(string message)
        {
            Status = "error";
            Message = message;
            Data = null;
        }

        public string Status { get; set; } = "success";
        public string Message { get; set; } = "success";
        public List<UserDto> Data { get; set; }
    }
}
