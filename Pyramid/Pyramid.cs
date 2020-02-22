using System;
using System.Linq;

namespace Pyramid
{
    public class Pyramid
    {
        private Point osn0, osn1, osn2, osn3, v;

        public Pyramid(Point[] points)
        {
            if (points.Length != 5)
            {
                throw new Exception("Ti sho, dibil voobsche, matematicheskoe ubogzestvo");
            }

            Matrix matrix;
            Point[] p;
            for (var i = 0; i < 5; i++)
            {
                p = points.Where((point, i1) => i1 != i).ToArray();
                matrix = new Matrix(new[] {p[0] - p[1], p[0] - p[2], p[0] - p[3]});
                if (Math.Abs(matrix.Determinant) > double.Epsilon) continue;
                osn0 = p[0];
                osn1 = p[1];
                osn2 = p[2];
                osn3 = p[3];
                v = points[i];
                break;
            }
        }

        double Square
        {
            get
            {
                var v1 = new Vector(osn0, osn1);
                var v2 = new Vector(osn0, osn2);
                return v1.Length * v2.Length * Util.GetAngleBetweenVectors(v1, v2) / 2;
            }
        }

        double Volume
        {
            get
            {
                var A = (osn2.Y - osn1.Y) * (osn3.Z - osn1.Z) - (osn2.Z - osn1.Z) * (osn3.Y - osn1.Y);
                var B = (osn2.Z - osn1.Z) * (osn3.X - osn1.X) - (osn2.X - osn1.X) * (osn3.Z - osn1.Z);
                var C = (osn2.X - osn1.X) * (osn3.Y - osn1.Y) - (osn2.Y - osn1.Y) * (osn3.X - osn1.X);
                var D = -osn1.X * A - osn1.Y * B - osn1.Z * C;
                var h = Math.Abs(A * v.X + B * v.Y + C * v.Z + D) / Math.Sqrt(A * A + B * B + C * C);
                return Square * h / 3;
            }
        }
    }
}