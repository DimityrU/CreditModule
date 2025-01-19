using CreditModule.DomainModels.Enums;

namespace CreditModule.DomainModels;

public class Payment
{
    public decimal Sum { get; set; }
    public PaymentTypes PaymentType { get; set; }

}