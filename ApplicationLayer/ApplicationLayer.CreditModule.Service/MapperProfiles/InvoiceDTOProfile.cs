using ApplicationLayer.CreditModule.Dto.DTOs;
using AutoMapper;
using CreditModule.DomainModels;

namespace ApplicationLayer.CreditModule.Service.MapperProfiles;

public class InvoiceDTOProfile : Profile
{
    public InvoiceDTOProfile()
    {
        CreateMap<Invoice, InvoiceDto>().ReverseMap();
    }

}