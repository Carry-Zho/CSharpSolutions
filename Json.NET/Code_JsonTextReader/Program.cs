using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Code_JsonTextReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonText = @"{ 
                                    ""name"": ""Alice"",
                                    ""age"": 21,
                                    ""isStudent"": true        
                                 }";
            using (JsonTextReader reader = new JsonTextReader(new StringReader(jsonText)))
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.PropertyName)
                    {
                        string key = (string)reader.Value;  // Read the property names
                        reader.Read(); // Move to the property's svalue token

                        Console.WriteLine($"Key: {key}, Value: {reader.Value}");

                    }
                }
            }
        }
    }
}
