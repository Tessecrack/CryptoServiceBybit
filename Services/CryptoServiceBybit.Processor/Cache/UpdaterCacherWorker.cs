using CryptoServiceBybit.Processor.ClientWrapper;
using CryptoServiceBybit.ServiceBybit;

namespace CryptoServiceBybit.Processor.Cache
{
    internal class UpdaterCacherWorker : IDisposable
    {
        public SymbolsCacher SymbolsCacher { get; private set; }

        private Thread _thread;

        RequestsSender<BaseClient> _sender;

        private bool _disposed;


        private int timeoutMs = 500;
        public UpdaterCacherWorker(SymbolsCacher _cacher, RequestsSender<BaseClient> sender)
        {
            SymbolsCacher = _cacher;

            _thread = new Thread(UpdateWork);

            _sender = sender;

            Run();
        }

        public void Run()
        {
            _thread.Start();
        }

        private void UpdateWork()
        {
            while (!_disposed)
            {
                SymbolsCacher.SpotInfo = _sender.GetTickersSpot().Result;
                Thread.Sleep(timeoutMs);

                SymbolsCacher.OptionInfo = _sender.GetTickersOption().Result;
                Thread.Sleep(timeoutMs);

                SymbolsCacher.LinearInfo = _sender.GetTickersLinear().Result;
                Thread.Sleep(timeoutMs);
            }
        }

        public void Dispose()
        {
            _thread.Join(4000);
            _thread.Interrupt();
            _disposed = true;
        }
    }
}
