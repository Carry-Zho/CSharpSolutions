using MiniExcelLibs;
using System.Data;
namespace UseCase_Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string excelPath = @"D:\Test\RawData.xlsx";

            //查询并打印“发行人省份”为“上海”的“交易代码”
            var table = MiniExcel.Query(excelPath, sheetName: "分表", useHeaderRow: true);
            var rows = 
                from row in table
                where row.发行人省份.ToString() == "上海"
                select row;

            Console.WriteLine(rows.Count());
            foreach (var row in rows)
            {
                Console.WriteLine(row.交易代码);
            }
        }
    }
}







