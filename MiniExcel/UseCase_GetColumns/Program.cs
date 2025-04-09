using MiniExcelLibs;
namespace UseCase_GetColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string excelPath = @"D:\Test\RawData.xlsx";
            var columns = MiniExcel.GetColumns(excelPath,sheetName: "总表");
            foreach (var column in columns)
            {
                System.Console.WriteLine($"{column}");
            }
        }
    }
}




