using Builder_Pattern;

class Program
{
    static void Main(string[] args)
    {
        var familyCar = new CarBuilder()
                            .SetType("Sedan")
                            .SetEngine("Electric")
                            .SetWheels(4)
                            .SetColor("Blue")
                            .Build();
        Console.WriteLine(familyCar.ToString());
    }
}