using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using MDPyramid;
using Xunit;

namespace TreeTests
{
    public class PyramidTests
    {
        const char separator = ' ';
        //        Tree tree = new Tree();

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
            var tree = new Pyramid(input);

            var actual = new List<int> { 1, 8, 11, 4 };
            var result = tree.MySolve();

            result.Nodes.Should().BeEquivalentTo(actual);
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

            var tree = new Pyramid(input);
            var actual = new List<int> { 1, 10, 11, 12 };
            var result = tree.MySolve();

            result.Nodes.Should().BeEquivalentTo(actual);
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
            var tree = new Pyramid(input);

            var actual = new List<int> { -1, -8, 5, -10, 21 };
            var result = tree.MySolve();

            result.Nodes.Should().BeEquivalentTo(actual);
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
            var tree = new Pyramid(input);

            var actual = new List<int> { 51, 10, 21 };

            
            var result = tree.MySolve();

            result.Nodes.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public void Should_Find_Path_With_Single_Parent_Node()
        {
            var input = new[]
            {
                "1 4 21"
            };
            var tree = new Pyramid(input);

            var actual = new List<int> { 1 };


            var result = tree.MySolve();

            result.Nodes.Should().BeEquivalentTo(actual);
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
            var tree = new Pyramid(input);

            var actual = new List<int> { 1, 8, 9, 14 };


            var result = tree.MySolve();

            result.Nodes.Should().BeEquivalentTo(actual);

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
            var tree = new Pyramid(input);

            var actual = new List<int> { 1, 8, 9, 14, 7 };


            var result = tree.MySolve();

            result.Nodes.Should().BeEquivalentTo(actual);

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
            var tree = new Pyramid(input);

            var actual = new List<int> { 1, 8, 9, 14, 1 };


            var result = tree.MySolve();

            result.Nodes.Should().BeEquivalentTo(actual);

        }
        [Fact]
        public void Shou2ld222_Find_Path_When_Comparing_Odd_And_Even_Numbers()
        {
            var r = new Pyramid(File.ReadAllLines(@".\sampleData2.txt")).MySolve();
            r.Sum.Should().Be(8186);
        }
        [Fact]
        public void Shou2ld333333_Find_Path_When_Comparing_Odd_And_Even_Numbers()
        {
            var r = new Pyramid(File.ReadAllLines(@".\sampleData.txt")).MySolve();
            r.Sum.Should().Be(16);
        }
        [Fact]
        public void Shou2ld33333_Find_Path_When_Comparing_Odd_And_Even_Numbers()
        {
            var r = new Pyramid(File.ReadAllLines(@".\sampleData3.txt")).MySolve();
            r.Sum.Should().Be(26);
        }
        [Fact]
        public void SSSS()
        {
            Program.Main(null);
        }
    }
}
