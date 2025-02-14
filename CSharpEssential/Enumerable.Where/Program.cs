using MiniExcelLibs;
using System.IO;

namespace Enumerable.Where
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? testDataFilePath = @"D:\Code\TestData\TestData.xlsx";

            //var columns = MiniExcel.GetColumns(testDataFilePath, useHeaderRow: true);

            //foreach (var column in columns)
            //{
            //    Console.WriteLine(column.ToString());
            //}

            var rows = MiniExcel.Query(testDataFilePath).ToList();


            foreach (var row in rows)
            {
                // 直接通过表头名称访问值
                var salesAmount = row["发行规模(亿)"];
                var date = row["票面利率(%)"];

                Console.WriteLine($"发行规模(亿): {salesAmount}, 票面利率(%): {date}");
            }

            //首行作为标题行，读取TestData.xlsx文件“分表”工作簿
            //统计“上市地点”为“上海”，“发行人企业性质”为“民营企业”的数量并逐条输出
            //var rows = MiniExcel.Query(testDataFilePath, sheetName: "分表", useHeaderRow: true).ToList();
            //var filteredRows = rows.Where(row => row.上市地点 == "上海" && row.发行人企业性质 == "民营企业");
            //Console.WriteLine(@"“上市地点”为“上海”，“发行人企业性质”为“民营企业”共有 {0} 家", filteredRows.Count());

            //Console.WriteLine("{0,-8}{1,-8}{2,-8}{3,-8}{4,-8}{5,-8}{6,-8}{7,-8}{8,-8}{9,-8}{10,-8}{11,-8}",
            //    "交易代码",
            //    "发行起始日",
            //    "摘牌日期",
            //    "发行规模(亿)",
            //    "票面利率(%)",
            //    "上市日期",
            //    "上市地点",
            //    "利率类型",
            //    "发行人简称",
            //    "发行人企业性质",
            //    "发行人省份",
            //    "发行人城市"
            //    );

            //foreach (var row in filteredRows)
            //{
            //    Console.WriteLine("{0,-8}{1,-8}{2,-8}{3,-8}{4,-8}{5,-8}{6,-8}{7,-8}{8,-8}{9,-8}{10,-8}{11,-8}",
            //        row.交易代码,
            //        row.发行起始日,
            //        row.摘牌日期,
            //        row.Item3,
            //        row.Item4,
            //        row.上市日期,
            //        row.上市地点,
            //        row.利率类型,
            //        row.发行人简称,
            //        row.发行人企业性质,
            //        row.发行人省份,
            //        row.发行人城市
            //        );
            //}
        }
    }
}
