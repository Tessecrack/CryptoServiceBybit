using System.Text.Json.Serialization;

namespace CryptoServiceBybit.Domain.Models
{
    public class PriceKlineInfo : BaseResponse
    {
        [JsonPropertyName("result")]
        public PriceInfo PriceInfo { get; set; }
    }
}
