using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;
using System.Text.Json;

namespace PaymentGateway.Api.Specs.Support
{

    public abstract class IntegrationTestBase
    {
        protected HttpClient? Client { get; set; }
        protected string? ApiUri { get; set; }
        protected JsonSerializerOptions? _serializerOptions = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        protected IntegrationTestBase()
        {
            var appFactory = new WebApplicationFactory<Program>();
            Client = appFactory.CreateClient();
            ApiUri = Client?.BaseAddress?.AbsoluteUri;
        }

        public StringContent JsonData<T>(T data)
        {
            string jsonString = JsonSerializer.Serialize(data, _serializerOptions);
            return new StringContent(jsonString, Encoding.UTF8, "application/json");
        }
        public T? ObjectData<T>(string json) => JsonSerializer.Deserialize<T>(json, _serializerOptions);
    }
}

