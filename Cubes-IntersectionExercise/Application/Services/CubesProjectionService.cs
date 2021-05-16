using Cubes_IntersectionExercise.Application.Abstractions;
using Cubes_IntersectionExercise.Domain;
using System;

namespace Cubes_IntersectionExercise
{
    public class CubesProjectionService : ICubesProjectionService
    {
        private readonly IEdgesComparerService _edgesComparerService;

        public CubesProjectionService(IEdgesComparerService edgesComparerService)
        {
            _edgesComparerService = edgesComparerService ?? throw new ArgumentNullException(nameof(IEdgesComparerService));
        }

        public double GetIntersectionVolumeFromTwoCubes(Cube cubeA, Cube cubeB)
            => _edgesComparerService.GetOverlapedValueFromTwoEdges(cubeA.Width, cubeB.Width)
                * _edgesComparerService.GetOverlapedValueFromTwoEdges(cubeA.Height, cubeB.Height)
                * _edgesComparerService.GetOverlapedValueFromTwoEdges(cubeA.Depth, cubeB.Depth);

        public bool AreCubesColliding(Cube cubeA, Cube cubeB)
            => _edgesComparerService.AreEdgesColliding(cubeA.Width, cubeB.Width)
                || _edgesComparerService.AreEdgesColliding(cubeA.Height, cubeB.Height)
                || _edgesComparerService.AreEdgesColliding(cubeA.Depth, cubeB.Depth);
    }
}
