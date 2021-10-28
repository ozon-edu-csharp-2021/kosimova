using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Models;
using MerchandiseService.Services.Interfaces;

namespace MerchandiseService.Services
{
    public class MerchandiseService : IMerchandiseService
    {
        public Task<MerchItemModel> Create(CreateMerchModel model, CancellationToken _)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<MerchItemModel>> GetByEmployeeId(int itemId, CancellationToken _)
        {
            throw new System.NotImplementedException();
        }
    }
}