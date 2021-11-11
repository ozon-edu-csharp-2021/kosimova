using System.Collections.Generic;
using MediatR;

namespace MerchandiseService.Infrastructure.Commands.CreateMerchRequest
{
    public class CreateMerchPackItem : IRequest
    {
        public int MerchType { get; init; }
        public List<int> Items { get; init; }
    }
}