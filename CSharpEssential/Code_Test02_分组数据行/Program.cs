using System.Data;
namespace Code_Test02_分组数据行
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable rawData = new DataTable();
            rawData.Columns.Add("Item", typeof(string));
            rawData.Columns.Add("Category", typeof(string));

            rawData.Rows.Add("aw123as", "AW");
            rawData.Rows.Add("aw125as", "RW");
            rawData.Rows.Add("aw126as", "RW");
            rawData.Rows.Add("aw127as", "WWE");
            rawData.Rows.Add("aw124as", "AS");


            //var groups = rawData.AsEnumerable().GroupBy(row => row.Field<string>("Category"))
            //    .Select(group => new
            //    {
            //        Category = group.Key,
            //        Items = group.Select(item => item.Field<string>("Item")).ToList()
            //    });

            var groups = rawData.AsEnumerable().GroupBy(row => row.Field<string>("Category"),item => item.Field<string>("Item"));
            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Key}");
                foreach (var item in group)
                    Console.WriteLine($"{item}");
            }

        }
    }
}
