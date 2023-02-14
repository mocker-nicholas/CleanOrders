namespace CleanOrders.Application.Common.Dtos.Orders
{
    public class CreateOrderResponse
    {
        public CreateOrderResponse(string status, string message)
        {
            Status = status;
            Message = message;
        }

        public CreateOrderResponse(OrderResponseDto data)
        {
            Data = data;
        }

        public string Status { get; set; } = "success";
        public string Message { get; set; } = "success";
        public OrderResponseDto? Data { get; set; }
    }
}
