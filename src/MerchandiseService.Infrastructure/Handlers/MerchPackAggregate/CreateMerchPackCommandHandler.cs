using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregateModels.MerchOrderAggregate;
using MerchandiseService.Domain.AggregateModels.MerchPackAggregate;
using MerchandiseService.Domain.Contracts;
using MerchandiseService.Domain.Models;
using MerchandiseService.Infrastructure.Commands.CreateMerchPack;
using MerchandiseService.Infrastructure.Exceptions.MerchPackAggregate;

namespace MerchandiseService.Infrastructure.Handlers.MerchPackAggregate
{
    public class CreateMerchPackCommandHandler : IRequestHandler<CreateMerchPackCommand, MerchPack>
    {
        private readonly IMerchPackRepository _merchPackRepository;

        public CreateMerchPackCommandHandler(IMerchPackRepository merchPackRepository)
        {
            _merchPackRepository = merchPackRepository;
        }

        public async Task<MerchPack> Handle(CreateMerchPackCommand request, CancellationToken cancellationToken)
        {
            var merchPack = await _merchPackRepository.GetByMerchTypeAsync(request.MerchType, cancellationToken);
            if (merchPack is not null && merchPack.ItemTypes.Any(x => x.Id == request.ItemType))
                throw new CreateMerchPackException(
                    "This item already exist in this merchPack. Please, choose another item");
            if (merchPack is null)
            {
                merchPack = new MerchPack(
                    Enumeration.GetAll<MerchType>().FirstOrDefault(x => x.Id == request.MerchType),
                    new List<ItemType>()
                    {
                        Enumeration.GetAll<ItemType>().FirstOrDefault(x => x.Id == request.ItemType)
                    }
                );
                await _merchPackRepository.CreateAsync(merchPack, cancellationToken);
            }
            else
            {
                merchPack.ItemTypes.Add( Enumeration.GetAll<ItemType>().FirstOrDefault(x => x.Id == request.ItemType));
                await _merchPackRepository.UpdateAsync(merchPack, cancellationToken);
            }

            return merchPack;
        }
    }
}