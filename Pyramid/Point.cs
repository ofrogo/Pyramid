namespace Pyramid
{
    public class Point
    {
        public double X { get; }

        public double Y { get; }

        public double Z { get; }

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point(b.X - a.X, b.Y - a.Y, b.Z - a.Z);
        }
    }
}