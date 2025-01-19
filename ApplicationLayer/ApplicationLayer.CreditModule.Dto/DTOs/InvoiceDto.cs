namespace ApplicationLayer.CreditModule.Dto.DTOs;

public record InvoiceDto(
    int InvoiceId,
    int InvoiceNumber,
    decimal InvoiceTotal
);