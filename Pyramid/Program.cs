using System;
using System.Text.Json;

namespace Pyramid
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var p = new Pyramid(new []{new Point(0,0,0), new Point(0,1,0), new Point(1, 1,0), new Point(1,0,0), new Point(1,1,1), });
            p.SaveToFile("test.json");
            var d = Pyramid.LoadFromFile("test.json");
            Console.WriteLine(d);
        }
    }
}