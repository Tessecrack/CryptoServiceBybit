using CryptoServiceBybit.Domain.Models.Tickers;
using CryptoServiceBybit.ServiceBybit;

namespace CryptoServiceBybit.Processor.Processors
{
    public class RequestProcessor<TClient> where TClient : BaseClient
    {
        private readonly TClient _client;

        private TaskQueue _queue;

        public RequestProcessor(TClient client)
        {
            _client = client;
            _queue = new TaskQueue();
        }

        public async Task<TickersSpotInfo> GetTickersSpot(CancellationToken cancel = default)
        {
            return await _queue.Enqueue(() => _client.GetTickersSpot());
        }

        public async Task<TickersInverseInfo> GetTickersInverse(CancellationToken cancel = default)
        {
            return await _queue.Enqueue(() => _client.GetTickersInverse());
        }

        public async Task<TickersLinearInfo> GetTickersLinear(CancellationToken cancel = default)
        {
            return await _queue.Enqueue(() => _client.GetTickersLinear());
        }

        public async Task<TickersOptionInfo> GetTickersOption(CancellationToken cancel = default)
        {
            return await _queue.Enqueue(() => _client.GetTickersOption());
        }
    }
}