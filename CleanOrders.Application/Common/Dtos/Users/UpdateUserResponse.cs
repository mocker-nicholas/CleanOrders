namespace CleanOrders.Application.Common.Dtos.Users
{
    public class UpdateUserResponse
    {
        public UpdateUserResponse(UserDto user)
        {
            Data = user;
        }

        public UpdateUserResponse(string message)
        {
            Status = "error";
            Message = message;
            Data = null;
        }

        public string Status { get; set; } = "success";
        public string Message { get; set; } = "success";
        public UserDto? Data { get; set; }
    }
}
