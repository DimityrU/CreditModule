using System.Net;
using ApplicationLayer.CreditModule.Dto.Outgoing;
using ApplicationLayer.CreditModule.Service;
using ApplicationLayer.CreditModule.Service.Shared;
using CreditModule.DomainModels;
using CreditModule.Tests.Fixtures;
using Moq;
using Newtonsoft.Json;

namespace CreditModule.Tests.Credits.GetCreditsWithInvoice;

[Collection("MockCollection")]
public partial class GetCreditsWithInvoicesTest(MockFixture fixture)
{
    private protected readonly ICreditService CreditService =
        new CreditsService(fixture.CreditRepositoryMock.Object, fixture.Mapper);

    [Theory]
    [Trait("GetCreditsWithInvoices", "Successful")]
    [MemberData(nameof(TestData))]
    public async Task GetCreditsWithInvoices_Test(List<Credit> expectedRepoResponse, GetAllCreditsResponse expectedResponse)
    {
        fixture.CreditRepositoryMock.Setup(repository => repository.GetCreditsWithInvoices()).ReturnsAsync(expectedRepoResponse);

        var response = await CreditService.GetCreditsWithInvoices();

        Assert.NotNull(response);
        Assert.False(response.HasError); 
        Assert.Null(response.ErrorMessage);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var expectedJson = JsonConvert.SerializeObject(expectedResponse.Credits);
        var actualJson = JsonConvert.SerializeObject(response.Credits);

        Assert.Equal(expectedJson, actualJson);
    }
}