using PestScanCalculatorConsoleApp.Model;

namespace PestScanCalculatorTestApp
{
    // Read more about NUnit https://docs.nunit.org/articles/nunit/intro.html
    // How to use Assert.That() https://dotnetpattern.com/nunit-assert-examples
    public class CalculatorTests
    {
        [SetUp]
        public void Setup()
        {
            // Setup tests: before running each one
        }

        [Test]
        public void Constructor_ValueIsTwo_Two()
        {
            Calculator calculator = new(2);

            Assert.That(calculator.Result, Is.EqualTo(2));
        }

        [Test]
        public void Constructor_DefaultValue_IsZero()
        {
            Calculator calculator = new();

            Assert.That(calculator.Result, Is.Zero);
        }

        [Test]
        public void Calculator_RunningAnyOperation_ShouldBeCalculatorInstance()
        {
            Calculator calculator = new();

            var newCalculator = calculator.AddTo(5).SubtractTo(2).MultiplTo(1).DivTo(1);

            Assert.That(newCalculator, Is.InstanceOf(typeof(Calculator)));
        }

        [Test]
        public void Calculator_RunningAnyOperation_ShouldNotBeSameAsCurrentInstance()
        {
            Calculator calculator = new();

            var newCalculator = calculator.AddTo(5).SubtractTo(2).MultiplTo(1).DivTo(1);

            Assert.That(newCalculator, Is.Not.SameAs(calculator));
        }

        [Test] // Abbos
        public void AddTo_FiveToFive_Ten()
        {
            Calculator calculator = new(5);

            var _calculator = calculator.AddTo(5);

            Assert.That(_calculator.Result, Is.EqualTo(10));
        }

        [TestCase(0, 4, -4)]
        [TestCase(10, 5, 5)]
        [TestCase(5, 5, 0)]
        public void SubstractTo_TestWithCases_ExpectedResult(double x, double y, double result)
        {
            Calculator calculator = new(x);

            var _calculator = calculator.SubtractTo(y);

            Assert.That(_calculator.Result, Is.EqualTo(result), $"{x} - {y} = {result}");
        }


        [TestCase(2, 2, 4)]// Parvina
        [TestCase(8, 8, 64)]
        public void MultiplTo_TestWithCases_ExpectedResult(double x, double y, double result )
        {
            Calculator calculator = new(x);
            var _calc =  calculator.MultiplTo(y);
            Assert.That(_calc.Result, Is.EqualTo(result));
        }


        [TestCase(4, 2, 2)]// Abdurasul
        [TestCase(8, 4, 2)]
        public void DivTo_TestWithCases_Result(double x, double y, double result)
        {
            Calculator calculator = new(x);
            var _calc = calculator.DivTo(y);
            Assert.That(_calc.Result, Is.EqualTo(result));
        }

        [Test]
        public void DivTo_FourToZero_ThrowException()
        {
            Calculator calculator = new(4);
            Assert.Throws<DivideByZeroException>(()=> calculator.DivTo(0));
        }


        [Test]
        public void Calculator_Behavior_Test()
        {
            Calculator calculator = new();

            calculator = calculator.AddTo(5).SubtractTo(2).MultiplTo(5).DivTo(3);

            Assert.That(calculator.Result, Is.EqualTo(5));
            
        }

        // Function to find max value

    }
}