using System;
/*
Person p = new Person();
p.SetFirstName("Peter");
Person p = new Person(parameters);
Console.WriteLine(p.GetFirstName());*/
class Program
{
    static void Main(string[] args)
    {
        Fraction noParameters = new Fraction();
        Console.WriteLine(noParameters.GetFractionString());
        Console.WriteLine(noParameters.GetDecimalValue());

        Fraction oneParameter = new Fraction(5);
        Console.WriteLine(oneParameter.GetFractionString());
        Console.WriteLine(oneParameter.GetDecimalValue());

        Fraction twoParameters = new Fraction(3, 4);
        Console.WriteLine(twoParameters.GetFractionString());
        Console.WriteLine(twoParameters.GetDecimalValue());

        Fraction decimalParameters = new Fraction(1, 3);
        Console.WriteLine(decimalParameters.GetFractionString());
        Console.WriteLine(decimalParameters.GetDecimalValue());
    }
}