//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Delivery.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int orderId { get; set; }
        public int subscribtionId { get; set; }
        public int employeeId { get; set; }
        public int deliveryTypeId { get; set; }
        public int status { get; set; }
        public Nullable<System.DateTime> receiveingDate { get; set; }
    
        public virtual DeliveryType DeliveryType { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Subscribtion Subscribtion { get; set; }
    }
}
