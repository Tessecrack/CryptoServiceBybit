using CryptoServiceBybit.Domain.Models.Tickers;
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
            var response = client.GetFromJsonAsync<TickersOptionInfo>("/api/tickers/option").Result;
            var result = response.Result;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        Console.ReadKey();
    }
}
