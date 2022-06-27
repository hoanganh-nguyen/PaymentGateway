using AcquiringBank.Domain.Validator;
using PaymentGateway.Application.Processor;
using PaymentGateway.Application.Validator;
using PaymentGateway.Domain.Interfaces;
using PaymentGateway.Domain.Repository;
using PaymentGateway.Domain.Validator;
using PaymentGateway.Infrastructure;

namespace PaymentGateway.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<ICardNumberValidator, DefaultCardNumberValidator>();
            builder.Services.AddScoped<ICvvValidator, RegexCvvValidator>();
            builder.Services.AddScoped<ICreditCardValidator, CreditCardValidator>();
            builder.Services.AddScoped<IPaymentRequestValidator, PaymentRequestValidator>();
            builder.Services.AddScoped<ISupportedCurrencyValidator, DefaultSupportedCurrencyValidator>();
            
            builder.Services.AddScoped<IPaymentGateway, PaymentProcessor>();
            builder.Services.AddTransient<IPaymentInfoRepository, FilePaymentInfoRepository>();
            builder.Services.AddScoped<IAcquiringBankHandler, LocalAcquiringBank.LocalAcquiringBank>();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Payment Gateway API", Version = "v1" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}