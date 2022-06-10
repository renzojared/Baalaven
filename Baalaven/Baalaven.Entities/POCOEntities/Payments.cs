using Baalaven.Entities.Enums;

namespace Baalaven.Entities.POCOEntities
{
    public class Payments
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal AmountPayable { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
