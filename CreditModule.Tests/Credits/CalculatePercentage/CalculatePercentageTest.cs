using System.Reflection;
using ApplicationLayer.CreditModule.Service;

namespace CreditModule.Tests.Credits.CalculatePercentage;

[Collection("MockCollection")]
public partial class CalculatePercentageTest
{
    [Theory]
    [Trait("CalculatePercentage", "Successful")]
    [MemberData(nameof(TestData))]
    public void CalculatePercentage_Test(object[] parameter, decimal expectedResult)
    {
        var CalculatePercentageMethod = typeof(CreditsService).GetMethod("CalculatePercentage",
            BindingFlags.NonPublic | BindingFlags.Static);

        var result = (decimal)CalculatePercentageMethod.Invoke(null, parameter);

        Assert.Equal(expectedResult, Math.Round(result, 2));
    }
}