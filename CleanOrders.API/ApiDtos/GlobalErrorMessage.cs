using System.Text.Json.Serialization;

namespace CleanOrders.API.ApiDtos
{
    public class GlobalErrorMessage
    {
        public GlobalErrorMessage(string data)
        {
            Message = data;
        }

        [JsonPropertyName("status")]
        public string Status { get; set; } = "error";
        [JsonPropertyName("message")]
        public string Message { get; set; } = "error";
    }
}
