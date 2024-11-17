using Data.Interfaces;
using Data.Services;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;

namespace TDD_CMS24_Martin
{
    public class Cringe
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IHost _host = Host.CreateDefaultBuilder()
                .ConfigureServices((services) =>
                {
                    services.AddSingleton<IShippingCompanyService<ShippingCompany>, ShippingCompanyService<ShippingCompany>>();
                })
                .Build();

            var app = _host.Services.GetRequiredService<ShippingCompanyService<ShippingCompany>>();
            app.Run();
        }
    }
}