using System.Text.Json.Serialization;

namespace CryptoServiceBybit.Domain.Models
{
    public class BaseResponse
    {
        [JsonPropertyName("retCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("retMsg")]
        public string Message { get; set; }

        [JsonPropertyName("retExtInfo")]
        public object ExternalInfo { get; set; }

        [JsonPropertyName("time")]
        public long Time { get; set; }
    }
}
