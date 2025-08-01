using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Code_Deserialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonContent = "{\"Name\":\"John\",\"Birthday\":\"2021-11-11\"}";

            var settings = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd",
                Converters = new List<JsonConverter> { new CustomDateTimeConverter() }
            };

            JObject job = JsonConvert.DeserializeObject<JObject>(jsonContent, settings);
            Console.WriteLine(job);
            Console.WriteLine(job["Birthday"].Type);
        }
    }
    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
