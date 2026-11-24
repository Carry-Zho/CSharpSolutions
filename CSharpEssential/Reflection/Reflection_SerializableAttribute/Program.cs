//BinaryFormatter 自 .NET 9 移除
//本例设定框架为<TargetFramework>net6.0</TargetFramework>
using System.Runtime.Serialization.Formatters.Binary;

namespace Reflection_SerializableAttribute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stream stream;
            Document documentBefore = new Document();
            documentBefore.Title = ".NET serializable attribute doc";

            //将Document 对象 documentBefore 序列化为二进制流，存储在.bin文件
            using (stream = File.Open(documentBefore.Title + ".bin", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, documentBefore);
            }

            //从二进制 .bin 文件读取流数据，反序列化为 Document 对象 documentAfter
            Document documentAfter;
            using (stream = File.Open(documentBefore.Title + ".bin", FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                documentAfter = (Document)formatter.Deserialize(stream);
            }

            Console.WriteLine(documentAfter.Title);
        }
    }


    //使用 SerializableAttribute/NonSerializedAttribute 预定义特性的类，辅助格式化程序类格式化
    [SerializableAttribute]
    internal class Document
    {
        public string Title = null;
        public string Data = null;

        [NonSerializedAttribute]
        public long _WindowHandle = 0;

        [NonSerializedAttribute]
        private Image Picture = new Image();
        class Image { }
    }
}