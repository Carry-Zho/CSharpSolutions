using MiniExcelLibs;
using System.Data;
namespace Code_Select
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string excelPath = @"D:\Test\RawData.xlsx";
            DataTable sourceTable = MiniExcel.QueryAsDataTable(excelPath, sheetName: "总表", useHeaderRow: true);

            DataTable newTable1 = new DataTable();
            newTable1.Columns.Add("交易代码", typeof(string));
            newTable1.Columns.Add("发行起始日", typeof(string));
            newTable1.Columns.Add("发行人简称", typeof(string));

            sourceTable.AsEnumerable()
                .Where(rw => rw.Field<string>("发行人企业性质") == "民营企业" && rw.Field<string>("上市地点") == "上海")
                .Select(rw => rw)
                .ToList()
                .ForEach(item => newTable1.Rows.Add(item.Field<string>("交易代码"), item.Field<string>("发行起始日"), item.Field<string>("发行人简称")));

            MiniExcel.SaveAs("C:\\Users\\Karry\\Desktop\\Output1.xlsx", newTable1,sheetName:"Sheet1");

            DataTable newTable2 = new DataTable();
            newTable2.Columns.Add("交易代码", typeof(string));
            newTable2.Columns.Add("发行起始日", typeof(string));
            newTable2.Columns.Add("发行人简称", typeof(string));

            foreach(var item in sourceTable.AsEnumerable()
                .Where(rw => rw.Field<string>("发行人企业性质") == "民营企业" && rw.Field<string>("上市地点") == "上海")
                .Select(rw => new { 交易代码 = rw.Field<string>("交易代码"), 发行起始日= rw.Field<string>("发行起始日"), 发行人简称=rw.Field<string>("发行人简称") }))
            {
                newTable2.Rows.Add(item.交易代码, item.发行起始日, item.发行人简称);
            }
            MiniExcel.SaveAs("C:\\Users\\Karry\\Desktop\\Output2.xlsx", newTable2, sheetName: "Sheet1");
        }
    }
}






