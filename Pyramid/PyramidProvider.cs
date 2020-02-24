namespace Pyramid
{
    public class PyramidProvider
    {
        public Point Base0 { get; set; }

        public Point Base1 { get; set; }

        public Point Base2 { get; set; }

        public Point Base3 { get; set; }

        public Point Top { get; set; }

        public PyramidProvider()
        {
        }

        public PyramidProvider(Pyramid pyramid)
        {
            Base0 = pyramid.Base0;
            Base1 = pyramid.Base1;
            Base2 = pyramid.Base2;
            Base3 = pyramid.Base3;
            Top = pyramid.Top;
        }

        public Pyramid GetPyramid()
        {
            return new Pyramid(new[] {Base0, Base1, Base2, Base3, Top});
        }
    }
}