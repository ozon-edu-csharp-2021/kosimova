using System;
using System.Collections;
using System.Collections.Generic;

namespace MerchandiseService.HttpClients.Models
{
    public class GetMerchHistoryResponse
    {
        private IEnumerable<EmployeeMerchItem> EmployeeMerches { get; set; }
    }
    public class EmployeeMerchItem
    {
        public MerchType MerchType { get; set; } // тип мёрча
        public DateTime DateOfIssue { get; set; } // дата выдачи мёрча
    }
}