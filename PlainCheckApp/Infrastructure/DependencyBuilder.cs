using Microsoft.Extensions.DependencyInjection;
using PlainCheckApp.Interfaces;
using PlainCheckApp.Services;
using Serilog;
using System;

namespace PlainCheckApp.Infrastructure
{
    internal static class DependencyBuilder
    {
        public static IServiceProvider ConfigureServices() =>
            new ServiceCollection()
            .AddTransient<MainForm>()
            .AddTransient<AboutForm>()
            .AddTransient<ILineLoader, CsvLoader>()
            .AddTransient<IGraphicDraw, PngGraphicDraw>()
            .AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog(dispose: true))
            .BuildServiceProvider();
    }
}
