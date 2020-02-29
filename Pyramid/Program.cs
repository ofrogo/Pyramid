using System;

namespace Pyramid
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var p = new Pyramid(new[]
                {new Point(0, 0, 0), new Point(0, 1, 0), new Point(1, 1, 0), new Point(1, 0, 0), new Point(1, 1, 1),});
            new PyramidProvider(p).SaveToFile("test.json");
            var d = PyramidProvider.LoadFromFile("test.json");
            Console.WriteLine(d.ToString());
        }
    }
}