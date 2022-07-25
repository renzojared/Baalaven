using System;
using System.Collections.Generic;
using AspectCore.Configuration;
using AspectCore.DependencyInjection;
using AspectCore.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Baalaven.IoC;

namespace Baalaven.UTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IHostBuilder CreateHostBuilder()
        {
            return new HostBuilder()
                .ConfigureAppConfiguration(builder =>
                {                    
                    builder
                        .AddInMemoryCollection(new Dictionary<string, string>()
                        {
                            {"UserName", "Alice"}
                        })
                        .AddJsonFile("appsettings.json")
                        ;
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddBaalavenServices(Configuration);
                })
                ;
        }        
    }
}
