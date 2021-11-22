using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregateModels.MerchPackAggregate;

namespace MerchandiseService.Domain.Contracts
{
    /// <summary>
    /// Репозиторий для управления сущностью <see cref="MerchPack"/>
    /// </summary>
    public interface IMerchPackRepository : IGenericRepository<MerchPack>
    {
        /// <summary>
        /// Получить информацию о товарах для типа мерча
        /// </summary>
        /// <param name="merchType">Тип мерча</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Объект заявки</returns>
        Task<MerchPack> GetByMerchTypeAsync(int merchType, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Получить информацию о всех мерч пакетах
        /// </summary>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Объект заявки</returns>
        Task<List<MerchPack>> GetAllAsync(CancellationToken cancellationToken = default);

    }
}