using System;
using System.IO;
using System.Threading.Tasks;
using HTTPLogsParser;
using HTTPLogsParser.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace programming_task
{
    class Program
    {
        static async Task Main(string[] args)
        {

            using IHost host = CreateHostBuilder(args).Build();
            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            //TODO: Logger should be user with proper configurations, need further investigations
            //var logger = provider.GetService<ILogger>();
            //logger.LogTrace("Starting program");
            var mainEntry = provider.GetRequiredService<IMainEntry>();
            //logger.LogTrace("mainEntry.CollectDataAsync()");
            var requetsAnalysis = await mainEntry.CollectDataAsync();
            //logger.LogTrace($"Called mainEntry.CollectDataAsync() returned results{requetsAnalysis}");
        }


        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddLogging(configure => configure.AddConsole())
                            .AddScoped<IParser, Parser>(InitParser)
                            .AddScoped<IQueryBuilder, QueryBuilder>()
                            .AddScoped<IMainEntry, MainEntry>());

        private static Parser InitParser(IServiceProvider arg)
        {
            //Initiating parser with default file name
            return new Parser(new StreamReader( "programming-task-example-data.log"));
        }

        
    }
}
