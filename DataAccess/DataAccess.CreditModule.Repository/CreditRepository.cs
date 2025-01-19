using AutoMapper;
using CreditModule.DomainModels;
using CreditModule.DomainModels.Enums;
using Dapper;
using DataAccess.CreditModule.Repository.Entities;
using DataAccess.CreditModule.Repository.Shared;
using Credit = CreditModule.DomainModels.Credit;
using Invoice = DataAccess.CreditModule.Repository.Entities.Invoice;
using Payment = CreditModule.DomainModels.Payment;

namespace DataAccess.CreditModule.Repository;

public class CreditRepository(CreditContext context, IMapper mapper) : ICreditRepository
{
    public async Task<IEnumerable<Credit>> GetCreditsWithInvoices()
    {
        var query = string.Concat(
            context.BuildSelect<Credit>(),
            context.BuildLeftJoin<Credit, Invoice>("CreditId", "CreditId"),
            context.BuildLeftJoin<Credit, PaymentType>("PaymentTypeId", "PaymentTypeId"));


        var result = await context.Database
            .QueryAsync<Entities.Credit, Invoice, PaymentType, Entities.Credit>(
                query,
                (credit, invoice, paymentType) =>
                {
                    credit.Invoice = invoice;
                    credit.PaymentTypeId = paymentType.PaymentTypeId;

                    return credit;
                },
                splitOn: "InvoiceId,PaymentTypeId"
            );


        return mapper.Map<IEnumerable<Credit>>(result);

    }

    public async Task<IEnumerable<Payment>> GetStatusData()
    {
        var query = string.Concat(
            context.BuildSelect<Credit>(["RequestedSum", "PaymentTypeId"]),
            context.BuildWhereNotEqual<Credit>("PaymentTypeId", ((int)PaymentTypes.Created).ToString()));

        var result = await context.Database.QueryAsync<Entities.Payment>(query);

        return mapper.Map<IEnumerable<Payment>>(result);
    }
}