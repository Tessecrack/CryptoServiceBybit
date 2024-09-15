using CryptoServiceBybit.Domain.Models;
using System.Net.Http.Json;

class Program
{
    private static readonly string apiBaseAddress = "https://localhost:7009";
    public static void Main(string[] args)
    {
        var client = new HttpClient()
        {
            BaseAddress = new Uri(apiBaseAddress)
        };

        try
        {
            //var tickersResponse = client.GetFromJsonAsync<TickersSpotInfo>("/tickers/spot/HUETA?token=1111").Result;
            var response = client.GetAsync("/tickers/spot/HUETA?token=1111").Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var tickersResponse = response.Content.ReadFromJsonAsync<TickersSpotInfo>().Result;
                Console.WriteLine(tickersResponse.StatusCode);
                Console.WriteLine(tickersResponse.Message);
                foreach (var ticker in tickersResponse.Result.ListTickers)
                {
                    Console.WriteLine($"{ticker.Symbol}: {ticker.LastPrice}");
                }
            }
            else
            {
                Console.WriteLine(response.StatusCode);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        Console.ReadKey();
    }
}
