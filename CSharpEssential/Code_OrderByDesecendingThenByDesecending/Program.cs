using MiniExcelLibs;
using System.Data;

namespace Code_OrderByDesecendingThenByDesecending
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string excelPath = @"D:\Test\RawData.xlsx";
            DataTable sourceDataTable = MiniExcel.QueryAsDataTable(excelPath, sheetName: "总表", useHeaderRow: true);

            //根据"发行规模(亿)"降序序排序，再根据“票面利率(%)”次级降序排序
            sourceDataTable = sourceDataTable.AsEnumerable()
                .OrderByDescending(orderL1 => orderL1.Field<double>("发行规模(亿)"))
                .ThenByDescending(orderL2 => orderL2.Field<double>("票面利率(%)"))
                .CopyToDataTable();

            MiniExcel.SaveAs("C:\\Users\\Karry\\Desktop\\Output.xlsx", sourceDataTable, sheetName: "Sheet1", overwriteFile: true);

        }
    }
}
