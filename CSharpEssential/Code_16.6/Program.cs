namespace Code_16._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FindMonthOldFiles(@"D:\Code\CSharpSolutions\CSharpEssential\Code_16.6\bin\Debug\net8.0\Test", @"*.pptx");
        }
        static void FindMonthOldFiles(string rootDirectory,string searchPattern) 
        {
            IEnumerable<FileInfo> files =
                from fileName in Directory.EnumerateFiles(rootDirectory,searchPattern)
                where File.GetLastWriteTime(fileName) < DateTime.Now.AddMonths(-1)
                select new FileInfo(fileName);
            foreach (FileInfo file in files)
            {
                //假设搜索的目录处在当前目录的子目录Test下
                string relativePath = file.FullName.Substring(Environment.CurrentDirectory.Length);
                Console.WriteLine($".{relativePath} ({file.LastWriteTime})");
            }
        }
    }
}




