namespace CleanOrders.API.ApiDtos
{
    public class GlobalErrorMessage
    {
        public GlobalErrorMessage(object data)
        {
            Data = data;
        }
        public string Status { get; set; } = "error";
        public string Message { get; set; } = "error";
        public object Data { get; set; }
    }
}
