// 1. 类继承
// 2. virtual、override、new

class TestClass
{
	public class Shape
	{
		public static string type = "shape";
		public const double PI = Math.PI;
		protected double _x, _y;

		public Shape() { }

		public Shape(double x, double y)
		{
			_x = x;
			_y = y;
		}

		public virtual double Area()
		{
			return _x * _y;
		}
	}


	public class Cycle: Shape
	{
		new public static string type = "cycle";
		public Cycle(double r): base(r, 0)
		{
		}

		public override double Area()
		{
			return PI * _x * _x;
		}
	}
}
