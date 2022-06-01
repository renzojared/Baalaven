using Baalaven.Entities.Enums;

namespace Baalaven.Entities.POCOEntities
{
    public class PaymentCards
    {
        public int Id { get; set; }
        public CardType CardType { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpireDate { get; set; }
        public int CVVData { get; set; }
    }
}
