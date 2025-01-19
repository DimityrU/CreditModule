using System.ComponentModel.DataAnnotations;

namespace DataAccess.CreditModule.Repository.Entities;

public class Credit
{
    [Key]
    public int CreditId { get; set; }
    public int CreditNumber { get; set; }
    public string ClientName { get; set; }
    public string RequestDate { get; set; }
    public int RequestedSum { get; set; }
    public int PaymentTypeId { get; set; }
    public Invoice Invoice { get; set; }

}