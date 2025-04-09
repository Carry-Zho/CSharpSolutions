using MiniExcelLibs;
using System.Collections.Generic;
namespace UseCase_Query
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string excelPath = @"D:\Test\RawData.xlsx";
            var rows = MiniExcel.Query(excelPath, useHeaderRow:true, sheetName:"分表").ToList();  //rows运行时解析为List<ExpandoObject>
            var columns =MiniExcel.GetColumns(excelPath,useHeaderRow:true).ToList();

            //打印列名
            foreach (var col in columns) 
            {
                Console.Write(col+"      ");
            }
            Console.WriteLine();

            //打印每行每单元格
            //rows运行时解析为List<ExpandoObject>,ExpandoObject实现IDynamicMetaObjectProvider接口，通过dynamic可以直接访问属性
            //特别注意，属性名为C#标识符，无法使用除_外的其他符号，因此"发行规模(亿)"、"票面利率(%)"列无法通过属性名访问（语法不合法）
            foreach (var row in rows)
            {
                Console.Write(row.交易代码 + "\t");
                Console.Write(row.发行起始日 + "\t");
                //Console.Write(row.发行规模(亿) + "\t");   C#属性名不能出现除_外的其他符号，语法不合法
                //Console.Write(row.票面利率(%) + "\t");    C#属性名不能出现除_外的其他符号，语法不合法
                Console.Write(row.上市日期 + "\t");
                Console.Write(row.上市地点 + "\t");
                Console.Write(row.利率类型 + "\t");
                Console.Write(row.发行人简称 + "\t");
                Console.Write(row.发行人企业性质 + "\t");
                Console.Write(row.发行人省份 + "\t");
                Console.WriteLine();
            }


            Console.WriteLine("**************************************************************************************************");

            //打印每行每单元格
            //rows运行时解析为List<ExpandoObject>,ExpandoObject显式实现IDictionary接口，ExpandoObject显式转型为IDictionary后可通过.Key、.Value访问
            foreach (var row in rows)
            {
                if (row != null)
                {
                    var iDic = row as IDictionary<string, object>;
                    foreach (var item in iDic)
                    {
                        Console.Write(item.Value + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
