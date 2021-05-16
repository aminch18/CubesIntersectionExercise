using System;

namespace Cubes_IntersectionExercise.Domain
{
    public class Cube
    {
        const int NUMBER_OF_FACES = 6;
        public Edge Width { get; }
        public Edge Height { get; }
        public Edge Depth { get; }
        public double Area { get => GetArea(); }
        public double Volume { get => GetVolume(); }

        public Cube(Point center, double edgeLength)
        {
            Width = new Edge(center.X, edgeLength);
            Height = new Edge(center.Y, edgeLength);
            Depth = new Edge(center.Z, edgeLength);
        }

        private double GetArea() => Math.Pow(Width.Length, 2) * NUMBER_OF_FACES;
        private double GetVolume() => Width.Length * Height.Length * Depth.Length;
    }
}
