using System;

namespace Pyramid
{
    public class Vector
    {
        private readonly Point _a;
        private readonly Point _b;

        public Vector(Point a, Point b)
        {
            _a = a;
            _b = b;
        }

        public Point Coordinates => _b - _a;

        public double Length => Util.GetDistanceBetweenTwoPoints(_b, _a);

        public static double operator *(Vector v1, Vector v2)
        {
            var v1Coords = v1.Coordinates;
            var v2Coords = v2.Coordinates;
            return Math.Sqrt(v1Coords.X * v2Coords.X + v1Coords.Y * v2Coords.Y + v1Coords.Z * v2Coords.Z);
        }
        
        public static double GetAngleBetweenVectors(Vector v1, Vector v2)
        {
            return Math.Acos(v1 * v2 / (v1.Length * v2.Length));
        }
    }
}