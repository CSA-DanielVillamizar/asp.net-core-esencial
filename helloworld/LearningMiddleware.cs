using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace helloworld
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LearningMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LearningMiddleware> logger;
        private readonly IConfiguration configuration;

        public LearningMiddleware(RequestDelegate next, ILogger<LearningMiddleware> logger, IConfiguration configuration)
        {
            _next = next;
            this.logger = logger;
            this.configuration = configuration;
        }

        public Task Invoke(HttpContext httpContext)
        {
            logger?.LogInformation(configuration["mensaje"]);

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LearningMiddlewareExtensions
    {
        public static IApplicationBuilder UseLearningMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LearningMiddleware>();
        }
    }
}
