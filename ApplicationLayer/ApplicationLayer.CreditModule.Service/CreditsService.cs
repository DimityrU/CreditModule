using System.Net;
using ApplicationLayer.CreditModule.Dto.DTOs;
using ApplicationLayer.CreditModule.Dto.Outgoing;
using ApplicationLayer.CreditModule.Service.Shared;
using AutoMapper;
using CreditModule.DomainModels;
using CreditModule.DomainModels.Enums;
using DataAccess.CreditModule.Repository.Shared;

namespace ApplicationLayer.CreditModule.Service;

public class CreditsService(ICreditRepository creditRepository,IMapper mapper) : ICreditService
{
    public async Task<GetAllCreditsResponse> GetCreditsWithInvoices()
    {
        var credits = await creditRepository.GetCreditsWithInvoices();

        var groupCredits = credits.GroupBy(credit => credit.CreditId)
            .Select(group =>
            {
                var first = group.First();
                first.Invoices = group
                    .SelectMany(c => c.Invoices)
                    .ToList();

                return first;
            })
            .ToList();

        var response = new GetAllCreditsResponse
        {
            Credits = mapper.Map<List<CreditInvoiceDto>>(groupCredits)
        };

        return response;
    }

    public async Task<GetStatusDataResponse> GetStatusData(PaymentTypes paymentType)
    {
        var response = new GetStatusDataResponse();
        if (paymentType is not (PaymentTypes.AwaitingPayment or PaymentTypes.Paid))
        {
            response.AddError(HttpStatusCode.BadRequest, "Invalid payment type");
            return response;
        }

        var payments = (await creditRepository.GetStatusData()).ToList();

        var status = new Status
        {
            PaymentType = paymentType,
            PaymentTypeTotal = payments
                .Where(payment => payment.PaymentType == paymentType)
                .Sum(payment => payment.Sum)
        };

        status.PaymentTypePercentage = CalculatePercentage(payments, status.PaymentTypeTotal);

        response.Status = mapper.Map<StatusDTO>(status);

        return response;
    }

    private static decimal CalculatePercentage(IEnumerable<Payment> payments, decimal value)
    {
        var total = payments.Sum(payment => payment.Sum);

        return total == 0 ? 0 : value / total * 100;
    }
}