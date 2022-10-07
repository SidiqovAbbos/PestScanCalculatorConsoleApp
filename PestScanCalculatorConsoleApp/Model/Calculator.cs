namespace PestScanCalculatorConsoleApp.Model
{
    public record Calculator
    {
        public double Result { get; init; }

        public Calculator(double value = 0)
        {
            Result = value;
        }

        public Calculator AddTo(double value)
        {
            return this with { Result = Result + value };
            //Similar with: return new Calculator(Result + value);
        }

        public Calculator SubtractTo(double value)
        {
            return this with { Result = Result - value };
        }

        public Calculator MultiplTo(double value)
        {
            return this with { Result = Result * value};
        }

        public Calculator DivTo(double value)
        {
            if (value is 0)
            {
                throw new DivideByZeroException();
            }
            return this with { Result = Result / value };
        }
    }
}
