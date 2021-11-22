using MediatR;
using MerchandiseService.Domain.AggregateModels.MerchOrderAggregate;

namespace MerchandiseService.Infrastructure.Commands.CreateMerchOrder
{
    public class CreateMerchOrderCommand : IRequest<MerchOrder>
    {
        /// <summary>
        /// Почта сотрудника
        /// </summary>
        public string Email { get; }
        
        /// <summary>
        /// Размер сотрудника
        /// </summary>
        public int ClothingSize { get; private set; }
        
        /// <summary>
        /// Тип мерча
        /// </summary>
        public int MerchType { get; }
    }
}