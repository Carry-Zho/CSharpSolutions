using MiniExcelLibs;
using System.Data;
namespace Code_ToList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //筛选"上市地点"为"上海"的债券，截取"交易代码"、"发行起始日"、"发行规模(亿)"列，另存为新Excel
            string excelFilePath = @"D:\Test\RawData_ToList.xlsx";

            DataTable excelData = MiniExcel.QueryAsDataTable(excelFilePath,useHeaderRow:true,sheetName:"Data");

            Console.WriteLine(excelData.Rows.Count);

            DataTable newData = new DataTable();
            newData.Columns.Add("交易代码", typeof(string));
            newData.Columns.Add("发行起始日",typeof(string));
            newData.Columns.Add("发行规模(亿)", typeof(double));

            excelData.AsEnumerable()
                .Where(row => (!string.IsNullOrWhiteSpace(row.Field<string>("交易代码"))) && row.Field<string>("上市地点")!.Contains("上海"))
                .ToList()
                    .ForEach(rw => newData.Rows.Add
                                                    (
                                                        rw.Field<string>("交易代码"), 
                                                        rw.Field<string>("发行起始日"), 
                                                        rw.Field<double>("发行规模(亿)")
                                                    )
                    );

            MiniExcel.SaveAs(@"C:\\Users\\Karry\\Desktop\\Output.xlsx", newData, sheetName:"newData",overwriteFile:true);

        }
    }
}
