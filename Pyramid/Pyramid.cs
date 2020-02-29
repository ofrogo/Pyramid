using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Pyramid
{
    public class Pyramid
    {
        public Point Base0 { get; private set; }

        public Point Base1 { get; private set; }

        public Point Base2 { get; private set; }

        public Point Base3 { get; private set; }

        public Point Top { get; private set; }

        public Pyramid(Point[] points)
        {
            if (points.Length != 5)
            {
                throw new Exception("Wrong number of points. Need 5 points.");
            }

            if (Util.IsOneLine(points))
            {
                throw new Exception("All points can't lie on one line!");
            }

            Matrix matrix;
            for (var i = 0; i < 5; i++)
            {
                var p = points.Where((point, i1) => i1 != i).ToArray();
                matrix = new Matrix(new[] {p[0] - p[1], p[0] - p[2], p[0] - p[3]});

                if (Math.Abs(matrix.Determinant) < double.Epsilon)
                {
                    Base0 = p[0];
                    Base1 = p[1];
                    Base2 = p[2];
                    Base3 = p[3];
                    Top = points[i];
                }
            }

            matrix = new Matrix(new[] {Top - Base0, Top - Base1, Top - Base2});
            if (Math.Abs(matrix.Determinant) < double.Epsilon)
            {
                throw new Exception("The top can't lies on the same plane with the base!");
            }

            if (Util.IsOneLine(new[] {Base0, Base1, Base2, Base3}))
            {
                throw new Exception("Bases points can't lie on one line");
            }
        }

        // Divide the quadrangle into two triangles and calculate the areas using the Heron formula
        public double Square =>
            Math.Round(Util.GetTriangleSquare(Base0, Base1, Base2) + Util.GetTriangleSquare(Base1, Base2, Base3), 5,
                MidpointRounding.AwayFromZero);

        public double Volume
        {
            get
            {
                var a = (Base2.Y - Base1.Y) * (Base3.Z - Base1.Z) - (Base2.Z - Base1.Z) * (Base3.Y - Base1.Y);
                var b = (Base2.Z - Base1.Z) * (Base3.X - Base1.X) - (Base2.X - Base1.X) * (Base3.Z - Base1.Z);
                var c = (Base2.X - Base1.X) * (Base3.Y - Base1.Y) - (Base2.Y - Base1.Y) * (Base3.X - Base1.X);
                var d = -Base1.X * a - Base1.Y * b - Base1.Z * c;
                var h = Math.Abs(a * Top.X + b * Top.Y + c * Top.Z + d) / Math.Sqrt(a * a + b * b + c * c);
                return Square * h / 3;
            }
        }

        public override string ToString()
        {
            return
                $"Pyramid: base:[{Base0}, {Base1}, {Base2}, {Base3}], top:[{Top}], volume:[{Volume}], base square:[{Square}]";
        }
    }
}