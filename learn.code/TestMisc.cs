using System;
namespace learn.code
{
	public class TestMisc
	{

        public static void Test()
        {

            //Dictionary<int, int> d = new Dictionary<int, int>();
            //d[1] = 1;
            //Console.WriteLine($"d.length: {d.Count}");

            //foreach(var item in d)
            //{
            //    Console.Write($"k={item.Key},v={item.Value}");
            //}

            //Console.WriteLine($" now: {new TimeInfo().ServerNow()}");

            //string s = "";
            //string[] a = s.Split(";");
            //Console.WriteLine($"s=[{s}], a={a}");
            //double f = 1.0 / 2;
            //Console.WriteLine($"f={f}");

            //Console.WriteLine("hasProperty:", typeof(UserAttribute));


            //Console.WriteLine(1.1.ToString());
            //Console.WriteLine($"{0:111111}");


            //for (var i = 0; i < 100; i++)
            //{
            //    string uuid = GetUUID();
            //    Console.WriteLine(uuid);
            //}

            //Dictionary<string, int> testD = {"a": 1};
            var testDict = new Dictionary<string, int>()
            {
                ["a1"] = 1,
                ["b1"] = 2,
            };

            var testDict2 = new Dictionary<string, int>()
            {
                {"a2", 1 },
                {"b2", 2 }
            };

            Console.WriteLine($"testDict: {testDict}");
            Console.WriteLine($"testDict2: {testDict2}");

            TimeInfo timeIns = new TimeInfo();
            long serverNow = timeIns.ServerNow();
            DateTime dt = timeIns.ToDateTime(serverNow);

            Console.WriteLine(serverNow);
            Console.WriteLine(dt);
            Console.WriteLine(dt.ToString("yyyy-MM-dd"));
            Console.WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss"));

            Console.WriteLine(timeIns.ToDateTimeStr(serverNow));
            Console.WriteLine(timeIns.ToDateTimeStr(serverNow, "yyyy-MM-dd"));


            //TimeInfo? t = null;
            //if (t == null)
            //    t = new();
        }
    }

    //static string GetUUID()
    //{
    //    Guid guid = Guid.NewGuid();
    //    string uuid = guid.ToString("N"); // N表示不带分隔符的32位UUID

    //    return uuid;
    //}
}

