using MiniExcelLibs;
using System.Linq;
using System.Data;

namespace Code_Join
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? testDataFilePath = @"D:\Test\RawData_Join.xlsx";
            var table1 = MiniExcel.QueryAsDataTable(testDataFilePath,useHeaderRow:true,sheetName: "表1").AsEnumerable();
            var table2 = MiniExcel.QueryAsDataTable(testDataFilePath, useHeaderRow: true, sheetName: "表2").AsEnumerable();

            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("交易代码", typeof(string));
            resultTable.Columns.Add("发行人简称", typeof(string));
            resultTable.Columns.Add("发行人企业性质", typeof(string));
            resultTable.Columns.Add("发行人省份", typeof(string));
            resultTable.Columns.Add("发行起始日", typeof(string));
            resultTable.Columns.Add("发行规模(亿)", typeof(double));

            table1.Join(table2, row1 => row1.Field<string>("交易代码"), row2 => row2.Field<string>("交易代码"),
                (rw1, rw2) => (
                rw1.Field<string>("交易代码"), 
                rw1.Field<string>("发行人简称"), 
                rw2.Field<string>("发行人企业性质"), 
                rw2.Field<string>("发行人省份"), 
                rw1.Field<string>("发行起始日"), 
                rw1.Field<double>("发行规模(亿)")
                )).ToList().ForEach(
                ele => resultTable.Rows.Add(ele.Item1,ele.Item2,ele.Item3,ele.Item4,ele.Item5,ele.Item6));

            MiniExcel.SaveAs("C:\\Users\\Karry\\Desktop\\Output.xlsx", resultTable, sheetName: "Sheet1");

        }
    }
}