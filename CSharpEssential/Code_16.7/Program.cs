namespace Code_16._7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListByFileSize1(@"D:\Data\new-221108\售前梳理", @"*.pptx");
        }
        static void ListByFileSize1(string rootDirectory,string searchPattern)
        { 
            IEnumerable<string> fileNames = 
                from fileName in Directory.GetFiles(rootDirectory, searchPattern)
                orderby (new FileInfo(fileName)).Length, fileName descending
                select fileName;
            foreach (string fileName in fileNames)
                Console.WriteLine("{0},{1} Kb",fileName,(new FileInfo(fileName)).Length/1024);
        }
    }
}
