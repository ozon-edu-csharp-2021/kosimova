using System;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpModels;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Controllers.V1
{
    [ApiController]
    [Route("v1/api/merch")]
    public class MerchandiseController : ControllerBase
    {

        [HttpPost("create")]
        public async Task<ActionResult<CreateMerchResponse>> CreateEmployeeMerch(CreateMerchRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpGet("getEmployeeHistory")]
        public async Task<ActionResult<GetMerchHistoryResponse>> GetEmployeeHistory(GetMerchHistoryRequest request)
        {
            throw new NotImplementedException();
        }
    }
}