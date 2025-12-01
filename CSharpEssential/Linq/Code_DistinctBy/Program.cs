using MiniExcelLibs;
using System.Data;
using System.Linq;

namespace Code_DistinctBy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string excelPath = @"D:\Test\RawData.xlsx";
            DataTable 分表 = MiniExcel.QueryAsDataTable(excelPath, sheetName: "分表", useHeaderRow: true);
            DataTable 总表 = MiniExcel.QueryAsDataTable(excelPath, sheetName: "总表", useHeaderRow: true);
            var 总分去重行数 = 分表.AsEnumerable().Concat(总表.AsEnumerable()).DistinctBy(rw => rw.Field<string>("交易代码")).Count();

            Console.WriteLine($"总分去重行数:{总分去重行数}");
        }
    }
}
