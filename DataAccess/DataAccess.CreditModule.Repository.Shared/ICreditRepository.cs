using CreditModule.DomainModels;

namespace DataAccess.CreditModule.Repository.Shared;

public interface ICreditRepository 
{
    Task<IEnumerable<Credit>> GetCreditsWithInvoices();
    Task<IEnumerable<Payment>> GetStatusData();
}