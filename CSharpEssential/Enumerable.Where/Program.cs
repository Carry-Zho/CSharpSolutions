using MiniExcelLibs;
using System.IO;

namespace Enumerable.Where
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? testDataFilePath = @"D:\Test\RawData.xlsx";

            //首行作为标题行，读取TestData.xlsx文件“分表”工作簿
            //统计“上市地点”为“上海”，“发行人企业性质”为“民营企业”的数量并逐条输出
            var rows = MiniExcel.Query(testDataFilePath, sheetName: "分表", useHeaderRow: true);
            var filteredRows = rows.Where(row => row.上市地点 == "上海" && row.发行人企业性质 == "民营企业");
            Console.WriteLine(@"“上市地点”为“上海”，“发行人企业性质”为“民营企业”共有 {0} 家", filteredRows.Count());

            foreach (var row in filteredRows)
            {
                Console.WriteLine("{0,-12}{1,-12}{2,-12}{3,-12}{4,-12}{5,-12}{6,-12}{7,-12}",
                    row.交易代码,
                    row.发行起始日,
                    row.上市日期,
                    row.上市地点,
                    row.利率类型,
                    row.发行人简称,
                    row.发行人企业性质,
                    row.发行人省份
                    );
            }
        }
    }
}
