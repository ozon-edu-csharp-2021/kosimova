using System.Collections.Generic;
using MediatR;
using MerchandiseService.Domain.AggregateModels.MerchOrderAggregate;

namespace MerchandiseService.Infrastructure.Queries.MerchOrderAggregate
{
    /// <summary>
    /// Получить инфо о всех выданных сотруднику мерчах
    /// </summary>
    /// 
    public class GetEmployeeOrdersQuery : IRequest<List<MerchOrder>>
    {
        /// <summary>
        /// Получить данные сотрудника по почте
        /// </summary>
        ///
        public string Email { get; }
    }
}