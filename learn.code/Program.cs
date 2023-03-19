// See https://aka.ms/new-console-template for more information


// 入口方式1：顶级语句
//static void main()
//{

//    Console.WriteLine("[static main] Hello, World!");
//}

//main();


using learn.code;
using learn.code.DataTypes;

public class Program
{

    class Person
    {
        public string? Name { get; set; }
        public int Sex { get; set; }
        public int Age { get; set; }
    }

    static void DoTest()
    {
        Console.WriteLine("-----------------------------------------------------");

        TestValueTypes.RunTest();

        Console.WriteLine("-----------------------------------------------------");

        TestProperties.RunTest();

        Console.WriteLine("-----------------------------------------------------");

    }

    public static void Main(string[] args)
    {
        Console.WriteLine("[Program.Main] Hello World!");

        DoTest();
    }
}
