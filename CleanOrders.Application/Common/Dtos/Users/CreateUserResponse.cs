namespace CleanOrders.Application.Common.Dtos.Users
{
    public class CreateUserResponse
    {
        public CreateUserResponse(UserDto user)
        {
            Data = user;
        }

        public CreateUserResponse(string message)
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

