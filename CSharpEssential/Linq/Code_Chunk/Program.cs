namespace Code_Chunk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string 姓名, string 性别, int 年龄)[] persons =
            {
                ("张三", "男", 25),
                ("李四", "女", 30),
                ("王五", "男", 28),
                ("赵六", "女", 22),
                ("钱七", "男", 35),
                ("孙八", "女", 27),
                ("周九", "男", 29),
                ("吴十", "女", 24),
                ("郑十一", "男", 31),
                ("冯十二", "女", 26)
            };

            var 三三一组 = persons.Chunk(3);

            foreach (var 每组 in 三三一组)
            {
                Console.WriteLine($"每组{每组.Length}个成员");
                foreach (var 每个成员 in 每组)
                {
                    Console.WriteLine($"姓名：{每个成员.姓名}, 性别：{每个成员.性别}, 年龄：{每个成员.年龄}");
                }
            }
        }
    }
}
