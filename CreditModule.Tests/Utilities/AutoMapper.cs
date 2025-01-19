using ApplicationLayer.CreditModule.Service.MapperProfiles;
using AutoMapper;

namespace CreditModule.Tests.Utilities;

public static class AutoMapper
{
    public static IMapper GetMapper => GetMapperConfiguration.CreateMapper();

    private static readonly MapperConfiguration GetMapperConfiguration = new(configuration =>
    {
        configuration.AddProfile<CreditDTOProfile>();
        configuration.AddProfile<InvoiceDTOProfile>();
        configuration.AddProfile<StatusDTOProfile>();

    });

}