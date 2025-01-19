using CreditModule.DomainModels.Enums;

namespace CreditModule.DomainModels
{
    public class Status
    {
        public PaymentTypes PaymentType { get; set; }
        public decimal PaymentTypeTotal { get; set; }
        public decimal PaymentTypePercentage { get; set; }
        
    }
}
