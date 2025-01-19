using AutoMapper;
using CreditModule.DomainModels;

namespace DataAccess.CreditModule.Repository.MapperProfiles;

public class PaymentProfile : Profile
{
    public PaymentProfile()
    {
        CreateMap<Entities.Payment, Payment>()
            .ForMember(dest => dest.Sum, opt => opt.MapFrom(src => src.RequestedSum))
            .ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => src.PaymentTypeId));

    }

}