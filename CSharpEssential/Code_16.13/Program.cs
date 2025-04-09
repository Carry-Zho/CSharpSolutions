namespace Code_16._13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] keywords = { "foreach", "abstract" };
            var selection =
                from word in keywords
                from character in word
                select character;
            foreach (var character in selection)
            {
                Console.Write(character + " ");
            }
                
        }
    }
}
