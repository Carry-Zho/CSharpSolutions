using Newtonsoft.Json.Linq;

namespace Code_JSONPath_Examples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonFilePath = @"JSON.json";
            string jsonText = File.ReadAllText(jsonFilePath);

            //反序列化
            JToken jtk = JToken.Parse(jsonText);

            //使用$，获取JSON文档的全部内容
            JToken allJSONContent = jtk.SelectToken("$")!;
            Console.WriteLine("使用$，获取JSON文档的全部内容---------------------------------------");
            Console.WriteLine(allJSONContent.ToString());

            //使用.PropertyName子运算符,获取商店中的自行车
            JToken bicycle = jtk.SelectToken("$.store.bicycle")!;
            Console.WriteLine("\n使用.PropertyName子运算符,获取商店中的自行车---------------------------------------");
            Console.WriteLine(bicycle.ToString());
            //使用['PropertyName']子运算符,获取商店中的自行车
            Console.WriteLine("\n使用['PropertyName']子运算符,获取商店中的自行车---------------------------------------");
            //string jsonPath = "$.store[\"bicycle\"]";  Error, .NET字符串内的双引号必须转义，Json.NET 无法解析转义双引号
            string jsonPath = "$.store['bicycle']";
            bicycle = jtk.SelectToken(jsonPath)!;
            Console.WriteLine(bicycle.ToString());

            //使用[2]下标运算符,获取商店书籍中第三本书
            JToken thirdBook = jtk.SelectToken("$.store.book[2]")!;
            Console.WriteLine("\n使用[2]下标运算符,获取商店书籍中第三本书---------------------------------------");
            Console.WriteLine(thirdBook.ToString());

            //使用联合运算符[0,1]，获取前两本书
            Console.WriteLine("\n使用联合运算符[0,1]，获取前两本书---------------------------------------");
            var firstTwoBooks = jtk.SelectTokens("$..book[0,1]");
            foreach (var book in firstTwoBooks)
            {
                Console.WriteLine(book.ToString());
            }

            //使用联合运算符[,]，获取商店中第一本书籍和第一辆自行车
            Console.WriteLine("\n使用联合运算符[,]，获取商店中第一本书籍和第一辆自行车--------------------------------------");
            var firstBookAndBicycle = jtk.SelectTokens(@"$.store['book','bicycle'][0]");
            foreach (var item in firstBookAndBicycle)
            {
                Console.WriteLine(item.ToString());
            }

            //使用数组分片[:2]，获取前两本书
            Console.WriteLine("\n使用数组分片[:2]，获取前两本书---------------------------------------");
            firstTwoBooks = jtk.SelectTokens("$..book[:2]");
            foreach (var book in firstTwoBooks)
            {
                Console.WriteLine(book.ToString());
            }

            //使用数组分片[-1:]，按获取最后一本书
            JToken lastBook = jtk.SelectToken("$..book[-1:]")!;
            Console.WriteLine("\n使用数组分片[-1:]，按获取最后一本书---------------------------------------");
            Console.WriteLine(lastBook.ToString());

            //使用数组分片[-2:]，获取最后两本书
            Console.WriteLine("\n使用数组分片[-2:]，获取最后两本书---------------------------------------");
            var lastTwoBooks = jtk.SelectTokens("$..book[-2:]");
            foreach (var book in lastTwoBooks)
            {
                Console.WriteLine(book.ToString());
                Console.WriteLine("<-------->");
            }

            //使用联合运算符[1,2]，获取第二、第三本书
            Console.WriteLine("\n使用联合运算符[1,2]，获取第二、第三本书---------------------------------------");
            var secondAndThirdBooks = jtk.SelectTokens("$..book[1,2]");
            foreach (var book in secondAndThirdBooks)
            {
                Console.WriteLine(book.ToString());
                Console.WriteLine("<-------->");
            }

            //使用数组分片[1:3],获取第二、第三本书
            Console.WriteLine("\n使用数组分片[1:3],获取第二、第三本书---------------------------------------");
            secondAndThirdBooks = jtk.SelectTokens("$..book[1:3]");
            foreach (var book in secondAndThirdBooks)
            {
                Console.WriteLine(book.ToString());
                Console.WriteLine("<-------->");
            }

            //使用联合运算符[1,2].title,获取第二、第三本书的标题,
            Console.WriteLine("\n使用联合运算符[1,2].title,获取第二、第三本书的标题,---------------------------------------");
            var secondAndThirdBookTitles = jtk.SelectTokens("$..book[1,2].title");
            foreach (var title in secondAndThirdBookTitles)
            {
                Console.WriteLine(title.ToString());
                Console.WriteLine("<-------->");
            }

            //使用数组分片[1:3].title,获取第二、第三本书的标题
            Console.WriteLine("\n使用数组分片[1:3].title,获取第二、第三本书的标题e---------------------------------------");
            secondAndThirdBookTitles = jtk.SelectTokens("$..book[1:3].title");
            foreach (var title in secondAndThirdBookTitles)
            {
                Console.WriteLine(title.ToString());
                Console.WriteLine("<-------->");
            }

            //使用通配符*,获取商店中所有商品（书籍和自行车）
            Console.WriteLine("\n获取商店中所有商品（书籍和自行车）--------------------------------------\"");
            var allItems = jtk.SelectTokens("$.store.*");
            foreach (var item in allItems)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine("<-------->");
            }

            //使用通配符[*],获取商店中所有书籍的作者
            Console.WriteLine("\n使用通配符[*],获取商店中所有书籍的作者--------------------------------------");
            var authors = jtk.SelectTokens("$.store.book[*].author");
            foreach (var author in authors)
            {
                Console.WriteLine(author.ToString());
                Console.WriteLine("<-------->");
            }

            //使用通配符.*,获取商店中所有书籍的所有属性
            Console.WriteLine("\n使用通配符[*],获取商店中所有书籍的所有属性--------------------------------------");
            var allBooksProperties = jtk.SelectTokens("$.store.book[*].*");
            foreach (var property in allBooksProperties)
            {
                Console.WriteLine(property.ToString());
                Console.WriteLine("<-------->");
            }

            //使用递归下降..,获取JSON文档内的所有作者
            Console.WriteLine("\n使用递归下降..,获取JSON文档内的所有作者--------------------------------------");
            var allAuthors = jtk.SelectTokens("$..author");
            foreach (var author in allAuthors)
            {
                Console.WriteLine(author.ToString());
                Console.WriteLine("<-------->");
            }


            //使用递归下降..,获取商店内的所有价格
            Console.WriteLine("\n使用递归下降..,获取商店内的所有价格--------------------------------------");
            var allPrices = jtk.SelectTokens("$.store..price");
            foreach (var price in allPrices)
            {
                Console.WriteLine(price.ToString());
                Console.WriteLine("<-------->");
            }

            //使用过滤器运算符及属性检查[?(@.isbn)],筛选书籍中带isbn号属性的书籍
            Console.WriteLine("\n使用过滤器运算符及属性检查[?(@.isbn)],筛选书籍中带isbn号属性的书籍--------------------------------------");
            var booksWithISBN = jtk.SelectTokens("$.store.book[?(@.isbn)]");
            foreach (var book in booksWithISBN)
            {
                Console.WriteLine(book.ToString());
                Console.WriteLine("<-------->");
            }

            //使用LINQ查询筛选不带isbn号的书籍（Json.NET不支持 [?(!@.isbn)]）
            Console.WriteLine("\n使用LINQ查询筛选不带isbn号的书籍（Json.NET不支持 [?(!@.isbn)]））--------------------------------------");
            var booksWithoutISBN = jtk.SelectToken("$.store.book")!.Where(b => b["isbn"] == null);
            foreach (var book in booksWithoutISBN)
            {
                Console.WriteLine(book.ToString());
                Console.WriteLine("<-------->");
            }

            //使用过滤运算符?(@.price < 10)筛选价格低于10的书籍
            Console.WriteLine("\n使用过滤运算符?(@.price < 10)筛选价格低于等于10的书籍--------------------------------------");
            var cheapBooks = jtk.SelectTokens("$.store.book[?(@.price <= 10)]");
            foreach (var book in cheapBooks)
            {
                Console.WriteLine(book.ToString());
                Console.WriteLine("<-------->");
            }

            //使用$..*，获取JSON文档的所有value
            Console.WriteLine("\n使用$..*，获取JSON文档的所有value--------------------------------------");
            var allValues = jtk.SelectTokens("$..*");
            foreach (var value in allValues)
            {
                Console.WriteLine(value.ToString());
                Console.WriteLine("<-------->");
            }
        }
    }
}
