using System.Text.Json.Serialization;

namespace CryptoServiceBybit.Domain.Models.Tickers
{
    public class TickersOptionInfo
    {
        [JsonPropertyName("result")]
        public TickersOption Result { get; set; }
    }

    public class TickersOption
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("list")]
        public TickerOption[] ListTickers { get; set; }
    }

    public class TickerOption
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("bid1Price")]
        public string Bid1Price { get; set; }

        [JsonPropertyName("bid1Size")]
        public string Bid1Size { get; set; }

        [JsonPropertyName("bid1Iv")]
        public string Bid1Iv { get; set; }

        [JsonPropertyName("ask1Price")]
        public string Ask1Price { get; set; }

        [JsonPropertyName("ask1Size")]
        public string Ask1Size { get; set; }

        [JsonPropertyName("ask1Iv")]
        public string Ask1Iv { get; set; }

        [JsonPropertyName("lastPrice")]
        public string LastPrice { get; set; }

        [JsonPropertyName("highPrice24h")]
        public string HighPrice24h { get; set; }

        [JsonPropertyName("lowPrice24h")]
        public string LowPrice24h { get; set; }

        [JsonPropertyName("markPrice")]
        public string MarkPrice { get; set; }

        [JsonPropertyName("indexPrice")]
        public string IndexPrice { get; set; }

        [JsonPropertyName("markIv")]
        public string MarkIv { get; set; }

        [JsonPropertyName("underlyingPrice")]
        public string UnderlyingPrice { get; set; }

        [JsonPropertyName("openInterest")]
        public string OpenInterest { get; set; }

        [JsonPropertyName("turnover24h")]
        public string Turnover24h { get; set; }

        [JsonPropertyName("volume24h")]
        public string Volume24h { get; set; }

        [JsonPropertyName("totalVolume")]
        public string TotalVolume { get; set; }

        [JsonPropertyName("totalTurnover")]
        public string TotalTurnover { get; set; }

        [JsonPropertyName("delta")]
        public string Delta { get; set; }

        [JsonPropertyName("gamma")]
        public string Gamma { get; set; }

        [JsonPropertyName("vega")]
        public string Vega { get; set; }

        [JsonPropertyName("theta")]
        public string Theta { get; set; }

        [JsonPropertyName("predictedDeliveryPrice")]
        public string PredictedDeliveryPrice { get; set; }

        [JsonPropertyName("change24h")]
        public string Change24h { get; set; }
    }
}
