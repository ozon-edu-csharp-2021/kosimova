using System.Collections.Generic;
using MediatR;
using MerchandiseService.Domain.AggregateModels.MerchPackAggregate;

namespace MerchandiseService.Infrastructure.Queries.MerchPackAggregate
{
    /// <summary>
    /// Получить список всех товаров для формирования мерч пака
    /// </summary>
    /// 
    public class GetAllItemsQuery : IRequest<List<ItemType>>
    {
    }
}