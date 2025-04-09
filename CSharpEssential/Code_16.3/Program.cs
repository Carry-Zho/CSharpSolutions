namespace Code_16._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List2(@"D:\Data\new-221108\售前梳理", @"*pptx");
        }

        static void List2(string rootDirectory, string searchPattern)
        {
            var fileNames = Directory.GetFiles(rootDirectory, searchPattern);

            var results =




                from fileName in fileNames
                select (Name: fileName, LastWriteTime: File.GetLastWriteTime(fileName));

            foreach(var result in results)
            {
                Console.WriteLine($"{result.Name} ({result.LastWriteTime})");
            }
        }
    }
}