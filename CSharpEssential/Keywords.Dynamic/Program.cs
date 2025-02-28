using System.Dynamic;
namespace Keywords.Dynamic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dynamic person = new ExpandoObject();
            person.Name = "Alice";  //正确，dynamic避免编译时检查，DLR把person解析成ExpandoObject，
                                    //ExpandoObject实现IDynamicMetaObjectProvider，支持动态添加属性


            IDynamicMetaObjectProvider metaProvider = person;
            metaProvider.Name = "Bob";  //错误
                                        //a、编译器只对dynamic禁止类型检查，metaProvider是IDynamicMetaObjectProvider类型，编译器会检查，IDynamicMetaObjectProvider没有定义Name属性
                                        //b、ExpandoObject实现IDynamicMetaObjectProvider接口，但是IDynamicMetaObjectProvider本身不提供直接操作对象成员（如添加、修改、删除属性和方法）的功能
        }
    }
}