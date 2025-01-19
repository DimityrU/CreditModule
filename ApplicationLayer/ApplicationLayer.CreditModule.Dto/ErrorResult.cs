using System.Net;

namespace ApplicationLayer.CreditModule.Dto;

public class ErrorResult
{
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

    public bool HasError { get; set; }

    public string? ErrorMessage { get; set; }

    public void AddError(HttpStatusCode statusCode, string errorMessage)
    {
        HasError = true;
        StatusCode = statusCode;
        ErrorMessage = errorMessage;
    }

    public override bool Equals(object? obj)
    {
        if (obj is ErrorResult other)
        {
            return StatusCode == other.StatusCode &&
                   HasError == other.HasError &&
                   ErrorMessage == other.ErrorMessage;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(StatusCode, HasError, ErrorMessage);
    }
}
