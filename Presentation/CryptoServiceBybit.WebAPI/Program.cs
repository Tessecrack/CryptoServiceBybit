using CryptoServiceBybit.Processor.DI;
using CryptoServiceBybit.Processor.Processors;
using CryptoServiceBybit.ServiceBybit;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddServiceBybitTestnet();
builder.Services.AddServiceBybit();
builder.Services.AddRequestsProcessor<BaseClient>();

var app = builder.Build();

var tokenAccess = builder.Configuration["Token"];

//app.UseTokenAccessMiddleware(tokenAccess);
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/tickers/spot", async (RequestProcessor<BaseClient> bybitService) =>
{
    var tickersSpot = await bybitService.GetTickersSpot();
    Console.WriteLine($"[{DateTime.Now}]Request: [/api/tickers/spot]");
    return Results.Json(tickersSpot);
});

app.MapGet("/api/tickers/inverse", async (RequestProcessor<BaseClient> bybitService) =>
{
    var tickersInverse = await bybitService.GetTickersInverse();
    Console.WriteLine($"[{DateTime.Now}]Request: [/api/tickers/inverse]");
    return Results.Json(tickersInverse);
});

app.MapGet("/api/tickers/linear", async (RequestProcessor<BaseClient> bybitService) =>
{
    var tickersLinear = await bybitService.GetTickersLinear();
    Console.WriteLine($"[{DateTime.Now}]Request: [/api/tickers/linear]");
    return Results.Json(tickersLinear);
});

app.MapGet("/api/tickers/option", async (RequestProcessor<BaseClient> bybitService) =>
{
    var tickersOption = await bybitService.GetTickersOption();
    Console.WriteLine($"[{DateTime.Now}]Request: [/api/tickers/option]");
    return Results.Json(tickersOption);
});

app.MapGet("/api/tickers/spot/{symbol}", async (RequestProcessor<BaseClient> bybitService, string symbol) =>
{
    var tickerSpot = await bybitService.GetTickerSpot(symbol);
    return Results.Json(tickerSpot);
});

app.MapGet("/api/tickers/inverse/{symbol}", async (RequestProcessor<BaseClient> bybitService, string symbol) =>
{
    var tickerInverse = await bybitService.GetTickerInverse(symbol);
    return Results.Json(tickerInverse);
});

app.MapGet("/api/tickers/linear/{symbol}", async (RequestProcessor<BaseClient> bybitService, string symbol) =>
{
    var tickerLinear = await bybitService.GetTickerLinear(symbol);
    return Results.Json(tickerLinear);
});

app.MapGet("/api/tickers/option/{symbol}", async (RequestProcessor<BaseClient> bybitService, string symbol) =>
{
    var tickerOption = await bybitService.GetTickerOption(symbol);
    return Results.Json(tickerOption);
});

app.MapGet("/api/market/kline/spot/{symbol}", async (RequestProcessor<BaseClient> bybitService, string symbol, string timeframe, int? limit) =>
{
    int lim = limit == null ? 10 : limit.Value;
    var priceInfoSpot = await bybitService.GetPriceKline(symbol, 0, 0, timeframe, "spot", lim);
    return Results.Json(priceInfoSpot);
});

app.MapGet("/api/market/kline/inverse/{symbol}", async (RequestProcessor<BaseClient> bybitService, string symbol, string timeframe, int? limit) =>
{
    int lim = limit == null ? 10 : limit.Value;
    var priceInfoInverse = await bybitService.GetPriceKline(symbol, 0, 0, timeframe, "inverse", lim);
    return Results.Json(priceInfoInverse);
});

app.Run();
