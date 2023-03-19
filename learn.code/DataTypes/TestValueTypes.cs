using System;
namespace learn.code.DataTypes
{

    public static class TestValueTypes
    {
        public static void RunTest()
        {
            TestSimpleTypes.Test();
            TestEnum.Test();
            TestNull.Test();
        }
    }
    /// <summary>
    /// 值类型
    ///		简单类型
    ///		   整型
    ///		      有符号整型 sbyte、short、int、long
    ///		      无符号整型 byte、ushort、uint、ulong
    ///		   浮点型
    ///		      二进制浮点型 float、double
    ///		      十进制浮点型 decimal
    ///		   字符型 char
    ///		   布尔型 bool
    ///		   取决于运算时的平台 nint、nuint
    ///		枚举类型
    ///		
    /// </summary>
    public static class TestSimpleTypes
    {

        public static void Test()
        {
            // 整型
            // 有符号整型 sbyte、short、int、long
            // 无符号整型 byte、ushort、uint、ulong
            sbyte a = 1;
            short b = 1;
            int c = 1;
            long d = 1;

            Console.WriteLine($"a={a}");
            Console.WriteLine($"b={b}");
            Console.WriteLine($"c={c}");
            Console.WriteLine($"d={d}");


            // 浮点型
            // 二进制浮点型 float、double
            // 十进制浮点型 decimal
            float e = 1.0f;
            double f = 2.0;
            decimal g = 100;

            Console.WriteLine($"e={e}");
            Console.WriteLine($"f={f}");
            Console.WriteLine($"g={g}");

            // 字符型 char
            string s = "Hello";
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine($"s[{i}]={s[i]}");
            }

            // 布尔型 bool
            bool h = false;
            Console.WriteLine($"h={h}");
            // 取决于运行时的平台

            Console.WriteLine($"nint.MinValue: {nint.MinValue}, nint.MaxValue: {nint.MaxValue}");
            Console.WriteLine($"nuint.MinValue: {nuint.MinValue}, nint.MaxValue: {nuint.MaxValue}");

            // 整型文本
            var decimalLiteral = 42;
            var hexLiteral = 0x1A;
            var binaryLiteral = 0b_0110_0100;

            Console.WriteLine($"decimalLiteral={decimalLiteral}");
            Console.WriteLine($"hexLiteral={hexLiteral}");
            Console.WriteLine($"binaryLiteral={binaryLiteral}");

        }


        static void Display<T>(T a, T b)
        {

        }

    }

    public static class TestEnum
    {
        // 枚举值默认整数且从0开始
        public enum Season
        {
            Spring,
            Summer,
            Automn,
            Winter
        }

        public enum ErrorCode : ushort
        {
            None = 0,
            Unknow = 1,
            ConnectLost = 100,
            OutlierReading = 200
        }

        public enum Days
        {
            None = 0b_0000_0000,  // 0
            Monday = 0b_0000_0001, // 1
            Tuesday = 0b_0000_0010, // 2
            Wednesday = 0b_0000_0100,  // 4
            Thursday = 0b_0000_1000,  // 8
            Friday = 0b_0001_0000,  // 16
            Saturday = 0b_0010_0000, // 32
            Sunday = 0b_0100_0000,  // 64
            Weekend = Saturday | Sunday,
        }

        public enum Days2
        {
            None = 0,  // 0
            Monday = 1, // 1
            Tuesday = 1 << 1, // 2
            Wednesday = 1 << 2,  // 4
            Thursday = 1 << 3,  // 8
            Friday = 1 << 4,  // 16
            Saturday = 1 << 5, // 32
            Sunday = 1 << 6,  // 64
            Weekend = Saturday | Sunday,
        }

        public static void Test()
        {

            Season a = Season.Automn;
            Console.WriteLine($"Intergral value of {a} is {(int)a}");

            Season b = (Season)1;
            Console.WriteLine($"b={b}");


            Season c = (Season)4;
            Console.WriteLine($"c={c}");

            ErrorCode e1 = (ErrorCode)100;
            Console.WriteLine($"e1={e1}");

            Days meetingDays = Days.Monday | Days.Wednesday | Days.Friday;
            Console.WriteLine($"meetingDays={meetingDays}");

            Console.WriteLine($"Days.Tuesday={(int)Days.Tuesday}");
            Console.WriteLine($"Days2.Tuesday={(int)Days2.Tuesday}");
            Console.WriteLine($"Days.Weekend={(int)Days.Weekend}");
            Console.WriteLine($"Days2.Weekend={(int)Days2.Weekend}");
        }

    }

    public static class TestNull
    {


        public static void Test()
        {
            bool? flag = null;
            char? letter = 'a';

            Console.WriteLine($"flag={flag}");
            Console.WriteLine($"letter={letter}");

            // 既检查 null 的可为空值类型的实例，又检索基础类型的值
            int? a = 42;
            // valueOfA 局部变量
            if (a is int valueOfA)
            {
                Console.WriteLine($"a is {valueOfA}");
            }
            else
            {
                Console.WriteLine("a does not have a value");
            }

            int? b = 10;
            if (b.HasValue)
            {
                Console.WriteLine($"b is {b.Value}");
            }
            else
            {
                Console.WriteLine("b does not have a value");
            }

            int? c = 7;
            if (c != null)
            {
                Console.WriteLine($"c is {c.Value}");
            }
            else
            {
                Console.WriteLine("c does not have a value");
            }
        }
    }

}
