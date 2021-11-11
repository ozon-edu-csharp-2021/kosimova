using System;
using MerchandiseService.Domain.Exceptions;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregateModels.MerchItemAggreagate
{
    /// <summary>
    /// Заявка на мерч для сотрудника
    /// </summary>
    public class MerchRequest : Entity
    {
        public MerchRequest(int employeeId, 
                            MerchType merchType, 
                            MerchStatus merchStatus, 
                            ClothingSize clothingSize, 
                            DateTime? createdDate,
                            DateTime? closedDate)
        {
            EmployeeId = employeeId;
            MerchType = merchType;
            ClothingSize = clothingSize;
            MerchStatus = merchStatus;
            CreatedDate = createdDate;
            ClosedDate = closedDate;
        }
        /// <summary>
        /// Идентификатор работника
        /// </summary>
        public int EmployeeId { get; private set; }
        
        /// <summary>
        /// Тип мерча
        /// </summary>
        public MerchType MerchType { get; private set; }
        
        /// <summary>
        /// Статус заявки мерча
        /// </summary>
        public MerchStatus MerchStatus { get; private set; }
        
        /// <summary>
        /// Размер одежды
        /// </summary>
        public ClothingSize ClothingSize { get; private set; }
        
        /// <summary>
        /// Дата создания заявки
        /// </summary>
        public DateTime? CreatedDate { get; }
        
        /// <summary>
        /// Дата закрытия заказа
        /// </summary>
        public DateTime? ClosedDate { get; }
        
        /// <summary>
        /// Смена статуса у заявки на мерч
        /// </summary>
        /// <param name="status"></param>
        /// <exception cref="Exception"></exception>
        public void ChangeStatus(MerchStatus status)
        {
            if (MerchStatus.Equals(AggregateModels.MerchItemAggreagate.MerchStatus.Cancelled))
                throw new MerchStatusException($"Request in closed. Change status unavailable");
            MerchStatus = status;
        }
        
        
        
        
    }
}