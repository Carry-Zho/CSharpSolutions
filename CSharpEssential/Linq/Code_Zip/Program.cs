using System.Data;
namespace Code_Zip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable DataTable_Header = new DataTable();
            DataTable_Header.Columns.Add("Header", typeof(string));
            DataTable_Header.Rows.Add("订单号");
            DataTable_Header.Rows.Add("订单类型");
            DataTable_Header.Rows.Add("底盘号");

            DataTable DataTable_RowConent = new DataTable();
            DataTable_RowConent.Columns.Add("Content", typeof(string));
            DataTable_RowConent.Rows.Add("2504220950hq2a");
            DataTable_RowConent.Rows.Add("客户订单");
            DataTable_RowConent.Rows.Add("LE42541471L037856");

            Dictionary<string,string> dataDic = new Dictionary<string,string>();
            dataDic = DataTable_Header.AsEnumerable()
                .Zip(DataTable_RowConent.AsEnumerable(), (TFirst, TSecond) => (TFirst, TSecond))
                .ToDictionary(
                   item => item.TFirst.Field<string>("Header")!,
                   item => item.TSecond?.Field<string>("Content")!
                );   //示例中Zip内的项不可能为空，使用非空断言告知编译器

            foreach (var item in dataDic)
                Console.WriteLine($"{item.Key} : {item.Value}");

        }
    }
}


