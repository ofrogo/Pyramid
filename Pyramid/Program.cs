﻿using System;
using System.Text.Json;

namespace Pyramid
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var p = new Pyramid(new []{new Point(0,0,0), new Point(0,1,0), new Point(1, 1,0), new Point(1,0,0), new Point(1,1,1), });
            var serialize = JsonSerializer.Serialize(p);
            Console.WriteLine(serialize);
        }
    }
}