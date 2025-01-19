using AutoMapper;
using CreditModule.DomainModels;

namespace DataAccess.CreditModule.Repository.MapperProfiles;

public class CreditProfile : Profile
{
    public CreditProfile()
    {

        CreateMap<Entities.Credit, Credit>()
            .ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => src.PaymentTypeId))
            .ForMember(dest => dest.Invoices, opt => opt.MapFrom(src => 
                src.Invoice != null
                ? new List<Invoice> { new()
                {
                    InvoiceId = src.Invoice.InvoiceId,
                    InvoiceNumber = src.Invoice.InvoiceNumber,
                    InvoiceTotal = src.Invoice.InvoiceTotal,
                } }
                : new List<Invoice>()))
            .ReverseMap();
    }

}