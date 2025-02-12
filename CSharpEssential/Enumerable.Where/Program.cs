using MiniExcelLibs;

namespace Enumerable.Where
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? testDataFilePath = @"D:\Code\TestData\TestData.xlsx";
            var sheetNames = MiniExcel.GetSheetNames(testDataFilePath);

            foreach (var sheetName in sheetNames)
            {
                Console.WriteLine(sheetName);
            }
        }
    }
}
