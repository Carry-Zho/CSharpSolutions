using MiniExcelLibs;
using System.Data;
namespace Code_ToArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string excelFilePath = @"D:\Test\RawData.xlsx";

            DataTable excelData = MiniExcel.QueryAsDataTable(excelFilePath,sheetName: "总表", useHeaderRow:true);
            var rowArray = excelData.AsEnumerable().ToArray();
            Console.WriteLine(rowArray.GetType());
        }
    }
}
