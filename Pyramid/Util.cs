using System;
using System.Collections.Generic;

namespace Pyramid
{
    public static class Util
    {
        public static double GetDistanceBetweenTwoPoints(Point p1, Point p2)
        {
            return Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) +
                             (p2.Y - p1.Y) * (p2.Y - p1.Y) +
                             (p2.Z - p1.Z) * (p2.Z - p1.Z));
        }

        public static double GetTriangleSquare(Point p1, Point p2, Point p3)
        {
            var d1 = GetDistanceBetweenTwoPoints(p1, p2);
            var d2 = GetDistanceBetweenTwoPoints(p2, p3);
            var d3 = GetDistanceBetweenTwoPoints(p3, p1);

            var p = (d1 + d2 + d3) / 2;

            return Math.Sqrt(p * (p - d1) * (p - d2) * (p - d3));
        }

        public static bool IsOneLine(Point[] points)
        {
            if (points.Length < 2)
                throw new ArgumentException("Value cannot be array with length < 2.", nameof(points));
            if (points.Length == 2) return true;
            var radVectors = new List<Point>();
            for (var i = 1; i < points.Length; i++)
            {
                radVectors.Add(new Vector(points[0], points[i]).Coordinates);
            }

            for (var i = 0; i < radVectors.Count - 1; i++)
            {
                for (var j = i + 1; j < radVectors.Count; j++)
                {
                    if (Math.Abs(radVectors[i].X / radVectors[j].X - radVectors[i].Y / radVectors[j].Y) >
                        double.Epsilon ||
                        Math.Abs(radVectors[i].X / radVectors[j].X - radVectors[i].Z / radVectors[j].Z) >
                        double.Epsilon)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}