using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregateModels.MerchPackAggregate;
using MerchandiseService.Domain.Models;
using MerchandiseService.Infrastructure.Queries.MerchPackAggregate;

namespace MerchandiseService.Infrastructure.Handlers.MerchPackAggregate
{
    /// <summary>
    /// Получить список всех товаров, чтобы далее создавать/изменять мерч пакет:
    /// </summary>
    public class GetAllItems : IRequestHandler<GetAllItemsQuery, List<ItemType>>
    {
        public async Task<List<ItemType>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            return Enumeration.GetAll<ItemType>().ToList();
        }
    }
}