using System;

namespace Lab_6_task_1
{
public class Calculator<T>
{
    public delegate T ArithmeticOperation(T x, T y);

    public ArithmeticOperation Add { get; set; }
    public ArithmeticOperation Subtract { get; set; }
    public ArithmeticOperation Multiply { get; set; }
    public ArithmeticOperation Divide { get; set; }

    public Calculator(ArithmeticOperation add, ArithmeticOperation subtract, ArithmeticOperation multiply, ArithmeticOperation divide)
    {
        Add = add;
        Subtract = subtract;
        Multiply = multiply;
        Divide = divide;
    }

    public T PerformOperation(T x, T y, ArithmeticOperation operation)
    {
        if (operation == null)
        {
            throw new ArgumentNullException(nameof(operation), "Arithmetic operation cannot be null.");
        }

        return operation(x, y);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Минко Ярослав");

        Calculator<int> intCalculator = new Calculator<int>(
            (x, y) => x + y, 
            (x, y) => x - y, 
            (x, y) => x * y, 
            (x, y) => x / y  
        );

        Console.WriteLine("Результат додавання: " + intCalculator.PerformOperation(5, 3, intCalculator.Add));
        Console.WriteLine("Результат віднімання: " + intCalculator.PerformOperation(5, 3, intCalculator.Subtract));
        Console.WriteLine("Результат множення: " + intCalculator.PerformOperation(5, 3, intCalculator.Multiply));
        Console.WriteLine("Результат ділення: " + intCalculator.PerformOperation(5, 3, intCalculator.Divide));

        Calculator<double> doubleCalculator = new Calculator<double>(
            (x, y) => x + y, 
            (x, y) => x - y, 
            (x, y) => x * y, 
            (x, y) => x / y  
        );

        Console.WriteLine("Результат додавання: " + doubleCalculator.PerformOperation(5.5, 3.2, doubleCalculator.Add));
        Console.WriteLine("Результат віднімання: " + doubleCalculator.PerformOperation(5.5, 3.2, doubleCalculator.Subtract));
        Console.WriteLine("Результат множення: " + doubleCalculator.PerformOperation(5.5, 3.2, doubleCalculator.Multiply));
        Console.WriteLine("Результат ділення: " + doubleCalculator.PerformOperation(5.5, 3.2, doubleCalculator.Divide));
    }
}

}