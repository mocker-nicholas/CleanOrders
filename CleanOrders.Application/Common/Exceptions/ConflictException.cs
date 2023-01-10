namespace CleanOrders.Application.Common.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException(string email) : base($"Email address: {email} already in use")
        {

        }

        public int StatusCode { get; set; } = 409;
    }
}
