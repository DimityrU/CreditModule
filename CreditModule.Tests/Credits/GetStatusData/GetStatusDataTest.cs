using System.Net;
using ApplicationLayer.CreditModule.Dto.Outgoing;
using ApplicationLayer.CreditModule.Service;
using ApplicationLayer.CreditModule.Service.Shared;
using CreditModule.DomainModels;
using CreditModule.DomainModels.Enums;
using CreditModule.Tests.Fixtures;
using Moq;

namespace CreditModule.Tests.Credits.GetStatusData;

[Collection("MockCollection")]
public partial class GetStatusDataTest(MockFixture fixture)
{
    private protected readonly ICreditService CreditService =
        new CreditsService(fixture.CreditRepositoryMock.Object, fixture.Mapper);

    [Theory]
    [Trait("GetStatusData", "Successful")]
    [MemberData(nameof(TestData))]
    public async Task GetStatusData_Test(PaymentTypes paymentType,List<Payment> expectedRepoResponse, GetStatusDataResponse expectedResponse)
    {
        fixture.CreditRepositoryMock.Setup(repository => repository.GetStatusData()).ReturnsAsync(expectedRepoResponse);

        var response = await CreditService.GetStatusData(paymentType);

        Assert.NotNull(response);
        Assert.Equal(expectedResponse, response);
        Assert.Equal(expectedResponse.Status, response.Status);
    }

    [Fact]
    [Trait("GetStatusData", "Error")]
    public async Task GetStatusData_Error_Test()
    {
        var paymentType = PaymentTypes.Created;

        var expectedResponse = new GetStatusDataResponse()
        {
            HasError = true,
            ErrorMessage = "Invalid payment type",
            StatusCode = HttpStatusCode.BadRequest
        };

        var response = await CreditService.GetStatusData(paymentType);

        Assert.NotNull(response);
        Assert.Equal(expectedResponse, response);
    }
}