using Cubes_IntersectionExercise.Domain;

namespace Cubes_IntersectionExercise.Application.Abstractions
{
    public interface ICubesProjectionService
    {
        double GetIntersectionVolumeFromTwoCubes(Cube cubeA, Cube cubeB);
        bool AreCubesColliding(Cube cubeA, Cube cubeB);
    }
}