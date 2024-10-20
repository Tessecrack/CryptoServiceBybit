using CryptoServiceBybit.Domain.Models.Tickers;
using System.Collections.Concurrent;

namespace CryptoServiceBybit.Processor.Cache
{
    internal class SymbolsCacher
    {
        public TickersSpotInfo SpotInfo { get; set; }

        public TickersOptionInfo OptionInfo { get; set; }

        public TickersLinearInfo LinearInfo { get; set; }
    }
}
