namespace CreditModule.DomainModels
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int InvoiceNumber { get; set; }
        public decimal InvoiceTotal { get; set; }
    }
}