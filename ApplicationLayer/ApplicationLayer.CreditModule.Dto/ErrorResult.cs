using System.Net;

namespace ApplicationLayer.CreditModule.Dto;

public class ErrorResult
{
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

    public bool HasError { get; set; }

    public string? ErrorMessage { get; set; }

    public void AddError(HttpStatusCode statusCode ,string errorMessage)
    {
        HasError = true;
        StatusCode = statusCode;
        ErrorMessage = errorMessage;
    }
}