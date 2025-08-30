using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary.Helpers
{
    // Shared JSON serialization settings used throughout the application
    internal static class Converter
    {
        // Settings for JSON parsing with metadata ignored and ISO date handling
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            }
        };
    }

    // Custom converter for parsing long values from JSON strings
    internal class ParseStringConverter : JsonConverter
    {
        // Determines if the converter can handle long or nullable long types
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        // Reads a JSON value and converts it to a long
        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            try
            {
                if (reader.TokenType == JsonToken.Null)
                    return null;

                var value = serializer.Deserialize<string>(reader);

                if (long.TryParse(value, out long result))
                    return result;

                throw new JsonSerializationException($"Invalid long value: '{value}'");
            }
            catch (Exception ex)
            {
                throw new JsonSerializationException("Failed to parse long value from JSON.", ex);
            }
        }

        // Writes a long value as a string to JSON
        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            try
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }

                var value = (long)untypedValue;
                serializer.Serialize(writer, value.ToString());
            }
            catch (Exception ex)
            {
                throw new JsonSerializationException("Failed to write long value to JSON.", ex);
            }
        }

        // Singleton instance for reuse across the application
        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
