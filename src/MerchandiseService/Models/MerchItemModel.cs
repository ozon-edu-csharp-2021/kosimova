using System;
using MerchandiseService.HttpModels;

namespace MerchandiseService.Models
{
    public class MerchItemModel
    {
        public MerchItemModel(int itemId, int employeeId, DateTime dateOfIssue, MerchType type)
        {
            ItemId = itemId;
            EmployeeId = employeeId;
            DateOfIssue = dateOfIssue;
            MerchType = type;
        }
        public int ItemId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateOfIssue { get; set; }
        public MerchType MerchType { get; set; }
    }
}