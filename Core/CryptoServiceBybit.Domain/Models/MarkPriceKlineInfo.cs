using System.Text.Json.Serialization;

namespace CryptoServiceBybit.Domain.Models
{
    public class MarkPriceKlineInfo : BaseResponse
    {
        [JsonPropertyName("result")]
        public PriceInfo PriceInfo { get; set; }
    }
}
