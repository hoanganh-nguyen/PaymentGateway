using System.Text;
using System.Text.Json;
using PaymentGateway.Domain.Repository;
using PaymentGateway.Infrastructure.Mask;
using PaymentGateway.Models;

namespace PaymentGateway.Infrastructure
{
    public class FilePaymentInfoRepository: IPaymentInfoRepository
    {
        protected JsonSerializerOptions? WriterSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase, 
            Converters =
            {
                new MaskedCreditCardJsonConverter()
            }
        };

        protected JsonSerializerOptions? ReaderSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
           
        };
        public async Task<PaymentInfo?> GetAsync(Guid id)
        {
            try
            {
                var json = await ReadTextAsync(id.ToString());
                return JsonSerializer.Deserialize<PaymentInfo>(json, ReaderSerializerOptions);
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        public async Task<bool> AddAsync(PaymentInfo info)
        {
            try
            {
                await WriteTextAsync(info.Id.ToString(), JsonSerializer.Serialize(info, WriterSerializerOptions));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;

        }


        async Task WriteTextAsync(string filePath, string text)
        {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            await using var sourceStream =
                new FileStream(
                    filePath,
                    FileMode.Create, FileAccess.Write, FileShare.None,
                    bufferSize: 4096, useAsync: true);

            await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
        }

        async Task<string> ReadTextAsync(string filePath)
        {
            using var sourceStream =
                new FileStream(
                    filePath,
                    FileMode.Open, FileAccess.Read, FileShare.Read,
                    bufferSize: 4096, useAsync: true);

            var sb = new StringBuilder();

            byte[] buffer = new byte[0x1000];
            int numRead;
            while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                sb.Append(text);
            }

            return sb.ToString();
        }
    }

  
}