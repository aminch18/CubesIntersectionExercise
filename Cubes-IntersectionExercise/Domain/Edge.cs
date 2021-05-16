namespace Cubes_IntersectionExercise.Domain
{
    public class Edge
    {
        public double Start { get; }
        public double End { get; }
        public double Length { get; }

        public Edge(double center, double length)
        {
            Start = center - length / 2.0;
            End = center + length / 2.0;
            Length = length;
        }
    }
}