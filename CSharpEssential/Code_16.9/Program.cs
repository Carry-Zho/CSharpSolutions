namespace Code_16._9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListByFileSize2(@"D:\Code\CSharpSolutions\CSharpEssential\Code_16.8\bin\Debug\net8.0\Test", "*.xlsx");
        }

        //投射一个FileInfo集合并按文件大小排序
        static void ListByFileSize2(string rootDirectory, string searchPattern)
        {
            IEnumerable<FileInfo> files =
                from fileName in Directory.EnumerateFiles(rootDirectory, searchPattern)
                let fileInfo = new FileInfo(fileName)   //使用let子句引入新的范围变量，避免多次实例化FileInfo
                orderby fileInfo.Length, fileName
                select fileInfo;

            foreach (FileInfo file in files)
            {
                //假设搜索的目录处在当前运行目录的子目录Test下
                string relativePath = file.FullName.Substring(rootDirectory.Length);
                Console.WriteLine($".{relativePath} ({file.Length / 1024} Kb)");
            }
        }
    }
}
