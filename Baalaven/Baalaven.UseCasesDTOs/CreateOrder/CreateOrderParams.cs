using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baalaven.UseCasesDTOs.CreateOrder
{
    public class CreateOrderParams
    {
        public string CustomerId { get; set; }
        public string ShippAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPostalCode { get; set; }
        public List<CreateOrderDetailParams> OrderDetails { get; set; }
    }
}
