using MiniExcelLibs;
using System.Data;  

namespace Core_GroupJoin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? testDataFilePath = @"D:\Test\RawData_GroupJoin.xlsx";
            var Customers = MiniExcel.QueryAsDataTable(testDataFilePath, useHeaderRow: true, sheetName: "Customers");
            var Orders = MiniExcel.QueryAsDataTable(testDataFilePath, useHeaderRow: true, sheetName: "Orders");

            DataTable result = new DataTable();
            result.Columns.Add(new DataColumn(){ColumnName = "OrderID",DataType = typeof(string), AllowDBNull = false});
            result.Columns.Add("OrderID", typeof(string));
            result.Columns.Add("OrderDate", typeof(string));

            //统计"CustomerName"和相应的"OrderID"、"OrderDate"，保存成新表单，
            //没有订单的客户，"OrderID"填充"*","OrderDate"填充"#"

            var maches = Customers.AsEnumerable()
                .GroupJoin(
                    Orders.AsEnumerable(),
                    cus => cus.Field<string>("CustomerID"),
                    ord => ord.Field<string>("CustomerID"),
                    (cus, ords) => new { cus, ords });

        }
    }
}
