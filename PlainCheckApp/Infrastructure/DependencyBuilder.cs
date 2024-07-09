using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Configuration;
using Serilog.Sinks;
using System;

namespace PlainCheckApp.Infrastructure
{
    internal static class DependencyBuilder
    {
        public static IServiceProvider ConfigureServices()
        {

            return new ServiceCollection()
            .AddTransient<MainForm>()
            .AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog(dispose: true))
            .BuildServiceProvider();
        }
    }
}
