using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Models;

namespace MerchandiseService.Services.Interfaces
{
    public interface IMerchandiseService
    {
        Task<MerchItemModel> CreateAsync(CreateMerchModel model,CancellationToken _);
        
        Task<List<MerchItemModel>> GetByEmployeeIdAsync(int itemId, CancellationToken _);
    }
}