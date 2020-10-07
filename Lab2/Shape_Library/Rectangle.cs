using System.Numerics;

namespace Shape_Library
{
    public class Rectangle : Shape2D
    {
        public override Vector3 Center { get; }
        public float Width { get; }
        public float Height { get; }
        public bool IsSquare
        {
            get
            {
                if (Height == Width)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public Rectangle(Vector2 center, Vector2 size)
        {
            Center = new Vector3()
            {
                X = center.X,
                Y = center.Y
            };
            Height = size.X;
            Width = size.Y;
        }

        public Rectangle(Vector2 center, float width)
        {

            Center = new Vector3()
            {
                X = center.X,
                Y = center.Y
            };

            Height = width;
            Width = width;
        }

        public override float Circumference => 2 * (Height + Width);
        public override float Area => Height * Width;

        public override string ToString()
        {
            if (IsSquare)
            {
                return $"rectangle @({Center.X:0.0}, {Center.Y:0.0}): square";
            }

            return $"rectangle @({Center.X:0.0}, {Center.Y:0.0}):w = {Width:0.0}, h = {Height:0.0}";
        }
    }
}
