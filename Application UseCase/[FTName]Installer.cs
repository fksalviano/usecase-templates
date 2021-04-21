using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Application.UseCases.[FTName].Repositories;
using Application.UseCases.[FTName].Abstractions;
using XPInc.Pix.Commons.Utils.ServiceInstallers;

namespace Application.UseCases.[FTName]
{
    public class [FTName]Installer : IServiceCollectionInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.TryAddSingleton<I[FTName]Repository, [FTName]Repository>();
            services.TryAddSingleton<[FTName]UseCase>();
            services.WithValidationSingleton<I[FTName]UseCase, [FTName]UseCase>(useCase =>
                new [FTName]ValidationUseCase(useCase));
        }
    }
}