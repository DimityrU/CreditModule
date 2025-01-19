using CreditModule.DomainModels.Enums;

namespace CreditModule.DomainModels
{
    public class Credit
    {
        public int CreditId { get; set; }
        public int CreditNumber { get; set; }
        public string ClientName { get; set; } 
        public string RequestDate { get; set; }
        public decimal RequestedSum { get; set; }
        public PaymentTypes PaymentType { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
