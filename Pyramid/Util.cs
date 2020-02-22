using System;

namespace Pyramid
{
    public class Util
    {
        public static double GetAngleBetweenVectors(Vector v1, Vector v2)
        {
            return Math.Acos(v1 * v2 / (v1.Length * v2.Length));
        }
    }
}