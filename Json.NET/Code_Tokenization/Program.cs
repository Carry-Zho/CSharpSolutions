using Newtonsoft.Json;

namespace Code_Tokenization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonText = @"{""name"":""John"", ""age"":30}";
            using(JsonTextReader reader = new JsonTextReader(new StringReader(jsonText)))
            {
                while (reader.Read())
                {
                    //Console.WriteLine(reader.GetType());
                    Console.WriteLine("TokenType:{0,-20},Value:{1,-20},ValueType:{2,-20}", reader.TokenType, reader.Value, reader.ValueType);
                }
            }
        }
    }
}
