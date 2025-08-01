namespace Code_Cast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass1();

            MyClass2 mc2 = (MyClass2)mc;
        }
    }
    internal class MyClass {}

    internal class MyClass1:MyClass {}

    internal class MyClass2 : MyClass1 { }

}
