using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Models;

namespace MerchandiseService.Services.Interfaces
{
    public interface IMerchandiseService
    {
        Task<MerchItemModel> Create(CreateMerchModel model,CancellationToken _);
        
        Task<List<MerchItemModel>> GetByEmployeeId(int itemId, CancellationToken _);
    }
}