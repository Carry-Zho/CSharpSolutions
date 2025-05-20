using MiniExcelLibs;
using System.Data;
namespace Code_Concat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string excelPath = @"D:\Test\RawData.xlsx";
            DataTable 分表 = MiniExcel.QueryAsDataTable(excelPath, sheetName: "分表", useHeaderRow: true);
            DataTable 总表 = MiniExcel.QueryAsDataTable(excelPath, sheetName: "总表", useHeaderRow: true);

            DataTable 总分 = 分表.AsEnumerable().Concat(总表.AsEnumerable()).CopyToDataTable();

            MiniExcel.SaveAs("C:\\Users\\Karry\\Desktop\\Output.xlsx", 总分, sheetName: "Sheet1");
        }
    }
}
