using MiniExcelLibs;
using System.Data;

namespace LINQ_Where
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string excelPath = @"D:\Test\RawData.xlsx";
            var table = MiniExcel.QueryAsDataTable(excelPath, sheetName: "总表", useHeaderRow: true);
            var result = table.AsEnumerable()
                .Where(row => row.Field<string>("上市地点") == "上海" && row.Field<string>("发行人企业性质") == "民营企业");
            foreach(var row in result)
            {
                Console.WriteLine($"{row.Field<string>("交易代码")}");
            }
        }
    }
}