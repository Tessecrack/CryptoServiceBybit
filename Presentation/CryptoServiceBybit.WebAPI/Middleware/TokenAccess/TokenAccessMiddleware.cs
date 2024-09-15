using CryptoServiceBybit.Domain.Models;

namespace CryptoServiceBybit.WebAPI.Middleware.TokenAccess
{
    public class TokenAccessMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _token;

        public TokenAccessMiddleware(RequestDelegate next, string token)
        {
            this._next = next;
            this._token = token;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];

            if (string.IsNullOrWhiteSpace(token) || !token.Equals(_token)) 
            {
                var currentTimeMs = DateTime.Now
                    .ToUniversalTime()
                    .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                BaseResponse badResponse = new BaseResponse()
                {
                    StatusCode = StatusCodes.Status403Forbidden,
                    Message = "You don't have access!",
                    Time = (long)currentTimeMs,
                };
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync<BaseResponse>(badResponse);
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
