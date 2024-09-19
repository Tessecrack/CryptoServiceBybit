using System.Text.Json.Serialization;

namespace CryptoServiceBybit.Domain.Models.Tickers
{
    public class TickersLinearInfo
    {
        [JsonPropertyName("result")]
        public TickersLinear Result { get; set; }
    }

    public class TickersLinear
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("list")]
        public TickerLinear[] ListTickers { get; set; }
    }

    public class TickerLinear
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("lastPrice")]
        public string LastPrice { get; set; }

        [JsonPropertyName("indexPrice")]
        public string IndexPrice { get; set; }

        [JsonPropertyName("markPrice")]
        public string MarkPrice { get; set; }

        [JsonPropertyName("prevPrice24h")]
        public string PreviousPrice24h { get; set; }

        [JsonPropertyName("price24hPcnt")]
        public string Price24hPcnt { get; set; }

        [JsonPropertyName("highPrice24h")]
        public string HighPrice24h { get; set; }

        [JsonPropertyName("lowPrice24h")]
        public string LowPrice24h { get; set; }

        [JsonPropertyName("prevPrice1h")]
        public string PrevPrice1h { get; set; }

        [JsonPropertyName("openInterest")]
        public string OpenInterest { get; set; }

        [JsonPropertyName("openInterestValue")]
        public string OpenInterestValue { get; set; }

        [JsonPropertyName("turnover24h")]
        public string Turnover24h { get; set; }

        [JsonPropertyName("volume24h")]
        public string Volume24h { get; set; }

        [JsonPropertyName("fundingRate")]
        public string FundingRate { get; set; }

        [JsonPropertyName("nextFundingTime")]
        public string NextFundingTime { get; set; }

        [JsonPropertyName("predictedDeliveryPrice")]
        public string PredictedDeliveryPrice { get; set; }

        [JsonPropertyName("basisRate")]
        public string BasisRate { get; set; }

        [JsonPropertyName("deliveryFeeRate")]
        public string DeliveryFeeRate { get; set; }

        [JsonPropertyName("deliveryTime")]
        public string DeliveryTime { get; set; }

        [JsonPropertyName("ask1Size")]
        public string Ask1Size { get; set; }

        [JsonPropertyName("bid1Price")]
        public string Bid1Price { get; set; }

        [JsonPropertyName("ask1Price")]
        public string Ask1Price { get; set; }

        [JsonPropertyName("bid1Size")]
        public string Bid1Size { get; set; }

        [JsonPropertyName("basis")]
        public string Basis { get; set; }

        [JsonPropertyName("preOpenPrice")]
        public string PreOpenPrice { get; set; }

        [JsonPropertyName("preQty")]
        public string PreQty { get; set; }

        [JsonPropertyName("curPreListingPhase")]
        public string CurPreListingPhase { get; set; }
    }
}


/*

        "symbol": "1000000BABYDOGEUSDT",
        "lastPrice": "0.0024773",
        "indexPrice": "0.0024664",
        "markPrice": "0.0024773",
        "prevPrice24h": "0.0018939",
        "price24hPcnt": "0.308041",
        "highPrice24h": "0.0029725",
        "lowPrice24h": "0.0017563",
        "prevPrice1h": "0.0022354",
        "openInterest": "2941263300",
        "openInterestValue": "7286391.57",
        "turnover24h": "103263599.7503",
        "volume24h": "47112960100.0000",
        "fundingRate": "-0.00088345",
        "nextFundingTime": "1726790400000",
        "predictedDeliveryPrice": "",
        "basisRate": "",
        "deliveryFeeRate": "",
        "deliveryTime": "0",
        "ask1Size": "186000",
        "bid1Price": "0.0024773",
        "ask1Price": "0.0025765",
        "bid1Size": "32724800",
        "basis": "",
        "preOpenPrice": "",
        "preQty": "",
        "curPreListingPhase": "" 

 */