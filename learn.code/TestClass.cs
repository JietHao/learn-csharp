using System;
namespace learn.code
{
	public class TestClass
	{
		public TestClass()
		{
		}


        public static void main(string[] args)
        {
            BaseC bc = new BaseC();
            bc.Invoke();

            DerivedC dc = new DerivedC();
            dc.Invoke();


            BaseC bdc = new DerivedC();
            bdc.Invoke();
        }
	}


    public class BaseC
    {
        public int x;
        public void Invoke()
        {
            Console.WriteLine("BaseC");

        }

        public virtual void Invoke1()
        {
            Console.WriteLine("BaseC");

        }
    }
    public class DerivedC : BaseC
    {
        //new public void Invoke() {
        //    Console.WriteLine("DerivedC");
        //}

        public void Invoke1()
        {
            Console.WriteLine("DerivedC");
        }


        public void Invoke1(string s)
        {
            Console.WriteLine("DerivedC");
        }

        public void Invoke2()
        {
            Console.WriteLine("DerivedC");
        }
    }
}

