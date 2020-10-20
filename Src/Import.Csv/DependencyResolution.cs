using Microsoft.Extensions.DependencyInjection;
using File.Import.Interfaces;
using File.Import.Services;

namespace File.Import
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddFileService(this IServiceCollection service)
        {
            service.AddSingleton<IFileService, FileService>();

            return service;
        }
    }
}
