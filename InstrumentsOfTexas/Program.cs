﻿using System;

namespace InstrumentsOfTexas
{
    public class CalculationException : Exception
    {
        public CalculationException(int operand1, int operand2, string message, Exception inner) : base(message, inner)
        // TODO: complete the definition of the constructor
        {
            this.Operand1 = operand1;
            this.Operand2 = operand2;
        }

        public int Operand1 { get; }
        public int Operand2 { get; }
    }

    public class CalculatorTestHarness
    {
        private Calculator calculator;

        public CalculatorTestHarness(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public string TestMultiplication(int x, int y)
        {
            try
            {
                Multiply(x, y);

            }

            catch (CalculationException e) when (x < 0 && y < 0)
            {
                return $"Multiply failed for negative operands. {e.Message}";
            }

            catch (CalculationException e) when (x > 0 || y > 0)
            {
                return $"Multiply failed for mixed or positive operands. {e.Message}";
            }
            return "Multiply succeeded";
        }

        public void Multiply(int x, int y)
        {
            try
            {
                Calculator calculator = new Calculator();
                calculator.Multiply(x, y);
            }

            catch (OverflowException e)
            {

                throw new CalculationException(x, y, e.Message, e.InnerException);
            }

        }
    }


    // Please do not modify the code below.
    // If there is an overflow in the multiplication operation
    // then a System.OverflowException is thrown.
    public class Calculator
    {
        public int Multiply(int x, int y)
        {
            checked
            {
                return x * y;
            }
        }
    }


    public static class Program
    {
        static void Main()
        {
            var cth = new CalculatorTestHarness(new Calculator());
            cth.TestMultiplication(-2, -Int32.MaxValue);
        }
    }
}
