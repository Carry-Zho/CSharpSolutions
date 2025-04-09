using MiniExcelLibs;

namespace UseCase_QueryRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string excelPath = @"D:\Test\RawData.xlsx";
            
            var rows = MiniExcel.QueryRange(excelPath, useHeaderRow:true, sheetName: "分表", startCell:"E1", endCell:"F4");

            foreach (var row in rows)
            {
                Console.Write(row.上市日期+"\t");
                Console.Write(row.上市地点 + "\t");
                System.Console.WriteLine();
            }
        }
    }
}
