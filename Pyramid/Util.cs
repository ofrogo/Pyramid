using System;

namespace Pyramid
{
    public class Util
    {
        public static double GetAngleBetweenVectors(Vector v1, Vector v2)
        {
            return Math.Acos(v1 * v2 / (v1.Length * v2.Length));
        }

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
    }
}