using System;

namespace CalculatorConundrum
{
    public static class SimpleCalculator
    {
        public static string Calculate(int operand1, int operand2, string operation)
        {
            try
            {
                switch (operation)
                {
                    case "+":
                        return $"{operand1} + {operand2} = {SimpleOperation.Addition(operand1, operand2).ToString()}";

                    case "/":
                        if (operand2 == 0)
                        {
                            return "Division by zero is not allowed.";
                        }
                        return  $"{operand1} / {operand2} = {SimpleOperation.Division(operand1, operand2).ToString()}"; 

                    case "*":
                        return $"{operand1} * {operand2} = {SimpleOperation.Multiplication(operand1, operand2).ToString()}";  

                    case null:
                        throw new ArgumentNullException("The operator is null");

                    case "":
                        throw new ArgumentException("The operator is Empty");
                                                                      
                    default:
                        throw new ArgumentOutOfRangeException("Invalid operator");
                }
            }

            catch (ArgumentOutOfRangeException)
            {

                throw; 
            }

            catch (ArgumentException)
            {
                throw;
            }


        }
    }

    public static class SimpleOperation
    {
        public static int Division(int operand1, int operand2)
        {
            return operand1 / operand2;
        }

        public static int Multiplication(int operand1, int operand2)
        {
            return operand1 * operand2;
        }

        public static int Addition(int operand1, int operand2)
        {
            return operand1 + operand2;
        }
    }
}
