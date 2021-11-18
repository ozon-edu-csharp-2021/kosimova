using System.Collections.Generic;
using MediatR;
using MerchandiseService.Domain.AggregateModels.MerchPackAggregate;

namespace MerchandiseService.Infrastructure.Queries.MerchPackAggregate
{
    /// <summary>
    /// Получить список товаров для конкретного типа мерча
    /// </summary>
    /// 
    public class GetMerchPackItemsQuery : IRequest<MerchPack>
    {
        /// <summary>
        /// Тип мерча
        /// </summary>
        ///
        public int MerchType { get; set; }
    }
}