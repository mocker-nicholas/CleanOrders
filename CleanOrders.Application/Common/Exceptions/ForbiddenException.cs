namespace CleanOrders.Application.Common.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException() : base("Forbidden")
        {

        }

        public int StatusCode { get; } = 403;
    }
}
