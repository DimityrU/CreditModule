using ApplicationLayer.CreditModule.Dto.Outgoing;
using CreditModule.DomainModels.Enums;

namespace ApplicationLayer.CreditModule.Service.Shared;

public interface ICreditService
{
    Task<GetAllCreditsResponse> GetCreditsWithInvoices();
    Task<GetStatusDataResponse> GetStatusData(PaymentTypes paymentType);
}