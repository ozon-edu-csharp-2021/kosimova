using System;
using MerchandiseService.Domain.Exceptions.MerchOrderAggregate;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregateModels.MerchOrderAggregate
{
    public class MerchOrder : Entity
    {
        public MerchOrder(
                    EmployeeId id, 
                    ClothingSize size, 
                    MerchType merchType, 
                    MerchOrderPriority priority,
                    MerchOrderStatus status)
        {
            EmployeeId = id;
            MerchType = merchType;
            Priority = priority;
            CreatedDate = new CreatedDate(DateTime.Now);
            SetClothingSize(size);
            Status = status;
        }
        public EmployeeId EmployeeId { get; }
        public ClothingSize ClothingSize { get; private set; }
        public MerchType MerchType { get; }
        public MerchOrderPriority Priority { get; }
        public MerchOrderStatus Status { get; private set; }
        public CreatedDate CreatedDate { get; }
        public GaveOutDate GaveOutDate { get; private set; }
        
        
        public void SetClothingSize(ClothingSize size)
        {
            // в случае если размер сотрудника не указан (например события из кафки), ставим по умолчанию:
            if (size is null)
                ClothingSize = ClothingSize.M;
        }
        
        /// <summary>
        /// Изменение статуса заказа
        /// </summary>
        /// 
        public void ChangeStatus(MerchOrderStatus status)
        {
            if (Status == MerchOrderStatus.Cancelled)
                throw new MerchOrderStatusException($"Order was cancelled. Change status unavailable");
            if (Status == MerchOrderStatus.GaveOut)
                throw new MerchOrderStatusException($"Order was gave out. Change status unavailable");
            Status = status;
        }

        /// <summary>
        /// Указание даты выдачи заказа
        /// </summary>
        ///
        public void SetGaveoutDate(DateTime date)
        {
            if (GaveOutDate != null)
                throw new DateExceptions("Gave out date was already set");
            if (date <= CreatedDate.Value)
                throw new DateExceptions("Gave out date can't be earlier that created date");
            GaveOutDate = new GaveOutDate(date);
        }
    }
}