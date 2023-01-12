namespace CleanOrders.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {

        public NotFoundException(string id) : base($"{id} was not found")
        {

        }

        public int StatusCode { get; } = 404;
    }
}
