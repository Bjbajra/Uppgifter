using System;
using System.Numerics;

namespace Shape_Library
{
    public class Circle : Shape2D
    {
        private float Radius { get; set; }
        public override Vector3 Center { get; }

        public Circle(Vector2 center, float radius)
        {
            //use only x and y points
            Center = new Vector3()
            {
                X = center.X,
                Y = center.Y
            };

            Radius = radius;

        }
        public override float Circumference => 2 * MathF.PI * Radius;

        public override float Area => MathF.Pow(Radius, 2) * MathF.PI;

        public override string ToString()
        {
            return $"circle @({Center.X:0.0}, {Center.Y:0.0}):r = {Radius:0.0}";
        }
    }
}
