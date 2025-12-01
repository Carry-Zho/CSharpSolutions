using MiniExcelLibs;
using System.Data;
namespace Code_GroupBy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string excelPath = @"D:\Test\RawData.xlsx";
            DataTable 总表 = MiniExcel.QueryAsDataTable(excelPath, sheetName: "总表", useHeaderRow: true);
            var result = 总表.AsEnumerable().GroupBy(rw => rw.Field<string>("发行人省份"),rw => rw, (key, group)=> 
            new { 
                    发行人省份 = key, 
                    发行规模最大 = new { 
                        交易代码 = group.MaxBy(ele => Convert.ToDouble(ele.Field<double>("发行规模(亿)"))).Field<string>("交易代码"),
                        发行起始日 = group.MaxBy(ele => Convert.ToDouble(ele.Field<double>("发行规模(亿)"))).Field<string>("发行起始日"),
                        发行规模 = group.MaxBy(ele => Convert.ToDouble(ele.Field<double>("发行规模(亿)"))).Field<double>("发行规模(亿)")
                    },
                    发行规模最小 = new {
                        交易代码 = group.MinBy(ele => Convert.ToDouble(ele.Field<double>("发行规模(亿)"))).Field<string>("交易代码"),
                        发行起始日 = group.MinBy(ele => Convert.ToDouble(ele.Field<double>("发行规模(亿)"))).Field<string>("发行起始日"),
                        发行规模 = group.MinBy(ele => Convert.ToDouble(ele.Field<double>("发行规模(亿)"))).Field<double>("发行规模(亿)")
                }
            });

            //发行人省份分组，打印每组中"发行规模(亿)"最小和最大的"交易代码"、"发行起始日"、"发行规模(亿)"

            foreach (var group in result)
            {
                Console.WriteLine($"发行人省份: {group.发行人省份}");
                Console.WriteLine($"发行规模最大: 交易代码: {group.发行规模最大.交易代码}, 发行起始日: {group.发行规模最大.发行起始日}, 发行规模(亿): {group.发行规模最大.发行规模}");
                Console.WriteLine($"发行规模最小: 交易代码: {group.发行规模最小.交易代码}, 发行起始日: {group.发行规模最小.发行起始日}, 发行规模(亿): {group.发行规模最小.发行规模}");
            }
        }
    }
}