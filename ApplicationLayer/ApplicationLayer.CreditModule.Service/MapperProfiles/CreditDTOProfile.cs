using ApplicationLayer.CreditModule.Dto.DTOs;
using AutoMapper;
using CreditModule.DomainModels;
using CreditModule.DomainModels.Enums;

namespace ApplicationLayer.CreditModule.Service.MapperProfiles;

public class CreditDTOProfile : Profile
{
    public CreditDTOProfile()
    {
        CreateMap<Credit, CreditInvoiceDto>()
            .ForCtorParam("RequestDate", opt => opt.MapFrom(src => DateOnly.Parse(src.RequestDate)))
            .ForCtorParam("Status", opt => opt.MapFrom(src => Enum.GetName(typeof(PaymentTypes), src.PaymentType)));


        CreateMap<Invoice, InvoiceDto>().ReverseMap();

        CreateMap<Status, StatusDTO>()
            .ForCtorParam("Status", opt => opt.MapFrom(src => Enum.GetName(typeof(PaymentTypes), src.PaymentType)))
            .ForCtorParam("Percentage", opt => opt.MapFrom(src => src.PaymentTypePercentage))
            .ForCtorParam("Total", opt => opt.MapFrom(src => src.PaymentTypeTotal));
    }

}