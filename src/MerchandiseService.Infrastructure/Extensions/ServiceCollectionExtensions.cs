using System;
using MediatR;
using MerchandiseService.Infrastructure.Handlers.MerchOrderAggregate;
using MerchandiseService.Infrastructure.Handlers.MerchPackAggregate;

namespace Microsoft.Extensions.DependencyInjection
{
        /// <summary>
        /// Класс расширений для типа <see cref="IServiceCollection"/> для регистрации инфраструктурных сервисов
        /// </summary>
        public static class ServiceCollectionExtensions
        {
            /// <summary>
            /// Добавление в DI контейнер инфраструктурных сервисов
            /// </summary>
            /// <param name="services">Объект IServiceCollection</param>
            /// <returns>Объект <see cref="IServiceCollection"/></returns>
            public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
            {
                services.AddMediatR(typeof(CreateMerchOrderCommandHandler).Assembly);
                services.AddMediatR(typeof(CreateMerchPackCommandHandler).Assembly);
                services.AddMediatR(typeof(GetEmployeeOrdersQueryHandler).Assembly);
                services.AddMediatR(typeof(GetAllItemTypesQueryHandler).Assembly);
                services.AddMediatR(typeof(GetMerchPackQueryHandler).Assembly);
                
                return services;
            }
            /// <summary>
            /// Добавление в DI контейнер инфраструктурных репозиториев
            /// </summary>
            /// <param name="services">Объект IServiceCollection</param>
            /// <returns>Объект <see cref="IServiceCollection"/></returns>
            public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
            {
                return services;
            }
        }
}