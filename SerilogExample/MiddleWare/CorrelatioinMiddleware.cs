using Serilog.Context;

namespace SerilogExample.MiddleWare
{
    public class CorrelationMiddleware : IMiddleware
    {
        // IMiddleware allows you to use the constructor for other DI services, 
        // but the 'next' delegate is provided in the method signature.
        public CorrelationMiddleware()
        {
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // 1. Resolve or Generate the Correlation ID
            if (!context.Request.Headers.TryGetValue("X-Correlation-ID", out var correlationId))
            {
                correlationId = Guid.NewGuid().ToString();
            }

            // 2. Add to Response Headers (so the client sees it)
            context.Response.Headers.TryAdd("X-Correlation-ID", correlationId);

            // 3. Push to Serilog Context
            // This ensures every log in this request scope carries the ID
            using (LogContext.PushProperty("CorrelationId", correlationId))
            {
                await next(context);
            }
        }
    }
}