using System.Collections.Generic;
using MediatR;
using MerchandiseService.Domain.AggregateModels.MerchPackAggregate;

namespace MerchandiseService.Infrastructure.Commands.CreateMerchPack
{
    public class CreateMerchPackCommand : IRequest<MerchPack>
    {
        /// <summary>
        /// Тип мерча
        /// </summary>
        public int MerchType { get; }
        
        /// <summary>
        /// Тип товарa для пакета
        /// </summary>
        public int ItemType  { get; }
    }
}