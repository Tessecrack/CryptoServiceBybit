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
            _requestsSender = new RequestsSender<BaseClient>(client);
            _updateCacherWorker = new UpdaterCacherWorker(_symbolsCacher, _requestsSender);
        }


        public void Dispose()
        {
            _requestsSender.Dispose();
            _updateCacherWorker.Dispose();
        }
    }
}