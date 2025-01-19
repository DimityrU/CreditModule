using ApplicationLayer.CreditModule.Dto.DTOs;
using ApplicationLayer.CreditModule.Dto.Outgoing;
using CreditModule.DomainModels;
using CreditModule.DomainModels.Enums;
using CreditModule.Tests.Utilities.InMemoryTestData;

namespace CreditModule.Tests.Credits.GetCreditsWithInvoice;

public partial class GetCreditsWithInvoicesTest
{
    public static object[] TestGetCreditsWithInvoices_EmptyCredits_TestCaseParam()
    {
        var expectedRepoResponse = new List<Credit>();

        var expectedResponse = new GetAllCreditsResponse
        {
            Credits = []
        };

        return [expectedRepoResponse, expectedResponse];
    }

    public static object[] TestGetCreditsWithInvoices_SingleCreditSingleInvoice_TestCaseParam()
    {
        var credit = new Credit
        {
            CreditId = CreditTestData.CreditId,
            CreditNumber = CreditTestData.CreditNumber,
            ClientName = CreditTestData.ClientName,
            RequestDate = CreditTestData.RequestDate,
            RequestedSum = CreditTestData.RequestedSum,
            PaymentType = PaymentTypes.Paid,
            Invoices = [new Invoice { InvoiceId = InvoiceTestData.InvoiceId, InvoiceNumber = InvoiceTestData.InvoiceNumber, InvoiceTotal = InvoiceTestData.InvoiceTotal }]
        };

        var expectedRepoResponse = new List<Credit> { credit };

        var expectedResponse = new GetAllCreditsResponse
        {
            Credits =
            [
                new CreditInvoiceDto(
                    1,
                    123,
                    "Ivan Ivanov",
                    new DateOnly(2025, 01, 20),
                    100.23m,
                    "Paid",
                    [new InvoiceDto(1, 101, 500.23m)])
            ]
        };

        return [expectedRepoResponse, expectedResponse];
    }

    public static object[] TestGetCreditsWithInvoices_SingleCreditMultipleInvoices_TestCaseParam()
    {
        var credits = new List<Credit>
    {
        new Credit
        {
            CreditId = CreditTestData.CreditId,
            CreditNumber = CreditTestData.CreditNumber,
            ClientName = CreditTestData.ClientName,
            RequestDate = CreditTestData.RequestDate,
            RequestedSum = CreditTestData.RequestedSum,
            PaymentType = PaymentTypes.Paid,
            Invoices = [new Invoice { InvoiceId = InvoiceTestData.InvoiceId, InvoiceNumber = InvoiceTestData.InvoiceNumber, InvoiceTotal = InvoiceTestData.InvoiceTotal }]
        },
        new Credit
        {
            CreditId = CreditTestData.CreditId,
            CreditNumber = CreditTestData.CreditNumber,
            ClientName = CreditTestData.ClientName,
            RequestDate = CreditTestData.RequestDate,
            RequestedSum = CreditTestData.RequestedSum,
            PaymentType = PaymentTypes.Paid,
            Invoices = [new Invoice { InvoiceId = InvoiceTestData.SecondInvoiceId, InvoiceNumber = InvoiceTestData.SecondInvoiceNumber, InvoiceTotal = InvoiceTestData.SecondInvoiceTotal }]
        }
    };

        var expectedResponse = new GetAllCreditsResponse
        {
            Credits =
            [
                new CreditInvoiceDto(
                    1,
                    123,
                    "Ivan Ivanov",
                    new DateOnly(2025, 01, 20),
                    100.23m,
                    "Paid",
                    [
                        new InvoiceDto(1, 101, 500.23m),
                        new InvoiceDto(2, 102, 600.23m)
                    ])
            ]
        };

        return [credits, expectedResponse];
    }

    public static object[] TestGetCreditsWithInvoices_MultipleCreditsMixedInvoices_TestCaseParam()
    {
        var credits = new List<Credit>
    {
        new Credit
        {
            CreditId = CreditTestData.CreditId,
            CreditNumber = CreditTestData.CreditNumber,
            ClientName = CreditTestData.ClientName,
            RequestDate = CreditTestData.RequestDate,
            RequestedSum = CreditTestData.RequestedSum,
            PaymentType = PaymentTypes.Paid,
            Invoices = [new Invoice { InvoiceId = InvoiceTestData.InvoiceId, InvoiceNumber = InvoiceTestData.InvoiceNumber, InvoiceTotal = InvoiceTestData.InvoiceTotal }]
        },
        new Credit
        {
            CreditId = CreditTestData.SecondCreditId,
            CreditNumber = CreditTestData.SecondCreditNumber,
            ClientName = CreditTestData.SecondClientName,
            RequestDate = CreditTestData.SecondRequestDate,
            RequestedSum = CreditTestData.SecondRequestedSum,
            PaymentType = PaymentTypes.AwaitingPayment,
            Invoices = [new Invoice { InvoiceId = InvoiceTestData.SecondInvoiceId, InvoiceNumber = InvoiceTestData.SecondInvoiceNumber, InvoiceTotal = InvoiceTestData.SecondInvoiceTotal }]
        }
    };

        var expectedResponse = new GetAllCreditsResponse
        {
            Credits =
            [
                new CreditInvoiceDto(
                    1,
                    123,
                    "Ivan Ivanov",
                    new DateOnly(2025, 01, 20),
                    100.23m,
                    "Paid",
                    [
                        new InvoiceDto(1, 101, 500.23m),
                    ]),

                new CreditInvoiceDto(
                    2,
                    456,
                    "Pesho Peshev",
                    new DateOnly(2025, 01, 21),
                    200.23m,
                    "AwaitingPayment",
                    [
                        new InvoiceDto(2, 102, 600.23m)
                    ])
            ]
        };

        return [credits, expectedResponse];
    }

    public static object[] TestGetCreditsWithInvoices_MultipleCreditsWithoutInvoices_TestCaseParam()
    {
        var credits = new List<Credit>
    {
        new Credit
        {
            CreditId = CreditTestData.CreditId,
            CreditNumber = CreditTestData.CreditNumber,
            ClientName = CreditTestData.ClientName,
            RequestDate = CreditTestData.RequestDate,
            RequestedSum = CreditTestData.RequestedSum,
            PaymentType = PaymentTypes.Created,
            Invoices = []
        },
        new Credit
        {
            CreditId = CreditTestData.SecondCreditId,
            CreditNumber = CreditTestData.SecondCreditNumber,
            ClientName = CreditTestData.SecondClientName,
            RequestDate = CreditTestData.SecondRequestDate,
            RequestedSum = CreditTestData.SecondRequestedSum,
            PaymentType = PaymentTypes.AwaitingPayment,
            Invoices = [new Invoice { InvoiceId = InvoiceTestData.InvoiceId, InvoiceNumber = InvoiceTestData.InvoiceNumber, InvoiceTotal = InvoiceTestData.InvoiceTotal }]
        },
        new Credit
        {
            CreditId = CreditTestData.SecondCreditId,
            CreditNumber = CreditTestData.SecondCreditNumber,
            ClientName = CreditTestData.SecondClientName,
            RequestDate = CreditTestData.SecondRequestDate,
            RequestedSum = CreditTestData.SecondRequestedSum,
            PaymentType = PaymentTypes.AwaitingPayment,
            Invoices = [new Invoice { InvoiceId = InvoiceTestData.SecondInvoiceId, InvoiceNumber = InvoiceTestData.SecondInvoiceNumber, InvoiceTotal = InvoiceTestData.SecondInvoiceTotal }]
        }
    };

        var expectedResponse = new GetAllCreditsResponse
        {
            Credits =
            [
                new CreditInvoiceDto(
                    1,
                    123,
                    "Ivan Ivanov",
                    new DateOnly(2025, 01, 20),
                    100.23m,
                    "Created",
                    []),

                new CreditInvoiceDto(
                    2,
                    456,
                    "Pesho Peshev",
                    new DateOnly(2025, 01, 21),
                    200.23m,
                    "AwaitingPayment",
                    [
                        new InvoiceDto(1, 101, 500.23m),
                        new InvoiceDto(2, 102, 600.23m)
                    ])
            ]
        };

        return [credits, expectedResponse];
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return TestGetCreditsWithInvoices_EmptyCredits_TestCaseParam();
        yield return TestGetCreditsWithInvoices_SingleCreditSingleInvoice_TestCaseParam();
        yield return TestGetCreditsWithInvoices_SingleCreditMultipleInvoices_TestCaseParam();
        yield return TestGetCreditsWithInvoices_MultipleCreditsMixedInvoices_TestCaseParam();
        yield return TestGetCreditsWithInvoices_MultipleCreditsWithoutInvoices_TestCaseParam();
    }

}