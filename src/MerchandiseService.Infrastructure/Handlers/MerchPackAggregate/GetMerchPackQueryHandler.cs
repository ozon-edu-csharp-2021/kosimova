using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregateModels.MerchOrderAggregate;
using MerchandiseService.Domain.AggregateModels.MerchPackAggregate;
using MerchandiseService.Domain.Contracts;
using MerchandiseService.Domain.Models;
using MerchandiseService.Infrastructure.Exceptions.MerchPackAggregate;
using MerchandiseService.Infrastructure.Queries.MerchPackAggregate;

namespace MerchandiseService.Infrastructure.Handlers.MerchPackAggregate
{
    /// <summary>
    /// Получить список товаров конкретногго мерча, чтобы далее создавать/изменять данный мерч:
    /// </summary>
    public class GetMerchPackQueryHandler : IRequestHandler<GetMerchPackItemsQuery, MerchPack>
    {
        private readonly IMerchPackRepository _merchPackRepository;

        public GetMerchPackQueryHandler(IMerchPackRepository merchPackRepository)
        {
            _merchPackRepository = merchPackRepository;
        }
        public async Task<MerchPack> Handle(GetMerchPackItemsQuery request, CancellationToken cancellationToken)
        {
            if (Enumeration.GetAll<MerchType>().All(x => x.Id != request.MerchType))
                throw new GetMerchPackException("Invalid merch type. Please type correctly");
            
            var result = await _merchPackRepository.GetByMerchTypeAsync(request.MerchType, cancellationToken);
            return result;
        }
    }
}