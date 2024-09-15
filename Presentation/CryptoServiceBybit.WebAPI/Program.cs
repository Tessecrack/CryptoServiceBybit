using CryptoServiceBybit.ServiceBybit;
using CryptoServiceBybit.WebAPI.Middleware.TokenAccess;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServiceBybitTestnet();
var app = builder.Build();

var tokenAccess = builder.Configuration["Token"];

//app.UseTokenAccessMiddleware(tokenAccess);
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/tickers/spot", async (BaseClient bybitService) =>
{
    var tickersSpot = await bybitService.GetTickersSpot();
    return Results.Json(tickersSpot);
});

app.MapGet("/api/tickers/inverse", async (BaseClient bybitService) =>
{
    var tickersInverse = await bybitService.GetTickersInverse();
    return Results.Json(tickersInverse);
});

app.MapGet("/api/tickers/spot/{symbol}", async (BaseClient bybitService, string symbol) =>
{
    var tickerSpot = await bybitService.GetTickerSpot(symbol);
    return Results.Json(tickerSpot);
});

app.MapGet("/api/tickers/inverse/{symbol}", async (BaseClient bybitService, string symbol) =>
{
    var tickerInverse = await bybitService.GetTickerInverse(symbol);
    return Results.Json(tickerInverse);
});

app.MapGet("/api/market/spot/{symbol}", async (BaseClient bybitService, string symbol) =>
{
    
});

app.Run();
