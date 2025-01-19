using ApplicationLayer.CreditModule.Dto.DTOs;
using AutoMapper;
using CreditModule.DomainModels;
using CreditModule.DomainModels.Enums;

namespace ApplicationLayer.CreditModule.Service.MapperProfiles;

public class StatusDTOProfile : Profile
{
    public StatusDTOProfile()
    {
        CreateMap<Status, StatusDTO>()
            .ForCtorParam("Status", opt => opt.MapFrom(src => Enum.GetName(typeof(PaymentTypes), src.PaymentType)))
            .ForCtorParam("Percentage", opt => opt.MapFrom(src => src.PaymentTypePercentage))
            .ForCtorParam("Total", opt => opt.MapFrom(src => src.PaymentTypeTotal));
    }

}