using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("Red", 4);
        Rectangle rectangle = new Rectangle("Blue", 3, 5);
        Circle circle = new Circle("Green", 2.5);

        Console.WriteLine($"Square color: {square.GetColor()}, area: {square.GetArea()}");
        Console.WriteLine($"Rectangle color: {rectangle.GetColor()}, area: {rectangle.GetArea()}");
        Console.WriteLine($"Circle color: {circle.GetColor()}, area: {circle.GetArea():F2}");

        List<Shape> shapes = new List<Shape>
        {
            square,
            rectangle,
            circle,
            new Square("Yellow", 6)
        };

        Console.WriteLine();
        Console.WriteLine("Shapes in the list:");

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}, Area: {shape.GetArea():F2}");
        }
    }
}
