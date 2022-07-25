using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

using Baalaven.IoC;
using Baalaven.WebExceptionsPresenter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

[assembly: TestFramework("Baalaven.WebApi.Startup", "Baalaven.Tests")]

namespace Baalaven.Tests
{
    public class Startup : DependencyInjectionTestFramework
    {
        public Startup(IMessageSink messageSink) : base(messageSink)
        {
        }

        //Override the method of createhostbuilder to register the configuration and service here
        protected override IHostBuilder CreateHostBuilder(AssemblyName assemblyName)
        {
            var hostBuilder = base.CreateHostBuilder(assemblyName);
            hostBuilder
                //Registration configuration
                .ConfigureAppConfiguration(builder =>
                {
                    builder
                        .AddInMemoryCollection(new Dictionary()
                        {
                            {"UserName", "Alice"}
                        })
                        .AddJsonFile("appsettings.json")
                        ;
                })
                //Register custom service
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton();
                    if (context.Configuration.GetAppSetting("XxxEnabled"))
                    {
                        services.AddSingleton();
                    }
                })
                ;

            return hostBuilder;
        }

        protected override void Configure(IServiceProvider provider)
        {
            //Some test data that needs to be initialized can be put here
        }
    }
}
