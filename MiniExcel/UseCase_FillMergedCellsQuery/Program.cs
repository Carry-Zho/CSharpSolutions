using MiniExcelLibs;
using MiniExcelLibs.OpenXml;
namespace UseCase_FillMergedCellsQuery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string excelPath = @"D:\Test\RawData.xlsx";

            var config = new OpenXmlConfiguration()
            {
                FillMergedCells = true
            };
            var rows = MiniExcel.Query(excelPath, configuration: config);
        }
    }
}
