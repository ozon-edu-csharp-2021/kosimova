using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpModels;
using MerchandiseService.Models;
using MerchandiseService.Services.Interfaces;

namespace MerchandiseService.Services
{
    public class MerchandiseService : IMerchandiseService
    {
        public async Task<MerchItemModel> Create(CreateMerchModel model, CancellationToken _)
        {
            return new MerchItemModel(1, model.EmployeeId, DateTime.Now, MerchType.WelcomePack);
        }

        public async Task<List<MerchItemModel>> GetByEmployeeId(int employeeId, CancellationToken _)
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