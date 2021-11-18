using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregateModels.EmployeeAggregate;
using MerchandiseService.Domain.AggregateModels.MerchOrderAggregate;

namespace MerchandiseService.Domain.Contracts
{
    /// <summary>
    /// Репозиторий для управления сущностью <see cref="Employee"/>
    /// </summary>
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        /// <summary>
        /// Получить информацию о сотруднике по почте
        /// </summary>
        /// <param name="email">Почта сотрудника</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Объект заявки</returns>
        Task<Employee> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
       
        /// <summary>
        /// Получить информацию о сотруднике по идентификатору
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Объект заявки</returns>
        Task<Employee> GetByEmailAsync(int employeeId, CancellationToken cancellationToken = default);
    }
}