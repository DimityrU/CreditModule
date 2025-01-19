using CreditModule.DomainModels.Enums;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CreditModule.Helpers;

public class ExcludePaymentTypes : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(PaymentTypes))
        {
            schema.Enum = schema.Enum
                .Where(e => e is OpenApiInteger integer &&
                            integer.Value != (int)PaymentTypes.Created)
                .ToList();
        }
    }
}