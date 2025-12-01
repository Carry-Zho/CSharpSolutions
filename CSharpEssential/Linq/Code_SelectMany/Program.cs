namespace Code_SelectMany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string Team, string[] Players)[] worldCup2006Finalists = new[]
            {
                ("France",new string[]{ "Fabien Barthez", "Gregory Coupet"}),
                ("Italy", new string[]{ "Gianluigi Buffon", "Angelo Peruzzi"})
            };


            //生成最终集合元素的过程中可引用原始集合对应元素和其索引
            var result2 = worldCup2006Finalists
                  .SelectMany((team, index) => team.Players.Select(player => (团队编号:index,国家名称:team.Team,运动员: player)));
            foreach (var item in result2)
                Console.WriteLine(item);
        }
    }
}
