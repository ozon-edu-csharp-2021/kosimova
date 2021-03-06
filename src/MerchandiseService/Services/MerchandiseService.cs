using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpClients.Models;
using MerchandiseService.Models;
using MerchandiseService.Services.Interfaces;

namespace MerchandiseService.Services
{
    public class MerchandiseService : IMerchandiseService
    {
        public async Task<MerchItemModel> CreateAsync(CreateMerchModel model, CancellationToken token)
        {
            return new MerchItemModel(1, model.EmployeeId, DateTime.Now, MerchType.WelcomePack);
        }

        public async Task<List<MerchItemModel>> GetByEmployeeIdAsync(int employeeId, CancellationToken _)
        {
            return new List<MerchItemModel>()
            {
                new MerchItemModel(1, employeeId, DateTime.Now, MerchType.WelcomePack),
                new MerchItemModel(2, employeeId, DateTime.Now, MerchType.ConferenceListenerPack),
                new MerchItemModel(3, employeeId, DateTime.Now, MerchType.ConferenceSpeakerPack)
            };
        }
    }
}