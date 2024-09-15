using CryptoServiceBybit.Domain.Models;
using System.Net.Http.Json;

namespace CryptoServiceBybit.ServiceBybit
{
    public abstract class BaseClient
    {
        protected HttpClient _httpClient;

        private readonly string _connectionString;

        private readonly string _version = "v5";

        protected BaseClient(string baseAddress)
        {
            _connectionString = baseAddress;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_connectionString)
            };
        }

        public async Task<AnnouncementsInfo> GetAnnouncements(string locale = "en-US", string type = "new_crypto", string tag = "Spot", 
            int page = 1, int limit = 20, CancellationToken cancel = default)
        {
            var response = await _httpClient
                .GetFromJsonAsync<AnnouncementsInfo>($"/{_version}/announcements/index?locale={locale}&type={type}&tag={tag}&page={page}&limit={limit}", cancel)
                .ConfigureAwait(false);

            return response;
        }

        public async Task<PriceKlineInfo> GetPriceKline(string symbol = "BTCUSDT", int startTimeMs = 0, int endTimeMs = 0,
             string interval = "D", string category = "spot", int limit = 10, CancellationToken cancel = default)
        {
            var response = await _httpClient
                .GetFromJsonAsync<PriceKlineInfo>($"/{_version}/market/kline?category={category}&symbol={symbol}&interval={interval}&start={startTimeMs}&end={endTimeMs}&limit={limit}", cancel)
                .ConfigureAwait(false);

            return response;
        }


        public async Task<MarkPriceKlineInfo> GetMarkPriceKline(string symbol = "BTCUSDT", int startTimeMs = 0, int endTimeMs = 0,
             string interval = "D", string category = "linear", int limit = 10, CancellationToken cancel = default)
        {
            var response = await _httpClient
                .GetFromJsonAsync<MarkPriceKlineInfo>($"/{_version}/market/mark-price-kline?category={category}&symbol={symbol}&interval={interval}&start={startTimeMs}&end={endTimeMs}&limit={limit}", cancel)
                .ConfigureAwait(false);

            return response;
        }

        public async Task<TickersSpotInfo> GetTickerSpot(string symbol = "BTCUSDT", CancellationToken cancel = default)
        {
            var response = await _httpClient
                .GetFromJsonAsync<TickersSpotInfo>($"/{_version}/market/tickers?category=spot&symbol={symbol}", cancel)
                .ConfigureAwait(false);

            return response;
        }

        public async Task<TickersSpotInfo> GetTickersSpot(CancellationToken cancel = default)
        {
            var response = await _httpClient
                .GetFromJsonAsync<TickersSpotInfo>($"{_version}/market/tickers?category=spot", cancel)
                .ConfigureAwait(false);

            return response;
        }

        public async Task<TickersInverseInfo> GetTickerInverse(string symbol = "BTCUSDT", CancellationToken cancel = default)
        {
            var response = await _httpClient
                .GetFromJsonAsync<TickersInverseInfo>($"/{_version}/market/tickers?category=inverse&symbol={symbol}", cancel)
                .ConfigureAwait(false);

            return response;
        }

        public async Task<TickersInverseInfo> GetTickersInverse(CancellationToken cancel = default)
        {
            var response = await _httpClient
                .GetFromJsonAsync<TickersInverseInfo>($"/{_version}/market/tickers?category=inverse", cancel)
                .ConfigureAwait(false);
            return response;
        }
    }
}
