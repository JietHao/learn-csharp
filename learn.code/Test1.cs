// 1. 命名空间
// 2. namespace、partial

namespace hj.test
{
    public partial class Test1
	{
		public Test1()
		{
		}
	}
}


namespace hj.test
{
    public partial class Test1
    {

        public Test1(int x)
        {
        }

        public static void printInfo()
        {
            Console.WriteLine("method in partial class Test1");
        }
    }

    public class Test2
    {
        public Test2()
        {
        }
    }
}