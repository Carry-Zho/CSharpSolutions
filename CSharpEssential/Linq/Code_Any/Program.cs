using MiniExcelLibs;
using System.Data;
namespace Code_Any
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string excelPath = @"D:\Test\RawData_Any.xlsx";
            DataTable rawData = MiniExcel.QueryAsDataTable(excelPath, sheetName: "分表", useHeaderRow: true);

            //查询"分表"中"交易代码"是否存在"127793.SH"
            Console.WriteLine(rawData.AsEnumerable().Any(rw => rw.Field<string>("交易代码") == "127793.SH"));
            //查询"分表"中"交易代码"是否存在"00001.SH"
            Console.WriteLine(rawData.AsEnumerable().Any(rw => rw.Field<string>("交易代码") == "00001.SH"));
        }
    }
}
