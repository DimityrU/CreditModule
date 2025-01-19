namespace ApplicationLayer.CreditModule.Dto.DTOs;

public record StatusDTO(
    string Status,
    decimal Total,
    decimal Percentage
);