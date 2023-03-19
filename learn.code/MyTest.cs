using System;
namespace learn.code
{
    public class MyClass
    {
        private string Source { get; }
        private string Name { get; }
        private double Count { get; }

        public MyClass(string Source, string Name = "a", double Count = 0)
        {
            this.Source = Source;
            //this.Name = Name;
            this.Count = Count;
            if (Count > 0)
                this.Name = "${Name}_1";
            else
                this.Name = "${Name}_1";
        }

    }

    public static class UserAttribute
    {
        public const string RoleId = "role_id";
    }

    public enum TestEnum
    {
        a = 1,
        b = 2
    }

}

