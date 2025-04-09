namespace Code_16._12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GroupKeywords1();
        }
        static void GroupKeywords1()
        {
            IEnumerable <(bool IsContextualKeyword, IGrouping<bool, string> Items)> selection =
                from keyword in Keywords
                group keyword by keyword.Contains("*")
                into groups //用查询延续子句扩展查询
                select
                (
                    IsContextualKeyword: groups.Key,
                    Items: groups
                );
            foreach ((bool IsContextualKeyword, IGrouping<bool, string> Items) wordGroup in selection)
            {
                Console.WriteLine(Environment.NewLine + "{0}:", wordGroup.IsContextualKeyword ? "Contextual Keywords" : "Keywords");
                foreach (string keyword in wordGroup.Items)
                    Console.Write(" " + keyword.Replace("*", null));
            }
        }
        static string[] Keywords { get; set; } = {
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
