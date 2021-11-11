using System;
using MediatR;

namespace MerchandiseService.Infrastructure.Commands.CreateMerchRequest
{
    public class CreateMerchRequestCommand : IRequest
    {
        public int EmployeeId { get; init; }
        
        public int MerchType { get; init; }
        
        public int MerchStatus { get; init; }

        public int? ClothingSize { get; init; }
        
        public DateTime? CreatedDate { get; init; }

        public DateTime? ClosedDate { get; init; }
    }
}