using Microsoft.Extensions.Options;

namespace specifiedbehavior.web.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string[] _paths;
        private const string APIKEYNAME = "apikey";

        public ApiKeyMiddleware(RequestDelegate next, IOptions<ApiKeyMiddlewareOptions> options)
        {
            _next = next;
            _paths = options.Value.Paths;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (_paths.Any(path => context.Request.Path.StartsWithSegments(path, StringComparison.OrdinalIgnoreCase)))
            {
                if (!context.Request.Cookies.ContainsKey(APIKEYNAME))
                {
                    context.Response.StatusCode = 400; // Bad Request
                    await context.Response.WriteAsync("User Key is missing");
                    return;
                }

                var apikey = context.Request.Cookies[APIKEYNAME];
                if (!apikey.Equals("A3921365-2A30-44D2-8127-025DA175362F")) // replace "Your_Api_Key" with your real API key
                {
                    context.Response.StatusCode = 401; // Unauthorized
                    await context.Response.WriteAsync("Unauthorized client");
                    return;
                }
            }

            await _next.Invoke(context);
        }
    }

    public class ApiKeyMiddlewareOptions
    {
        public string[] Paths { get; set; }
    }

}
