namespace Code_FindAll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new() { 1,2,3,4,5,6,7,8,9 };
            
            List<int> newList = list.FindAll(x => x > 2 && x <5);

            foreach (var item in newList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
