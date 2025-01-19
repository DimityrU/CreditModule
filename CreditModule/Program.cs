using ApplicationLayer.CreditModule.Service;
using ApplicationLayer.CreditModule.Service.MapperProfiles;
using ApplicationLayer.CreditModule.Service.Shared;
using AutoMapper;
using CreditModule.Helpers;
using DataAccess.CreditModule.Repository;
using DataAccess.CreditModule.Repository.Entities;
using DataAccess.CreditModule.Repository.MapperProfiles;
using DataAccess.CreditModule.Repository.Shared;
using Microsoft.Extensions.Options;
using System.Reflection;
using NSwag;
using OpenApiInfo = Microsoft.OpenApi.Models.OpenApiInfo;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("CreditContext");

// Add services to the container.
builder.Services.AddScoped(_ => new CreditContext(connectionString));

builder.Services.AddScoped<ICreditRepository, CreditRepository>();
builder.Services.AddScoped<ICreditService, CreditsService>();

var config = new MapperConfiguration(c => {
    c.AddProfile<InvoiceProfile>();
    c.AddProfile<CreditProfile>();
    c.AddProfile<CreditDTOProfile>();
    c.AddProfile<PaymentProfile>();
});

builder.Services.AddSingleton<IMapper>(_ => config.CreateMapper());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SchemaFilter<ExcludePaymentTypes>();

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CreditModuleAPI");

    });
}

app.UseHttpsRedirection();

app.UseCors("AllowAnyOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
