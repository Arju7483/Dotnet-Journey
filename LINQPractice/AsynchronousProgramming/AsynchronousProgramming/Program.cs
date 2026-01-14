using System;
using System.Threading.Tasks;

public class Program
{
    public static async Task Method1()
    {
        Console.WriteLine("method1 is start");
        await Task.Delay(TimeSpan.FromSeconds(5));
        Console.WriteLine("method1 is end");
    }

    public static async Task Main(string[] args)
    {
        Console.WriteLine("main start");
        for(int i = 1; i <= 5; i++)
        {
        await Method1();
        }
        
        Console.WriteLine("main end");
    }
}
