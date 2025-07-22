using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Code_JObject
{
    internal class Program
    {
        #region cas1
        //static void Main(string[] args)
        //{
        //    JObject joa = new JObject();
        //    joa.Add("Timi", "Gaming now");

        //    var job = new JObject(joa);

        //    JObject joc = new()
        //    {
        //        { "天成", "Gaming now" } // Adding a property with a key-value pair
        //    };


        //    JObject jod = new()
        //    {
        //        ["雷火"] = "Gaming now" // Adding a property using indexer syntax
        //    };

        //}
        #endregion
        //#region case2
        //static void Main(string[] args)
        //{
        //    JObject job = new JObject
        //    {
        //        ["天成"] = "Gaming now",
        //        ["雷火"] = "Gaming tomorrow"
        //    };
        //    var result1 = job.GetValue("天成");
        //    Console.WriteLine(result1!.Type);
        //    Console.WriteLine(result1.GetType());

        //    if(!job.TryGetValue("天雷", out result1))
        //        Console.WriteLine("天雷属性不存在");

        //    var result2 = job.GetValue("天雷"); // Attempting to get a value that does not exist
        //    Console.WriteLine(result2!.Type);   //访问null值时会抛出异常
        //    Console.WriteLine(result2.GetType());//访问null值时会抛出异常


        //}

        //#endregion

        #region case3

        static void Main(string[] args)
        {
            JObject job = new JObject
            {
                ["天成"] = "Gaming now",
                ["雷火"] = "Gaming tomorrow"
            };

            var result = job.Property("天成");

            Console.WriteLine(result!.Type);
            Console.WriteLine(result!.GetType());
            Console.WriteLine($"属性名:{result.Name},属性值:{result.Value}");

            result = job.Property("天雷"); // Attempting to get a property that does not exist
            if (result == null)
            {
                Console.WriteLine("天雷属性不存在");
            }

            foreach (var item in job.Properties())
            {
                Console.WriteLine($"属性名:{item.Name},属性值:{item.Value}");
            }

            foreach (var item in job.PropertyValues())
            {
                Console.WriteLine(item);
            }

        }
        #endregion
    }
}
