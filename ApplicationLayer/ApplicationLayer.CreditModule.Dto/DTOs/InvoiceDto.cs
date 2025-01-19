namespace ApplicationLayer.CreditModule.Dto.DTOs;

public record InvoiceDto(
    string InvoiceId,
    int InvoiceNumber,
    int InvoiceTotal
);