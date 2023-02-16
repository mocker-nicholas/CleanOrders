namespace CleanOrders.Application.Common.Dtos.Orders
{
    public class CreateOrderResponse
    {
        public CreateOrderResponse(string status, string message)
        {
            Status = status;
            Message = message;
        }

        public CreateOrderResponse(object data)
        {
            Data = data;
        }

        public string Status { get; set; } = "success";
        public string Message { get; set; } = "success";
        public object? Data { get; set; }
    }
}
