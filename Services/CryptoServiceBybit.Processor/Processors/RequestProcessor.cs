using CryptoServiceBybit.Domain.Models.Tickers;
using CryptoServiceBybit.Domain.Models;
using CryptoServiceBybit.Processor.Cache;
using CryptoServiceBybit.Processor.ClientWrapper;
using CryptoServiceBybit.ServiceBybit;

namespace CryptoServiceBybit.Processor.Processors
{
    public class RequestProcessor<TClient> : IDisposable
        where TClient : BaseClient
    {
        private SymbolsCacher _symbolsCacher;

        private RequestsSender<BaseClient> _requestsSender;

        private UpdaterCacherWorker _updateCacherWorker;

        private bool disposedValue;

        public RequestProcessor(TClient client)
        {
            _symbolsCacher = new SymbolsCacher();
            _requestsSender = new RequestsSender<BaseClient>(_symbolsCacher, client);
            _updateCacherWorker = new UpdaterCacherWorker(_symbolsCacher, _requestsSender);
        }

        public async Task<AnnouncementsInfo> GetAnnouncements(string locale = "en-US", string type = "new_crypto", string tag = "Spot",
            int page = 1, int limit = 20, CancellationToken cancel = default)
        {
            return await _requestsSender.GetAnnouncements(locale, type, tag, page, limit, cancel);
        }

        public async Task<PriceKlineInfo> GetPriceKline(string symbol = "BTCUSDT", int startTimeMs = 0, int endTimeMs = 0,
            string interval = "D", string category = "spot", int limit = 10, CancellationToken cancel = default)
        {
            return await _requestsSender.GetPriceKline(symbol, startTimeMs, endTimeMs,
                interval, category, limit, cancel);
        }

        public async Task<MarkPriceKlineInfo> GetMarkPriceKline(string symbol = "BTCUSDT", int startTimeMs = 0, int endTimeMs = 0,
            string interval = "D", string category = "linear", int limit = 10, CancellationToken cancel = default)
        {
            return await _requestsSender.GetMarkPriceKline(symbol, startTimeMs,
                endTimeMs, interval, category, limit, cancel);
        }

        public async Task<TickersSpotInfo> GetTickerSpot(string symbol, CancellationToken cancel = default)
        {
            return await _requestsSender.GetTickerSpot(symbol, cancel);
        }

        public async Task<TickersInverseInfo> GetTickerInverse(string symbol, CancellationToken cancel = default)
        {
            return await _requestsSender.GetTickerInverse(symbol, cancel);
        }

        public async Task<TickersLinearInfo> GetTickerLinear(string symbol, CancellationToken cancel = default)
        {
            return await _requestsSender.GetTickerLinear(symbol, cancel);
        }

        public async Task<TickersOptionInfo> GetTickerOption(string symbol, CancellationToken cancel = default)
        {
            return await _requestsSender.GetTickerOption(symbol, cancel);
        }


        public async Task<TickersSpotInfo> GetTickersSpot(CancellationToken cancel = default)
        {
            return await _requestsSender.GetTickersSpotFromCache(cancel).ConfigureAwait(false);
        }

        public async Task<TickersInverseInfo> GetTickersInverse(CancellationToken cancel = default)
        {
            return await _requestsSender.GetTickersInverseFromCache(cancel).ConfigureAwait(false);
        }

        public async Task<TickersLinearInfo> GetTickersLinear(CancellationToken cancel = default)
        {
            return await _requestsSender.GetTickersLinearFromCache(cancel).ConfigureAwait(false);
        }

        public async Task<TickersOptionInfo> GetTickersOption(CancellationToken cancel = default)
        {
            return await _requestsSender.GetTickersOptionFromCache(cancel).ConfigureAwait(false);
        }


        public void Dispose()
        {
            _updateCacherWorker.Dispose();
        }
    }
}