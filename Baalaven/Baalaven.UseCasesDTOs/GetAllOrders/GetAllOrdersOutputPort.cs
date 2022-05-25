using Baalaven.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Baalaven.UseCases.GetAllOrders
{
    public class GetAllOrdersOutputPort
    {
        public List<GetAllOrder> Orders { get; set; }
    }

    public class GetAllOrder
    {
        public DateTime OrderDate { get; private set; }
        public string ShipAddress { get; private set; }
        public string ShipCity { get; private set; }
        public string ShipCountry { get; private set; }
        public string ShipPostalCode { get; private set; }
        public DiscountType DiscountType { get; private set; }
        public double Discount { get; private set; }
        public ShippingType shippingType { get; private set; }
        public List<GetAllOrderDetail> OrderDetails { get; private set; }
        public GetAllOrder(DateTime orderDate, string shipAddress,
            string shipCity, string shipCountry, string shipPostalCode,
            DiscountType discountType, double discount, ShippingType shippingType)
        {
            OrderDate = orderDate;
            ShipAddress = shipAddress;
            ShipCity = shipCity;
            ShipCountry = shipCountry;
            ShipPostalCode = shipPostalCode;
            DiscountType = discountType;
            Discount = discount;
            this.shippingType = shippingType;
        }
        public void SetOrderDetails(List<GetAllOrderDetail> orderDetails) => OrderDetails = orderDetails;
    }

    public class GetAllOrderDetail
    {
        public string Product { get; private set; }
        public decimal UnitPrice { get; private set; }
        public short Quantity { get; private set; }

        public GetAllOrderDetail(string product, decimal unitPrice, short quantity)
        {
            Product = product;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
    }
}