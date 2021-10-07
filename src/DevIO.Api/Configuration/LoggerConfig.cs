using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace DevIO.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfig(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "040f61203bc3473f9d776373daab1364";
                o.LogId = new Guid("5829d5a7-4fe5-4c91-bed4-0184c010543b");
            });

            /*services.AddLogging(builder =>
            {
                builder.AddElmahIo(o =>
                {
                    o.ApiKey = "040f61203bc3473f9d776373daab1364";
                    o.LogId = new Guid("5829d5a7-4fe5-4c91-bed4-0184c010543b");
                });
                builder.AddFilter<ElmahIoLoggerProvider>(category: null, LogLevel.Warning);
            });*/

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}
