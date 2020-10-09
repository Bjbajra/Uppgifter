using System;
using System.Collections;
using System.Numerics;

namespace Shape_Library
{
    public class Triangle : Shape2D //IEnumerable
    {
        public override Vector3 Center { get; }
        public override float Area { get; }
        public override float Circumference { get; }
        private float P1X { get; }
        private float P1Y { get; }
        private float P2X { get; }
        private float P2Y { get; }
        private float P3X { get; }
        private float P3Y { get; }

        public Triangle(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            Center = new Vector3()
            {
                X = (p1.X + p2.X + p3.X) / 3f,
                Y = (p1.Y + p2.Y + p3.Y) / 3f,
                Z = 0.0f
            };

            P1X = p1.X;
            P1Y = p1.Y;

            P2X = p2.X;
            P2Y = p2.Y;

            P3X = p3.X;
            P3Y = p3.Y;

            Circumference = GetCircumference(p1, p2, p3);

            Area = MathF.Abs(1f / 2f * (p1.X * (p2.Y - p3.Y) + p2.X * (p3.Y - p1.Y) + p3.X * (p1.Y - p2.Y)));
        }

        public override string ToString()
        {
            return
                $"triangle @({Center.X:0.0}, {Center.Y:0.0}): p1({P1X:0.0}, {P1Y:0.0}), p2({P2X:0.0}, {P2Y:0.0}), p3({P3X:0.0}, {P3Y:0.0})";

        }

        public float GetCircumference(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            float side1 = MathF.Sqrt(MathF.Pow((p1.X - p2.X), 2) + MathF.Pow((p1.Y - p2.Y), 2));
            float side2 = MathF.Sqrt(MathF.Pow((p1.X - p3.X), 2) + MathF.Pow((p1.Y - p3.Y), 2));
            float side3 = MathF.Sqrt(MathF.Pow((p3.X - p2.X), 2) + MathF.Pow((p3.Y - p2.Y), 2));

            return side1 + side2 + side3;
        }

        //public IEnumerator GetEnumerator()
        //{
        //    return new TrianglePointEnumerator(this);

        //}

        //public class TrianglePointEnumerator : IEnumerator
        //{
        //    public Triangle[] pointsTriangles;
        //    int index = -1;
        //    public TrianglePointEnumerator(Vector2 P1, Vector2 P2, Vector2 P3)
        //    {
        //        pointsTriangles[0] = P1;
        //        pointsTriangles[1] = P2;
        //        pointsTriangles[3] = P3;
        //    }
        //    public object Current
        //    {
        //        get
        //        {
        //            return pointsTriangles;
        //        }
        //    }
        //    public bool MoveNext()
        //    {
        //        if (index > 2)
        //        {
        //            return false;
        //        }

        //        index++;
        //        return true;
        //    }
        //    public void Reset()
        //    {
        //    }
        //}
    }
}
