using System.Text.Json.Serialization;

namespace CryptoServiceBybit.Domain.Models.Tickers
{
    public class TickersSpotInfo : BaseResponse
    {
        [JsonPropertyName("result")]
        public TickersSpot Result { get; set; }
    }

    public class TickersSpot
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("list")]
        public TickerSpot[] ListTickers { get; set; }
    }

    public class TickerSpot
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("bid1Price")]
        public string Bid1Price { get; set; }

        [JsonPropertyName("bid1Size")]
        public string Bid1Size { get; set; }

        [JsonPropertyName("ask1Price")]
        public string Ask1Price { get; set; }

        [JsonPropertyName("ask1Size")]
        public string Ask1Size { get; set; }

        [JsonPropertyName("lastPrice")]
        public string LastPrice { get; set; }

        [JsonPropertyName("prevPrice24h")]
        public string PrevPrice24h { get; set; }

        [JsonPropertyName("price24hPcnt")]
        public string Price24hPcnt { get; set; }

        [JsonPropertyName("highPrice24h")]
        public string HighPrice24h { get; set; }

        [JsonPropertyName("lowPrice24h")]
        public string LowPrice24h { get; set; }

        [JsonPropertyName("turnover24h")]
        public string Turnover24h { get; set; }

        [JsonPropertyName("volume24h")]
        public string Volume24h { get; set; }

        [JsonPropertyName("usdIndexPrice")]
        public string UsdIndexPrice { get; set; }
    }
}
