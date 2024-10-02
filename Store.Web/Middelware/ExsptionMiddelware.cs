using Store.Serveses.HandelResponse;
using System.Text.Json;

namespace Store.Web.Middelware
{
    public class ExsptionMiddelware
    {
        private readonly RequestDelegate next;
        private readonly IHostEnvironment environment;
        private readonly ILogger<ExsptionMiddelware> logger;

        public ExsptionMiddelware(RequestDelegate next, IHostEnvironment environment, ILogger<ExsptionMiddelware> logger)
        {
            this.next = next;
            this.environment = environment;
            this.logger = logger;
        }



        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;
                var res = environment.IsDevelopment()
                    ? new CustomExsption(500, ex.Message, ex.StackTrace)
                    : new CustomExsption(500, ex.Message);
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(res, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
