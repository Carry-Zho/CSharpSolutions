using MiniExcelLibs;
using System.Data;
namespace Code_FirstOrLast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string excelPath = @"D:\Test\RawData.xlsx";
            var table = MiniExcel.QueryAsDataTable(excelPath, sheetName: "总表", useHeaderRow: true);
            var rows = table.AsEnumerable();

            //FirstOrDefault
            var firstResult = rows.FirstOrDefault(row => row.Field<string>("发行人企业性质") == "民营企业" && row.Field<string>("上市地点") == "上海",default(DataRow));
            Console.WriteLine(firstResult?.Field<string>("交易代码"));

            //LastOrDefault
            var lastResult = rows.LastOrDefault(row => row.Field<string>("发行人企业性质") == "民营企业" && row.Field<string>("上市地点") == "上海", default(DataRow));
            Console.WriteLine(lastResult?.Field<string>("交易代码"));

        }
    }
}




