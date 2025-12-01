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
            var Orders = MiniExcel.QueryAsDataTable(testDataFilePath, useHeaderRow: true, sheetName: "0rders");

            DataTable result = new DataTable();
            result.Columns.Add("CustomerName", typeof(string)); 
            result.Columns.Add("OrderID", typeof(string));
            result.Columns.Add("OrderDate", typeof(string));

            //统计"CustomerName"和相应的"OrderID"、"OrderDate"，保存成新表单，
            //没有订单的客户，"OrderID"填充"*","OrderDate"填充"#"

            Customers.AsEnumerable()
                .GroupJoin(
                    Orders.AsEnumerable(),
                    cus => cus.Field<double>("CustomerID"),
                    ord => ord.Field<double>("CustomerID"),
                    (cus, ords) => new { CustomerName = cus.Field<string>("CustomerName"), OrderGroups = ords })
                .SelectMany(item => item.OrderGroups.DefaultIfEmpty(),
                                        (cus,ord) => 
                                        new { 
                                                CustomerName = cus.CustomerName, 
                                                OrderID = ord !=null ? ord.Field<double>("OrderID").ToString() : "*", 
                                                OrderDate = ord != null ? ord.Field<DateTime>("OrderDate").ToString("yyyy/MM/dd") : "#"
                                             }
                                        )
                .ToList()
                .ForEach(ele => result.Rows.Add(ele.CustomerName, ele.OrderID, ele.OrderDate) );

            //保存成新Excel
            MiniExcel.SaveAs("C:\\Users\\Karry\\Desktop\\Output.xlsx", result, sheetName: "Sheet1", overwriteFile: true);

        }
    }
}
