using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregateModels.MerchOrderAggregate;

namespace MerchandiseService.Domain.Contracts
{
    /// <summary>
    /// Репозиторий для управления сущностью <see cref="MerchOrder"/>
    /// </summary>
    public interface IMerchOrderRepository : IGenericRepository<MerchOrder>
    {
        /// <summary>
        /// Получить информацию о заказе по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор заказа</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Объект заявки</returns>
        Task<MerchOrder> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Получить информацию о всех мерчах сотрудника
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Объект заявки</returns>
        Task<List<MerchOrder>> GetByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken = default);
    }
}