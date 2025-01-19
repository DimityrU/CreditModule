using ApplicationLayer.CreditModule.Dto.DTOs;
using ApplicationLayer.CreditModule.Dto.Outgoing;
using CreditModule.DomainModels;
using CreditModule.DomainModels.Enums;

namespace CreditModule.Tests.Credits.GetStatusData;

public partial class GetStatusDataTest
{
    public static object[] TestGetStatusData_ValidPaymentTypeNoPayments_TestCaseParam()
    {
        var paymentType = PaymentTypes.Paid;
        var expectedRepoResponse = new List<Payment>();
        var expectedResponse = new GetStatusDataResponse
        {
            Status = new StatusDTO("Paid", 0, 0)
        };

        return [paymentType, expectedRepoResponse, expectedResponse];
    }

    public static object[] TestGetStatusData_ValidPaymentTypeWithPayments_TestCaseParam()
    {
        var paymentType = PaymentTypes.AwaitingPayment;
        var expectedRepoResponse = new List<Payment>
    {
        new() { Sum = 100, PaymentType = PaymentTypes.AwaitingPayment },
        new() { Sum = 200, PaymentType = PaymentTypes.AwaitingPayment }
    };

        var expectedResponse = new GetStatusDataResponse
        {
            Status = new StatusDTO("AwaitingPayment", 300, 100)
        };

        return [paymentType, expectedRepoResponse, expectedResponse];
    }

    public static object[] TestGetStatusData_ValidPaymentTypeWithMixedPayments_TestCaseParam()
    {
        var paymentType = PaymentTypes.Paid;
        var expectedRepoResponse = new List<Payment>
    {
        new() { Sum = 100, PaymentType = PaymentTypes.AwaitingPayment },
        new() { Sum = 200, PaymentType = PaymentTypes.Paid },
        new() { Sum = 300, PaymentType = PaymentTypes.AwaitingPayment },
        new() { Sum = 400, PaymentType = PaymentTypes.Paid }
    };

        var expectedResponse = new GetStatusDataResponse
        {
            Status = new StatusDTO("Paid", 600, 60)
        };

        return [paymentType, expectedRepoResponse, expectedResponse];
    }

    public static object[] TestGetStatusData_PaidButOnlyAwaitingPayments_TestCaseParam()
    {
        var paymentType = PaymentTypes.Paid;

        var expectedRepoResponse = new List<Payment>
        {
            new() { Sum = 150, PaymentType = PaymentTypes.AwaitingPayment },
            new() { Sum = 250, PaymentType = PaymentTypes.AwaitingPayment }
        };

        var expectedResponse = new GetStatusDataResponse
        {
            Status = new StatusDTO("Paid", 0, 0)
        };

        return [paymentType, expectedRepoResponse, expectedResponse];
    }


    public static IEnumerable<object[]> TestData()
    {
        yield return TestGetStatusData_ValidPaymentTypeNoPayments_TestCaseParam();
        yield return TestGetStatusData_ValidPaymentTypeWithPayments_TestCaseParam();
        yield return TestGetStatusData_ValidPaymentTypeWithMixedPayments_TestCaseParam();
        yield return TestGetStatusData_PaidButOnlyAwaitingPayments_TestCaseParam();
    }

}