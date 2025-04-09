namespace Code_16._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConutContextualKeywords();
        }

        static void ConutContextualKeywords()
        {
            int delegateInvocations = 0;
            Func<string, string> func =
                text =>
                {
                    delegateInvocations++;
                    return text;
                };

            IEnumerable<string> selection =
                from word in Keywords
                where word.Contains('*')
                select func(word);

            //Query is not executed until accessed
            Console.WriteLine($"1. delegateInvocations = {delegateInvocations}");

            //Executing Count should invoke func once for each item selected
            Console.WriteLine($"2. Contextual keyword count = {selection.Count()}");
            Console.WriteLine($"3. delegateInvocations = {delegateInvocations}");

            //Executing Count should invoke func once for each item selected
            Console.WriteLine($"4. Contextual keyword count = {selection.Count()}");
            Console.WriteLine($"5. delegateInvocations = {delegateInvocations}");

            //Cache the value so future Count calls will not trigger another invocation of the query
            //But the query will still be executed while the cache is being populated
            List<string> selectionCache = selection.ToList();
            Console.WriteLine($"6. delegateInvocations = {delegateInvocations}");

            //Executing Count should not invoke func as the cache is already populated
            Console.WriteLine($"7. delegateInvocations = {selectionCache.Count()}");
            Console.WriteLine($"8. delegateInvocations = {delegateInvocations}");

        }

        static string[] Keywords  ={
            "abstract", "add*", "alias*", "as", "ascending*", "async*",
            "await*", "base","bool", "break", "by*", "byte", "case",
            "catch", "char", "checked", "class", "const", "continue",
            "decimal", "default", "delegate", "descending*", "do",
            "double", "dynamic*", "else", "enum", "event", "equals*",
            "explicit", "extern", "false", "finally", "fixed", "from*",
            "float", "for", "foreach", "get*", "global*", "group*",
            "goto", "if", "implicit", "in", "int", "into*", "interface",
            "internal", "is", "lock", "long", "join*", "let*", "nameof*",
            "namespace", "new", "null", "object", "on*", "operator", "orderby*",
            "out", "override", "params", "partial*", "private", "protected",
            "public", "readonly", "ref", "remove*", "return", "sbyte",
            "sealed", "select*", "set*", "short", "sizeof", "stackalloc",
            "static", "string", "struct", "switch", "this", "throw", "true",
            "try", "typeof", "uint", "ulong", "unsafe", "ushort", "using",
            "value*", "var*", "virtual", "unchecked", "void", "volatile",
            "where*", "while", "yield*"
        };
    }
}
