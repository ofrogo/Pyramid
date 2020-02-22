using System;

namespace Pyramid
{
    public class Vector
    {
        private Point A, B;

        public Vector(Point a, Point b)
        {
            A = a;
            B = b;
        }

        public Point Coordinates => B - A;

        public double Length => Math.Sqrt(A.X * B.X + A.Y * B.Y + A.Z * B.Z);
        
        public static double operator *(Vector v1, Vector v2)
        {
            var v1Coord = v1.Coordinates;
            var v2Coord = v2.Coordinates;
            return v1Coord.X * v2Coord.X + v1Coord.Y * v2Coord.Y + v1Coord.Z * v2Coord.Z;
        }
        
        
    }
}