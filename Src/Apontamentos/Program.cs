using File.Import;
using System;
using Apontamento.App.Application.Interfaces;
using Apontamento.App.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Apontamento.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IProcessaApontamentos, ProcessaApontamentos>()
                .AddFileService()
                .BuildServiceProvider();

            var processa = serviceProvider.GetRequiredService<IProcessaApontamentos>();

            processa.Processar("./Files/data.csv");

            Console.ReadLine();
        }
    }
}
