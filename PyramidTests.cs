using System.IO;
using FluentAssertions;
using Xunit;

namespace MDPyramid
{
    public class PyramidTests
    {
        [Fact]
        public void Should_Find_Leftmost_Path()
        {
            var input = new[]
            {
                "1",
                "8 9",
                "11 5 9",
                "4 5 2 3"
            };
            var pyramid = new Pyramid(input);

            var result = pyramid.FindPath();

            result.Nodes.Should().BeEquivalentTo(new[] { 1, 8, 11, 4 });
        }

        [Fact]
        public void Should_Find_Rightmost_Path()
        {
            var input = new[]
            {
                "1",
                "8 10",
                "9 5 11",
                "14 5 2 12"
            };
            var pyramid = new Pyramid(input);

            var result = pyramid.FindPath();

            result.Nodes.Should().BeEquivalentTo(new[] { 1, 10, 11, 12 });
        }

        [Fact]
        public void Should_Find_Path_With_Negative_Values()
        {
            var input = new[]
            {
                "-1",
                "-8 9",
                "5 -9 9",
                "1 -10 11 3",
                "1 21 19 3 5"
            };
            var pyramid = new Pyramid(input);

            var result = pyramid.FindPath();

            result.Nodes.Should().BeEquivalentTo(new[] { -1, -8, 5, -10, 21 });
        }

        [Fact]
        public void Should_Find_Path_When_Root_Node_Has_Multiple_Values()
        {
            var input = new[]
            {
                "51 4 21",
                "1 10 11 3",
                "1 21 19 3 5"
            };
            var pyramid = new Pyramid(input);

            var result = pyramid.FindPath();

            result.Nodes.Should().BeEquivalentTo(new[] { 51, 10, 21 });
        }

        [Fact]
        public void Should_Find_Path_With_Single_Parent_Node()
        {
            var input = new[]
            {
                "1 4 21"
            };
            var pyramid = new Pyramid(input);

            var result = pyramid.FindPath();

            result.Nodes.Should().BeEquivalentTo(new[] { 1 });
        }

        [Fact]
        public void Should_Find_Path_When_Comparing_Even_Numbers()
        {
            var input = new[]
            {
                "1",
                "8 10",
                "9 5 3",
                "14 10 2 12"
            };
            var pyramid = new Pyramid(input);

            var result = pyramid.FindPath();

            result.Nodes.Should().BeEquivalentTo(new[] { 1, 8, 9, 14 });
        }

        [Fact]
        public void Should_Find_Path_When_Comparing_Odd_Numbers()
        {
            var input = new[]
            {
                "1",
                "8 10",
                "9 5 3",
                "14 10 2 12",
                "1 7 3 4 5"
            };
            var pyramid = new Pyramid(input);

            var result = pyramid.FindPath();

            result.Nodes.Should().BeEquivalentTo(new[] { 1, 8, 9, 14, 7 });
        }

        [Fact]
        public void Should_Find_Path_When_Comparing_Odd_And_Even_Numbers()
        {
            var input = new[]
            {
                "1",
                "8 10",
                "9 5 3",
                "14 11 2 12",
                "1 6 3 4 5"
            };
            var pyramid = new Pyramid(input);

            var result = pyramid.FindPath();

            result.Nodes.Should().BeEquivalentTo(new[] { 1, 8, 9, 14, 1 });
        }

        [Fact]
        public void Should_Find_Path_For_SampleData1()
        {
            var r = new Pyramid(File.ReadAllLines(@".\sampleData1.txt")).FindPath();
            r.Sum.Should().Be(16);
        }

        [Fact]
        public void Should_Find_Path_For_SampleData2()
        {
            var r = new Pyramid(File.ReadAllLines(@".\sampleData2.txt")).FindPath();
            r.Sum.Should().Be(8186);
        }

        [Fact]
        public void Should_Find_Path_For_SampleData3()
        {
            var r = new Pyramid(File.ReadAllLines(@".\sampleData3.txt")).FindPath();
            r.Sum.Should().Be(26);
        }

        [Fact]
        public void Main_Should_Not_Throw()
        {
            Program.Main();
        }
    }
}
