using MiniExcelLibs;
using System.IO;

namespace Enumerable.Where
{
    internal class Program
    {
        private static readonly string 交易代码;

        static void Main(string[] args)
        {
            string? testDataFilePath = @"D:\Test\RawData.xlsx";

            //首行作为标题行，读取TestData.xlsx文件“分表”工作簿
            //统计“上市地点”为“上海”，“发行人企业性质”为“民营企业”的数量并逐条输出
            var rows = MiniExcel.Query(testDataFilePath, sheetName: "分表", useHeaderRow: true).ToList();
            var filteredRows = rows.Where(row => row.上市地点 == "上海" && row.发行人企业性质 == "民营企业");
            Console.WriteLine(@"“上市地点”为“上海”，“发行人企业性质”为“民营企业”共有 {0} 家", filteredRows.Count());

            foreach (var row in filteredRows)
            {
                var dictRow = row as IDictionary<string, object>;

                Console.WriteLine("{0,-12}{1,-8}{2,-8}{3,-8}{4,-14}{5,-8}{6,-8}{7,-8}{8,-8}{9,-8}",
                    dictRow["交易代码"],
                    dictRow["发行起始日"],
                    dictRow["发行规模(亿)"],
                    dictRow["票面利率(%)"],
                    dictRow["上市日期"],
                    dictRow["上市地点"],
                    dictRow["利率类型"],
                    dictRow["发行人简称"],
                    dictRow["发行人企业性质"],
                    dictRow["发行人省份"]
                    );
            }
        }
    }
}
