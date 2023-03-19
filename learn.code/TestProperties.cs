using System;
namespace learn.code
{
	public static class TestProperties
	{
        class Person
        {
            public string? Name { get; set; }
            public int Sex { get; set; }
            public int Age { get; set; }
        }


        public static void RunTest()
        {
            Person person = new Person();
            //person.Name = "nameA";
            person.Sex = 0;
            person.Age = 20;

            Console.WriteLine($"person.Name:{person.Name ?? "Name11"}");

            foreach (System.Reflection.PropertyInfo prop in typeof(Person).GetProperties())
            {
                Console.WriteLine($"propName: {prop.Name}");
            }

            foreach (System.Reflection.PropertyInfo prop in person.GetType().GetProperties())
            {
                Console.WriteLine($"propName: {prop.Name}, propValue: {prop.GetValue(person, null)}");
            }
        }


    }
}

