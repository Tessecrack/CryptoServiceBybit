using System.Text.Json.Serialization;

namespace CryptoServiceBybit.Domain.Models
{
    public class PriceInfo
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("list")]
        // 0 - startTime; 1 - open; 2 - high; 3 - low; 4 - close
        // 0 - startTime; 1 - open; 2 - high; 3 - low; 4 - close; 5 - volume; 6 - turnover
        public string[][] PriceList { get; set; }
    }
}
