using System;
using MerchandiseService.HttpModels;

namespace MerchandiseService.Models
{
    public class MerchItemModel
    {
        public int ItemId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateOfIssue { get; set; }
        public MerchType MerchType { get; set; }
    }
}