using System;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace Shape_Library
{
    public abstract class Shape
    {
        public abstract Vector3 Center { get; }
        public abstract float Area { get; }
        private static Random rnd = new Random();

        private static float rndValue()
        {
            Random random = new Random();
            return (float)random.NextDouble() * 10;
        }

        public static Shape GenerateShape()
        {
            //int randomShape = rnd.Next(0,6);
            

            switch (rnd.Next(0,7))
            {
                case 0:
                    return new Circle(new Vector2(rndValue(), rndValue()), rndValue());
                    break;
                case 1:
                    return new Rectangle(new Vector2(rndValue(), rndValue()),new Vector2(rndValue(), rndValue()) );

                case 2:
                    return new Rectangle(new Vector2(rndValue(), rndValue()), rndValue());
                    break;

                case 3:
                    return new Triangle(new Vector2(rndValue(), rndValue()), new Vector2(rndValue(), rndValue()), new Vector2(rndValue(), rndValue()));
                    break;

                case 4:
                    return new Sphere(new Vector3(rndValue(), rndValue(),rndValue()), rndValue());
                    break;

                case 5:
                    return new Cuboid(new Vector3(rndValue(), rndValue(), rndValue()),new Vector3(rndValue(), rndValue(), rndValue()));
                    break;
                case 6:
                    return new Cuboid(new Vector3(rndValue(), rndValue(), rndValue()), rndValue());
                    break;
            }

            return null;
        }

        public static Shape GenerateShape(Vector3 center)
        {
            switch (rnd.Next(0,7))
            {
                case 0:
                    return new Circle(new Vector2(center.X, center.Y), rndValue());
                    break;
                case 1:
                    return new Rectangle(new Vector2(center.X, center.Y), new Vector2(rndValue(), rndValue()));

                case 2:
                    return new Rectangle(new Vector2(center.X, center.Y), rndValue());
                    break;

                case 3:
                    return new Triangle(new Vector2(center.X, center.Y),new Vector2(rndValue(), rndValue()),new Vector2(rndValue(), rndValue()));
                    break;

                case 4:
                    return new Sphere(new Vector3(center.X, center.Y, center.Z), rndValue());
                    break;

                case 5:
                    return new Cuboid(new Vector3(center.X, center.Y, center.Z), new Vector3(rndValue(), rndValue(), rndValue()));
                    break;
                case 6:
                    return new Cuboid(new Vector3(center.X, center.Y, center.Z),rndValue() );
                    break;
            }

            return null;
        }
    }
}
