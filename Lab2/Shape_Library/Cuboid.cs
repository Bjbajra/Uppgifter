using System;
using System.Numerics;

namespace Shape_Library
{
    public class Cuboid : Shape3D
    {
        public override Vector3 Center { get; }

        private float Width { get; }
        private float Length { get; }
        private float Height { get; }

        public bool IsCube
        {
            get
            {
                if (Height == Length && Length == Width && Height == Width)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public Cuboid(Vector3 center, Vector3 size)
        {
            Center = new Vector3()
            {
                X = center.X,
                Y = center.Y,
                Z = center.Z
            };
            Width = size.X;
            Length = size.Y;
            Height = size.Z;


        }

        public Cuboid(Vector3 center, float width)
        {
            Center = new Vector3()
            {
                X = center.X,
                Y = center.Y,
                Z = center.Z
            };
            Width = width;
            Length = width;
            Height = width;

        }

        public override float Volume => Width * Length * Height;
        public override float Area => 2 * ((Length * Width) + (Width * Height) + (Length * Height));
       

        public override string ToString()
        {
            if (IsCube)
            {
                return $"Cuboid @({Center.X:0.0}, {Center.Y:0.0}, {Center.Z:0.0}): cube";
            }
            return $"Cuboid @({Center.X:0.0}, {Center.Y:0.0}, {Center.Z:0.0}) : w = {Width:F2}, h = {Height:F2}, l = {Length:F2} ";
        }
    }
}
