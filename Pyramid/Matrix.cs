using System;

namespace Pyramid
{
    public class Matrix
    {
        private double[,] matrix;

        public Matrix(double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3)
        {
            matrix = new double[,] {{x1, y1, z1}, {x2, y2, z2}, {x3, y3, z3}};
        }

        public Matrix(Point[] points)
        {
            if (points.Length != 3)
            {
                throw new Exception("Bad data for new matrix!");
            }

            matrix = new double[,]
            {
                {points[0].X, points[0].Y, points[0].Z}, {points[1].X, points[1].Y, points[1].Z},
                {points[2].X, points[2].Y, points[2].Z}
            };
        }

        public Matrix(double[,] matrix)
        {
            if (matrix.GetLength(0) != 3 || matrix.GetLength(1) != 3)
            {
                throw new Exception("Bad data for new matrix!");
            }

            this.matrix = matrix;
        }

        public double Determinant =>
            matrix[1, 1] * (matrix[2, 2] * matrix[3, 3] - matrix[2, 3] * matrix[3, 2]) -
            matrix[2, 1] * (matrix[1, 2] * matrix[3, 3] - matrix[1, 3] * matrix[3, 2]) +
            matrix[3, 1] * (matrix[1, 2] * matrix[2, 3] - matrix[2, 2] * matrix[1, 3]);
    }
}