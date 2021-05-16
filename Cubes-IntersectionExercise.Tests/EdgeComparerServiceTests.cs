using Cubes_IntersectionExercise.Application.Abstractions;
using Cubes_IntersectionExercise.Domain.Builders;
using FluentAssertions;
using Xunit;

namespace Cubes_IntersectionExercise
{
    public class EdgeComparerServiceTests
    {
        private readonly IEdgesComparerService _service;
        public EdgeComparerServiceTests()
        {
            _service = new EdgesComparerService();
        }

        [Fact]
        public void Given_Two_Cubes_With_Same_Length_And_Any_Equal_Property_Should_Not_Collide()
        {
            var cubeA = CubeBuilder.Create()
                                    .CenteredAt(2, 2, 2)
                                    .WithEdgeLength(1)
                                    .Build();

            var cubeB = CubeBuilder.Create()
                                   .CenteredAt(10, 10, 10)
                                   .WithEdgeLength(1)
                                   .Build();

            _service.AreEdgesColliding(cubeA.Width, cubeB.Width).Should().BeFalse();
            _service.AreEdgesColliding(cubeA.Height, cubeB.Height).Should().BeFalse();
            _service.AreEdgesColliding(cubeA.Depth, cubeB.Depth).Should().BeFalse();
        }

        [Fact]
        public void Given_Two_Cubes_Overlapped_With_Similar_Edge_Side_Should_Collide()
        {
            var cubeA = CubeBuilder.Create().CenteredAt(2, 2, 2).WithEdgeLength(2).Build();
            var cubeB = CubeBuilder.Create().CenteredAt(3, 2, 2).WithEdgeLength(2).Build();

            _service.AreEdgesColliding(cubeA.Width, cubeB.Width).Should().BeTrue();
            _service.AreEdgesColliding(cubeA.Height, cubeB.Height).Should().BeTrue();
            _service.AreEdgesColliding(cubeA.Height, cubeB.Depth).Should().BeTrue();
        }

        [Fact]
        public void Given_Two_Cubes_Touched_Height_And_Depth_Should_Collide()
        {
            var cubeA = CubeBuilder.Create()
                           .CenteredAt(2, 2, 2)
                           .WithEdgeLength(1)
                           .Build();

            var cubeB = CubeBuilder.Create()
                                   .CenteredAt(4, 2, 2)
                                   .WithEdgeLength(1)
                                   .Build();

            _service.AreEdgesColliding(cubeA.Width, cubeB.Width).Should().BeFalse();
            _service.AreEdgesColliding(cubeA.Height, cubeB.Height).Should().BeTrue();
            _service.AreEdgesColliding(cubeA.Depth, cubeB.Depth).Should().BeTrue();
        }
    }
}
