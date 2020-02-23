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

        public double Length => Math.Sqrt(Coordinates.X * Coordinates.X + 
                                          Coordinates.Y * Coordinates.Y + 
                                          Coordinates.Z * Coordinates.Z);
        
        public static double operator *(Vector v1, Vector v2)
        {
            var v1Coords = v1.Coordinates;
            var v2Coords = v2.Coordinates;
            return Math.Sqrt(v1Coords.X * v2Coords.X + v1Coords.Y * v2Coords.Y + v1Coords.Z * v2Coords.Z);
        }
        
        
    }
}