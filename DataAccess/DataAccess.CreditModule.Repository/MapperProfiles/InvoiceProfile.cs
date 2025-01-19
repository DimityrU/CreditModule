using AutoMapper;
using CreditModule.DomainModels;

namespace DataAccess.CreditModule.Repository.MapperProfiles;

public class InvoiceProfile : Profile
{
    public InvoiceProfile()
    {
        CreateMap<Entities.Invoice, Invoice>().ReverseMap();
    }

}