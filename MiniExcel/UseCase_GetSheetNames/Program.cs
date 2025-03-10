using MiniExcelLibs;
namespace UseCase_GetSheetNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string excelPath = @"D:\Test\RawData.xlsx";
            var sheetNames = MiniExcel.GetSheetNames(excelPath);
            foreach (var sheetName in sheetNames)
            {
                System.Console.WriteLine(sheetName);
            }
        }
    }
}
