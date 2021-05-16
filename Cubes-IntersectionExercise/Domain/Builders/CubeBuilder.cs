namespace Cubes_IntersectionExercise.Domain.Builders
{
    public class CubeBuilder
    {
        private Point _center;
        private double _edgeLength;
        public static CubeBuilder Create() => new CubeBuilder();

        public CubeBuilder CenteredAt(double x, double y, double z)
        {
            _center = new Point { X = x, Y = y, Z = z };
            return this;
        }

        public CubeBuilder WithEdgeLength(double edgeLength)
        {
            _edgeLength = edgeLength;
            return this;
        }

        public Cube Build() => new Cube(_center, _edgeLength);
    }
}
