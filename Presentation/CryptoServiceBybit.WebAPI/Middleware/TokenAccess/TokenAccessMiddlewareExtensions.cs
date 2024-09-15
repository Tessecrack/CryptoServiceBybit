namespace CryptoServiceBybit.WebAPI.Middleware.TokenAccess
{
    public static class TokenAccessMiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenAccessMiddleware(this IApplicationBuilder app, string tokenAccess) 
        { 
            app.UseMiddleware<TokenAccessMiddleware>(tokenAccess);
            return app;
        }
    }
}
