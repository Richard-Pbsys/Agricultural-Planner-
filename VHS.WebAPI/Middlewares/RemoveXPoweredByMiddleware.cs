using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace VHS.WebAPI.Middlewares
{
    public class RemoveXPoweredByMiddleware
    {
        private readonly RequestDelegate _next;

        public RemoveXPoweredByMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.OnStarting(() =>
            {
                context.Response.Headers.Remove("X-Powered-By");
                return Task.CompletedTask;
            });

            await _next(context);
        }
    }
}
