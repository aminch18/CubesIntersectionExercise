
using Cubes_IntersectionExercise.Domain.Builders;
using FluentAssertions;
using Xunit;

namespace Cubes_IntersectionExercise
{
    public class CubesProjectionServiceTests
    {
        private readonly CubesProjectionService _service;
        public CubesProjectionServiceTests()
        {
            _service = new CubesProjectionService(new EdgesComparerService());
        }

        [Fact]
        public void Given_Cubes_That_Don_Not_Intersect_IntersectionVolume_Should_Be_Zero()
        {
            var cubeA = CubeBuilder.Create()
                                    .CenteredAt(0, 0, 0)
                                    .WithEdgeLength(1)
                                    .Build();

            var cubeB = CubeBuilder.Create()
                                   .CenteredAt(10, 10, 10)
                                   .WithEdgeLength(1)
                                   .Build();

            _service.GetIntersectionVolumeFromTwoCubes(cubeA, cubeB).Should().Be(0);
        }

        [Fact]
        public void Given_Two_Cubes_With_Same_Height_And_Depth__IntersectionVolume_Should_Be_Four()
        {
            var cubeA = CubeBuilder.Create()
                                   .CenteredAt(1, 1, 1)
                                   .WithEdgeLength(2)
                                   .Build();

            var cubeB = CubeBuilder.Create()
                                   .CenteredAt(2, 1, 1)
                                   .WithEdgeLength(2)
                                   .Build();

           _service.AreCubesColliding(cubeA, cubeB).Should().BeTrue();
           _service.GetIntersectionVolumeFromTwoCubes(cubeA, cubeB).Should().Be(4);
        }

        [Fact]
        public void Given_Two_Cubes_With_Same_Width_And_Depth__IntersectionVolume_Should_Be_Four()
        {
            double expected = 4;
            var cubeA = CubeBuilder.Create()
                                   .CenteredAt(2, 2, 2)
                                   .WithEdgeLength(2)
                                   .Build();

            var cubeB = CubeBuilder.Create()
                                   .CenteredAt(2, 3, 2)
                                   .WithEdgeLength(2)
                                   .Build();

           _service.AreCubesColliding(cubeA, cubeB).Should().BeTrue();
           _service.GetIntersectionVolumeFromTwoCubes(cubeA, cubeB).Should().Be(expected);
        }

        [Fact]
        public void Given_Two_Cubes_With_Same_Width_And_Heigth__IntersectionVolume_Should_Be_Four()
        {
            double expected = 4;
            var cubeA = CubeBuilder.Create()
                                   .CenteredAt(2, 2, 2)
                                   .WithEdgeLength(2)
                                   .Build();

            var cubeB = CubeBuilder.Create()
                                   .CenteredAt(2, 2, 3)
                                   .WithEdgeLength(2)
                                   .Build();

           _service.AreCubesColliding(cubeA, cubeB).Should().BeTrue();
           _service.GetIntersectionVolumeFromTwoCubes(cubeA, cubeB).Should().Be(expected);
        }

        [Fact]
        public void Given_One_CubeA_Contained_Inside_One_CubeB_IntersectionVolume_Should_Be_One()
        {
            var expected = 1;
            var cubeA = CubeBuilder.Create()
                .CenteredAt(2, 2, 2)
                .WithEdgeLength(2)
                .Build();
            var cubeB = CubeBuilder.Create()
                .CenteredAt(2, 2, 2)
                .WithEdgeLength(1)
                .Build();

           _service.AreCubesColliding(cubeA, cubeB).Should().BeTrue();
           _service.GetIntersectionVolumeFromTwoCubes(cubeA, cubeB).Should().Be(expected);
        }

        [Fact]
        public void Given_Two_Cubes_Totally_Overrlaped_IntersectionVolume_Should_Be_Equal_To_Them_Proper_Volume()
        {
            var cubeA = CubeBuilder.Create()
                                   .CenteredAt(2, 2, 2)
                                   .WithEdgeLength(2)
                                   .Build();

            var cubeB = CubeBuilder.Create()
                                   .CenteredAt(2, 2, 2)
                                   .WithEdgeLength(2)
                                   .Build();

           _service.AreCubesColliding(cubeA, cubeB).Should().BeTrue();
           _service.GetIntersectionVolumeFromTwoCubes(cubeA, cubeB).Should().Be(cubeA.Volume);
           _service.GetIntersectionVolumeFromTwoCubes(cubeA, cubeB).Should().Be(cubeB.Volume);
        }

        [Fact]
        public void Given_Two_Cubes_That_Are_Touching_IntersectionVolume_Should_Be_Zero()
        {
            var cubeA = CubeBuilder.Create()
                                   .CenteredAt(2, 2, 2)
                                   .WithEdgeLength(2)
                                   .Build();

            var cubeB = CubeBuilder.Create()
                                   .CenteredAt(4, 2, 2)
                                   .WithEdgeLength(2)
                                   .Build();

           _service.AreCubesColliding(cubeA, cubeB).Should().BeTrue();
           _service.GetIntersectionVolumeFromTwoCubes(cubeA, cubeB).Should().Be(0);
        }

        [Fact]
        public void Given_TwoRandom_Cubes_GetIntersectionVolumeFromTwoCubesMethod_ShoulBe_Commutative_Operation()
        {
            var cubeA = CubeBuilder.Create().CenteredAt(0, 0, 0).WithEdgeLength(3).Build();
            var cubeB = CubeBuilder.Create().CenteredAt(2, 2, 2).WithEdgeLength(2).Build();

            _service.AreCubesColliding(cubeA, cubeB).Should().BeTrue();
            _service.GetIntersectionVolumeFromTwoCubes(cubeA, cubeB).Should().Be(_service.GetIntersectionVolumeFromTwoCubes(cubeB, cubeA));
        }
    }
}
