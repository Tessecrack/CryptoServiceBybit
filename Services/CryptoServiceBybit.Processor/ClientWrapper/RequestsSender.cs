using CryptoServiceBybit.Domain.Models;
using CryptoServiceBybit.Domain.Models.Tickers;
using CryptoServiceBybit.Processor.Processors;
using CryptoServiceBybit.ServiceBybit;

namespace CryptoServiceBybit.Processor.ClientWrapper
{
    internal class RequestsSender<TClient> where TClient : BaseClient
    {
        private readonly TClient _client;
        private TaskQueue _queue;

        public RequestsSender(TClient client) 
        { 
            _client = client;
            _queue = new TaskQueue();
        }

        public async Task<AnnouncementsInfo> GetAnnouncements(string locale = "en-US", string type = "new_crypto", string tag = "Spot",
            int page = 1, int limit = 20, CancellationToken cancel = default)
        {
            return await _queue.Enqueue(() => _client.GetAnnouncements(locale, type, tag, page, limit, cancel));
        }

        public async Task<PriceKlineInfo> GetPriceKline(string symbol = "BTCUSDT", int startTimeMs = 0, int endTimeMs = 0,
            string interval = "D", string category = "spot", int limit = 10, CancellationToken cancel = default)
        {
            return await _queue.Enqueue(() => _client.GetPriceKline(symbol, startTimeMs, endTimeMs, 
                interval, category, limit, cancel));
        }

        public async Task<MarkPriceKlineInfo> GetMarkPriceKline(string symbol = "BTCUSDT", int startTimeMs = 0, int endTimeMs = 0,
            string interval = "D", string category = "linear", int limit = 10, CancellationToken cancel = default)
        {
            return await _queue.Enqueue(() => _client.GetMarkPriceKline(symbol, startTimeMs, 
                endTimeMs, interval, category, limit, cancel));
        }

        public async Task<TickersSpotInfo> GetTickerSpot(string symbol, CancellationToken cancel = default)
        {
            return await _queue.Enqueue(() => _client.GetTickerSpot(symbol, cancel));
        }

        public async Task<TickersInverseInfo> GetTickerInverse(string symbol, CancellationToken cancel = default)
        {
            return await _queue.Enqueue(() => _client.GetTickerInverse(symbol, cancel));
        }

        public async Task<TickersLinearInfo> GetTickerLinear(string symbol, CancellationToken cancel = default)
        {
            return await _queue.Enqueue(() => _client.GetTickerLinear(symbol, cancel));
        }

        public async Task<TickersOptionInfo> GetTickerOption(string symbol, CancellationToken cancel = default)
        {
            return await _queue.Enqueue(() => _client.GetTickerOption(symbol, cancel));
        }

        public async Task<TickersSpotInfo> GetTickersSpot(CancellationToken cancel = default)
        {
            return await _queue.Enqueue(() => _client.GetTickersSpot(cancel)).ConfigureAwait(false);
        }

        public async Task<TickersInverseInfo> GetTickersInverse(CancellationToken cancel = default)
        {
            return await _queue.Enqueue(() => _client.GetTickersInverse(cancel)).ConfigureAwait(false);
        }

        public async Task<TickersLinearInfo> GetTickersLinear(CancellationToken cancel = default)
        {
            return await _queue.Enqueue(() => _client.GetTickersLinear(cancel)).ConfigureAwait(false);
        }

        public async Task<TickersOptionInfo> GetTickersOption(CancellationToken cancel = default)
        {
            return await _queue.Enqueue(() => _client.GetTickersOption(cancel)).ConfigureAwait(false);
        }
    }
}
