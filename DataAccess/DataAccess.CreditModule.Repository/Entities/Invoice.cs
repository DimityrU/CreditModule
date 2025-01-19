using System.ComponentModel.DataAnnotations;

namespace DataAccess.CreditModule.Repository.Entities
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public int InvoiceNumber { get; set; }
        public int InvoiceTotal { get; set; }
        public int CreditId { get; set; }
    }
}