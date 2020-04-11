using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuadraticEquation;
using Xunit;

namespace QuadraticEquation.Tests
{
    public class EqulationTests
    {
        [Theory]
        [InlineData(3, 5, 2, new double[2] { -0.67, -1 })]
        [InlineData(4, -10, 4, new double[2] { 2, 0.5 })]
        [InlineData(1, -6, 5, new double[2] { 5, 1 })]
        [InlineData(10, 0, -10, new double[2] { 1, -1 })]
        public void Solve_DiscriminantMoreZero(double a, double b, double c, double[] expected)
        {
            // Arrange
            Equation eq = new Equation(a, b, c);

            // Act
            double[] actual = eq.Solve();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Solve_DiscriminantLessZero()
        {
            Equation eq = new Equation(1, 1, 1);
            double[] expected = null;

            double[] actual = eq.Solve();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Solve_DiscriminantEqualZero()
        {
            Equation eq = new Equation(1, 2, 1);
            double[] expected = { -1 };

            double[] actual = eq.Solve();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Solve_NotQuadraticEcuation()
        {
            Equation eq = new Equation(0, 10, -10); // 10x-10=0, expected: 1
            double[] expected = { 1 };

            double[] actual = eq.Solve();

            Assert.Equal(expected, actual);
        }
    }
}
