using Cubes_IntersectionExercise.Domain;
using System;

namespace Cubes_IntersectionExercise.Application.Abstractions
{
    public interface IEdgesComparerService
    {
        public double GetOverlapedValueFromTwoEdges(Edge edgeA, Edge edgeB) =>  Math.Max(0, GetDifferenceBetweenTwoEdges(edgeA, edgeB));
        public double GetDifferenceBetweenTwoEdges(Edge edgeA, Edge edgeB) => Math.Min(edgeA.End, edgeB.End) - Math.Max(edgeA.Start, edgeB.Start);
        public bool AreEdgesColliding(Edge edgeA, Edge edgeB) => GetDifferenceBetweenTwoEdges(edgeA, edgeB) >= 0;
    }
}