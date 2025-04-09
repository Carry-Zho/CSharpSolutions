using MiniExcelLibs;
using System.Data;
namespace UseCase_QueryAsDataTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string excelPath = @"D:\Test\RawData.xlsx";

            var table = MiniExcel.QueryAsDataTable(excelPath, sheetName: "分表", useHeaderRow: true);
            foreach (var row in table.AsEnumerable())
            {
                Console.WriteLine(row["交易代码"] + "\t" + row["发行规模(亿)"]+ "\t"+ row["发行规模(亿)"].GetType() + "\t" + row["上市日期"] + "\t"+ row["上市日期"].GetType());
            }
        }
    }
}