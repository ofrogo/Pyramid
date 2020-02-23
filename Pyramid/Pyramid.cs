using System;
using System.Linq;

namespace Pyramid
{
    public class Pyramid
    {
        private Point _base0, _base1, _base2, _base3, _top;

        public Pyramid(Point[] points)
        {
            if (points.Length != 5)
            {
                throw new Exception("Ti sho, dibil voobsche, matematicheskoe ubogzestvo");
            }
            
            Init(points);
            
            var matrix = new Matrix(new []{_top - _base0, _top - _base1, _top - _base2});
            if (Math.Abs(matrix.Determinant) < double.Epsilon)
            {
                throw new Exception("The top lies on the same plane with the base");
            }
        }

        // Divide the quadrangle into two triangles and calculate the areas using the Heron formula
        public double Square => Util.GetTriangleSquare(_base0, _base1, _base2) + Util.GetTriangleSquare(_base1, _base2, _base3);
        
        public double Volume
        {
            get
            {
                var a = (_base2.Y - _base1.Y) * (_base3.Z - _base1.Z) - (_base2.Z - _base1.Z) * (_base3.Y - _base1.Y);
                var b = (_base2.Z - _base1.Z) * (_base3.X - _base1.X) - (_base2.X - _base1.X) * (_base3.Z - _base1.Z);
                var c = (_base2.X - _base1.X) * (_base3.Y - _base1.Y) - (_base2.Y - _base1.Y) * (_base3.X - _base1.X);
                var d = -_base1.X * a - _base1.Y * b - _base1.Z * c;
                var h = Math.Abs(a * _top.X + b * _top.Y + c * _top.Z + d) / Math.Sqrt(a * a + b * b + c * c);
                return Square * h / 3;
            }
        }

        private void Init(Point[] points)
        {
            for (var i = 0; i < 5; i++)
            {
                var p = points.Where((point, i1) => i1 != i).ToArray();
                var matrix = new Matrix(new[] {p[0] - p[1], p[0] - p[2], p[0] - p[3]});
                
                if (Math.Abs(matrix.Determinant) < double.Epsilon)
                {
                    _base0 = p[0];
                    _base1 = p[1];
                    _base2 = p[2];
                    _base3 = p[3];
                    _top = points[i];
                }
            }
        }
    }
}