using System.Text.Json;
using System.Text.Json.Serialization;
using PaymentGateway.Models;

namespace PaymentGateway.Infrastructure.Mask
{
    public class MaskedCreditCardJsonConverter : JsonConverter<CreditCard>
    {
        public override CreditCard Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            CreditCard card = new CreditCard();

            reader.Read();
            string? propertyName;
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            } 
            
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return card;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    propertyName = reader.GetString();
                    reader.Read();
                    switch (propertyName)
                    {
                        case "cardNumber":
                            string cardNumber = reader.GetString();
                            card.CardNumber = cardNumber;
                            break;
                        case "cvv":
                            string cvv = reader.GetString();
                            card.Cvv = cvv;
                            break;
                        case "expiryMonth":
                            string expiryMonth = reader.GetString();
                            card.ExpiryMonth = Int32.Parse(expiryMonth);
                            break;
                        case "expiryYear":
                            string expiryYear = reader.GetString();
                            card.ExpiryYear = Int32.Parse(expiryYear);
                            break;
                    }
                }
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, CreditCard value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("cardNumber", value.CardNumber.Mask(0, 12 , '*'));
            writer.WriteString("cvv", value.Cvv);
            writer.WriteNumber("expiryMonth", value.ExpiryMonth);
            writer.WriteNumber("expiryYear", value.ExpiryYear);
            writer.WriteEndObject();
        }
    }

    public static class StringExtensions
    {
        public static string Mask(this string source, int start, int maskLength)
        {
            return source.Mask(start, maskLength, 'X');
        }

        public static string Mask(this string source, int start, int maskLength, char maskCharacter)
        {
            if (start > source.Length - 1)
            {
                throw new ArgumentException("Start position is greater than string length");
            }

            if (maskLength > source.Length)
            {
                throw new ArgumentException("Mask length is greater than string length");
            }

            if (start + maskLength > source.Length)
            {
                throw new ArgumentException("Start position and mask length imply more characters than are present");
            }

            string mask = new string(maskCharacter, maskLength);
            string unMaskStart = source.Substring(0, start);
            string unMaskEnd = source.Substring(start + maskLength, source.Length - maskLength);

            return unMaskStart + mask + unMaskEnd;
        }
    }
}
