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
            var responseSpot = client.GetAsync("/api/tickers/spot").Result;
            Thread.Sleep(1000);
            var responseInverse = client.GetAsync("/api/tickers/inverse").Result;
            if (responseSpot.StatusCode == System.Net.HttpStatusCode.OK 
                && responseInverse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var tickersSpotResponse = responseSpot.Content.ReadFromJsonAsync<TickersSpotInfo>().Result;
                var tickersInverseResponse = responseInverse.Content.ReadFromJsonAsync<TickersInverseInfo>().Result;

                var listSpotTickers = tickersSpotResponse.Result.ListTickers;
                var listInverseTickers = tickersInverseResponse.Result.ListTickers;

                var maxLength = Math.Max(listSpotTickers.Length, listInverseTickers.Length);
                Console.WriteLine("symbols:");
                for (int i = 0; i < maxLength; ++i)
                {
                    if (i < listSpotTickers.Length)
                    {
                        Console.Write("SPOT: " + listSpotTickers[i].Symbol + " ");
                    }
                    if (i < listInverseTickers.Length)
                    {
                        Console.Write("INVERSE: " + listInverseTickers[i].Symbol + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine(responseSpot.StatusCode);
            }


        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        Console.ReadKey();
    }
}
