using Baalaven.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Baalaven.Presenters.GetAllOrdersDTO
{
    public class GetAllOrdersOutput
    {
        public List<Order> Orders { get; set; }
    }

    public class Order
    {
        public DateTime OrderDate { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPostalCode { get; set; }
        public DiscountType DiscountType { get; set; }
        public double Discount { get; set; }
        public ShippingType shippingType { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }

    public class OrderDetail
    {
        public string Product { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
    }
}
