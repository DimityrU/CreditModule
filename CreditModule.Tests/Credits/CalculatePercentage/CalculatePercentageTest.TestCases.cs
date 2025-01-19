using CreditModule.DomainModels;
using CreditModule.DomainModels.Enums;

namespace CreditModule.Tests.Credits.CalculatePercentage;

public partial class CalculatePercentageTest
{
    public static object[] TestCalculatePercentage_BasicTestCase()
    {
        var payments = new List<Payment>
        {
            new() { Sum = 100.50m, PaymentType = PaymentTypes.Paid },
            new() { Sum = 200.75m, PaymentType = PaymentTypes.Paid }
        };

        var totalPaymentsByType = 100.50m;
        var expectedPercentage = 33.36m;

        object parameter = new object[] { payments, totalPaymentsByType };

        return [parameter, expectedPercentage];
    }


    public static object[] TestCalculatePercentage_ZeroTotal()
    {
        var payments = new List<Payment>
        {
            new() { Sum = 0m, PaymentType = PaymentTypes.Paid },
            new() { Sum = 0m, PaymentType = PaymentTypes.Paid }
        };

        var totalPaymentsByType = 100.50m;
        var expectedPercentage = 0m;

        object parameter = new object[] { payments, totalPaymentsByType };

        return [parameter, expectedPercentage];
    }


    public static object[] TestCalculatePercentage_SinglePaymentFulltotalPaymentsByType()
    {
        var payments = new List<Payment>
        {
            new() { Sum = 300.25m, PaymentType = PaymentTypes.Paid }
        };

        var totalPaymentsByType = 300.25m;
        var expectedPercentage = 100m;

        object parameter = new object[] { payments, totalPaymentsByType };

        return [parameter, expectedPercentage];
    }


    public static object[] TestCalculatePercentage_ComplexPercentage()
    {
        var payments = new List<Payment>
        {
            new() { Sum = 500.50m, PaymentType = PaymentTypes.Paid },
            new() { Sum = 300.30m, PaymentType = PaymentTypes.AwaitingPayment },
            new() { Sum = 200.20m, PaymentType = PaymentTypes.Paid }
        };

        var totalPaymentsByType = 500.50m;
        var expectedPercentage = 50.00m;

        object parameter = new object[] { payments, totalPaymentsByType };

        return [parameter, expectedPercentage];
    }


    public static object[] TestCalculatePercentage_LargetotalPaymentsByTypes()
    {
        var payments = new List<Payment>
        {
            new() { Sum = 1000000.99m, PaymentType = PaymentTypes.AwaitingPayment },
            new() { Sum = 2000000.75m, PaymentType = PaymentTypes.Paid },
            new() { Sum = 3000000.50m, PaymentType = PaymentTypes.AwaitingPayment }
        };

        var totalPaymentsByType = 1500000.25m;
        var expectedPercentage = 25m;

        object parameter = new object[] { payments, totalPaymentsByType };

        return [parameter, expectedPercentage];
    }


    public static object[] TestCalculatePercentage_NegativeValueByType()
    {
        var payments = new List<Payment>
        {
            new() { Sum = 100.75m, PaymentType = PaymentTypes.AwaitingPayment },
            new() { Sum = 400.50m, PaymentType = PaymentTypes.AwaitingPayment }
        };

        var totalPaymentsByType = -100.25m;
        var expectedPercentage = -20.00m;

        object parameter = new object[] { payments, totalPaymentsByType };

        return [parameter, expectedPercentage];
    }


    public static IEnumerable<object[]> TestData()
    {
        yield return TestCalculatePercentage_BasicTestCase();
        yield return TestCalculatePercentage_ZeroTotal();
        yield return TestCalculatePercentage_SinglePaymentFulltotalPaymentsByType();
        yield return TestCalculatePercentage_ComplexPercentage();
        yield return TestCalculatePercentage_LargetotalPaymentsByTypes();
        yield return TestCalculatePercentage_NegativeValueByType();
    }

}