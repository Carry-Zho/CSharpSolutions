using MiniExcelLibs;
using System.Data;

namespace Code_OrderBy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string excelPath = @"D:\Test\RawData.xlsx";
            DataTable sourceDataTable = MiniExcel.QueryAsDataTable(excelPath, sheetName: "总表", useHeaderRow: true);

            //根据"发行规模(亿)"升序排序
            sourceDataTable = sourceDataTable.AsEnumerable()
                .OrderBy(l1 => l1.Field<double>("发行规模(亿)"))
                .ThenBy(l2 => l2.Field<double>("票面利率(%)"))
                .CopyToDataTable();

            MiniExcel.SaveAs("C:\\Users\\Karry\\Desktop\\Output.xlsx", sourceDataTable, sheetName: "Sheet1", overwriteFile:true);
        }
    }
}
