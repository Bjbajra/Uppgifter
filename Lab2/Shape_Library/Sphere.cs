using System;
using System.Numerics;

namespace Shape_Library
{
    public class Sphere : Shape3D
    {
        private float Radius { get; }
        public override Vector3 Center { get; }
        public Sphere(Vector3 center, float radius)
        {
            Center = new Vector3()
            {
                X = center.X,
                Y = center.Y,
                Z = center.Z
            };
            Radius = radius;
        }

        public override float Volume => 4f / 3f * MathF.PI * MathF.Pow(Radius, 3f);
        public override float Area => 4f * MathF.PI * MathF.Pow(Radius, 2f);
        public override string ToString()
        {
            return $"sphere @({Center.X:0.0}, {Center.Y:0.0}, {Center.Z:0.0}) : r = {Radius:0.0}";
        }

    }
}
