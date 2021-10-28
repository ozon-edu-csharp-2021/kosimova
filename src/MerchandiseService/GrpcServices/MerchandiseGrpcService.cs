using System;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using MerchandiseService.Grpc;
using MerchandiseService.Models;
using MerchandiseService.Services.Interfaces;
using MerchType = MerchandiseService.HttpModels.MerchType;
using Google.Protobuf.WellKnownTypes;
using Enum = System.Enum;

namespace MerchandiseService.GrpcServices
{
    public class MerchandiseGrpcService : MerchandiseGrpc.MerchandiseGrpcBase
    {
        private readonly IMerchandiseService _service;

        public override async Task<CreateMerchResponse> CreateEmployeeMerch(CreateMerchRequest request, ServerCallContext context)
        {
            var item = await _service.Create(new CreateMerchModel()
            {
                EmployeeId = request.EmployeeId,
                MerchType = (MerchType)Enum.Parse(typeof(MerchType), request.MerchType.ToString())
             //   MerchType = request.MerchType
            }, context.CancellationToken);
            return (new CreateMerchResponse()
            {
                Status = item.ItemId == 0 ? "FAILURE" : "SUCCESS"
            });
        }

        public override async Task<GetMerchHistoryResponse> GetMerchHistory(GetMerchHistoryRequest request, ServerCallContext context)
        {
            var employeeMerchs = await _service.GetByEmployeeId(request.EmployeeId, context.CancellationToken);
            return new GetMerchHistoryResponse()
            {
                EmployeeMerches = { employeeMerchs.Select(x => new EmployeeMerchItem()
                {
                    MerchType = (Grpc.MerchType)Enum.Parse(typeof(Grpc.MerchType), x.MerchType.ToString()),
                    DateOfIssue = Timestamp.FromDateTime(x.DateOfIssue)
                }) }
            };
        }
    }
}