namespace ApplicationLayer.CreditModule.Dto.DTOs;

public record CreditInvoiceDto(
    int CreditId,
    int CreditNumber,
    string ClientName,
    DateOnly RequestDate,
    decimal RequestedSum,
    string Status,
    List<InvoiceDto> Invoices
);