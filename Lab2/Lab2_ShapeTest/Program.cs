using Shape_Library;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Lab2_ShapeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            float averageAreaAllShapes = 0;
            float totalOfTriangleCircumference = 0;
            float largestVolumeOf3DShapes = 0;

            List<Shape> shapes = new List<Shape>();

            for (int i = 0; i < 20; i++)
            {
                //Shape generateShape = Shape.GenerateShape();
                Shape vec3Shape = Shape.GenerateShape(new Vector3(2.0f, 3.5f, 2.5f));

                //shapes.Add(generateShape);
                shapes.Add(vec3Shape);
            }

            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"{shape} \n");
            }

            foreach (Shape shape in shapes)
            {
                if (shape is Triangle triangle)
                {
                    totalOfTriangleCircumference += triangle.Circumference;
                }

                if (shape is Shape3D shapeVolume)
                {
                    if (shapeVolume.Volume > largestVolumeOf3DShapes)
                    {
                        largestVolumeOf3DShapes = shapeVolume.Volume;
                    }
                }

                averageAreaAllShapes += shape.Area / shapes.Count;
            }

            Console.WriteLine($"Total of all triangle circumference = {Math.Round(totalOfTriangleCircumference, 2)}\n");
            Console.WriteLine($"Average area of all shapes = {Math.Round(averageAreaAllShapes, 2)}\n");
            Console.WriteLine($"Largest volume of 3D shape = {Math.Round(largestVolumeOf3DShapes, 2)}");

            //Triangle tra = new Triangle(Vector2.Zero, Vector2.One, new Vector2(2.0f, .5f));
            //foreach (Vector v in tra)
            //{
            //    Console.WriteLine(v);
            //}
        }
    }
}
