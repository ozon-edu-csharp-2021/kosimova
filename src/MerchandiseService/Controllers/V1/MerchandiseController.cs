using System;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpClients.Models;
using MerchandiseService.Models;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Controllers.V1
{
    [ApiController]
    [Route("v1/api/merch")]
    public class MerchandiseController : ControllerBase
    {
        private readonly Services.MerchandiseService _merchandiseService;
        
        [HttpPost("create")]
        public async Task<ActionResult> CreateEmployeeMerch(CreateMerchRequest request, CancellationToken token)
        {
            var item = await _merchandiseService.Create(new CreateMerchModel()
            {
                EmployeeId = request.EmployeeId,
                MerchType = request.MerchType
            }, token);
            return Ok();
        }

        [HttpGet("getEmployeeHistory")]
        public async Task<ActionResult<GetMerchHistoryResponse>> GetMerchHistory([FromQuery]GetMerchHistoryRequest request, CancellationToken token)
        {
            var result = await _merchandiseService.GetByEmployeeId(request.EmployeeId, token);
            return Ok(result);
        }
    }
}