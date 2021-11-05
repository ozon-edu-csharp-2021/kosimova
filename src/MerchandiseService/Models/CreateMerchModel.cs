using MerchandiseService.HttpClients.Models;

namespace MerchandiseService.Models
{
    public class CreateMerchModel
    {
        public int EmployeeId { get; set;  }
        public MerchType MerchType { get; set; }
    }
}