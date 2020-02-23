using System;

namespace Pyramid
{
    public class Matrix
    {
        private readonly double[,] _matrix;

        public Matrix(double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3)
        {
            _matrix = new[,]
            {
                {x1, y1, z1},
                {x2, y2, z2},
                {x3, y3, z3}
            };
        }

        public Matrix(Point[] points)
        {
            if (points.Length != 3)
            {
                throw new Exception("Bad data for new matrix!");
            }

            _matrix = new[,]
            {
                {points[0].X, points[0].Y, points[0].Z},
                {points[1].X, points[1].Y, points[1].Z},
                {points[2].X, points[2].Y, points[2].Z}
            };
        }

        public Matrix(double[,] matrix)
        {
            if (matrix.GetLength(0) != 3 || matrix.GetLength(1) != 3)
            {
                throw new Exception("Bad data for new matrix!");
            }

            _matrix = matrix;
        }

        public double Determinant =>
            _matrix[0, 0] * (_matrix[1, 1] * _matrix[2, 2] - _matrix[1, 2] * _matrix[2, 1]) -
            _matrix[1, 0] * (_matrix[0, 1] * _matrix[2, 2] - _matrix[0, 2] * _matrix[2, 1]) +
            _matrix[2, 0] * (_matrix[0, 1] * _matrix[1, 2] - _matrix[1, 1] * _matrix[0, 2]);
    }
}