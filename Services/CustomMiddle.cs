namespace WebCustomMiddleware.Services
{
    public class CustomMiddle
    {
        private readonly RequestDelegate _next;

        public CustomMiddle(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            // Do something before the next middleware
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Not Authorized");
                return;
            }
            await _next(context);
            // Do something after the next middleware
        }
    }
}
