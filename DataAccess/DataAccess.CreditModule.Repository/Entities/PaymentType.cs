using System.ComponentModel.DataAnnotations;

namespace DataAccess.CreditModule.Repository.Entities
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }
        public string Name { get; set; }

    }
}