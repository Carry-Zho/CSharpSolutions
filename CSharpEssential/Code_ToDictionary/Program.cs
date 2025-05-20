using MiniExcelLibs;
using System.Data;
namespace Code_ToDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string excelFile = @"D:\Test\RawData_ToDic.xlsx";
            DataTable excelData = MiniExcel.QueryAsDataTable(excelFile,sheetName:"Data", useHeaderRow:true);
            Dictionary<string, double> stockDic = excelData.AsEnumerable()
                .ToDictionary(rw => rw.Field<string>("交易代码")!,rw =>rw.Field<double>("发行规模(亿)"));

            foreach (var keyValuePair in stockDic)
            {
                Console.WriteLine($"Key: {keyValuePair.Key}, Value: {keyValuePair.Value}");
            }

        }
    }
}
