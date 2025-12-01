namespace Code_ExceptBy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var productsInStock = new List<Product>
            {
                new Product(productID:1,productName:"Product A"),
                new Product (productID:2, productName:"Product B"),
                new Product (productID:3, productName:"Product C"),
                new Product (productID:4, productName:"Product D"),
            };
            var soldProducts = new List<Product>
            {
                new Product(productID:2,productName:"Product B"),
                new Product (productID:4, productName:"Product D"),
            };

            var availableProducts = productsInStock
                .ExceptBy(soldProducts.Select(item =>item.ProductID),ele =>ele.ProductID);

            Console.WriteLine("Available Products:");
            foreach (var item in availableProducts)
            {
                Console.WriteLine($"ProductID: {item.ProductID}, ProductName: {item.Name}");
            }
        }
    }
    internal class Product
    {
        public Product(int productID, string? productName)
        {
            ProductID = productID;
            Name = productName;
        }
        public int ProductID { get; }
        public string? Name { get; set; }
    }
}
