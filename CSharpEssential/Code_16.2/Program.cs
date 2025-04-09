namespace Code_16._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List1(@"D:\Data\new-221108\售前梳理", @"*pptx");
        }
        static void List1(string rootDirectory, string searchPattern)
        { 
            IEnumerable<string> fileNames = Directory.GetFiles(rootDirectory, searchPattern);

            IEnumerable<FileInfo> fileInfos = 
                from file in fileNames
                select new FileInfo(file);

            foreach(FileInfo fi in fileInfos)
            {
                Console.WriteLine($@"{fi.Name} ({fi.LastWriteTime})");
            }
        }
    }
}