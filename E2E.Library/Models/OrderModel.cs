using System;
using System.Collections.Generic;
using System.Text;
using E2E.Library.Enums;

namespace E2E.Library.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public List<ProductModel> Products { get; set; } = new List<ProductModel>();

        public decimal TotalAmount { get; set; }

        public DateTime OrderDate { get; set; }

        public StatusEnum Status { get; set; } = StatusEnum.OutOfStock;

        public DeliveryStatusEnum DeliveryStatus { get; set; } = DeliveryStatusEnum.Pending;
    }
}
