using System;
public class Program
{
    public static void ExampleOfQuerySyntax()
    {   
        // Data Source
        List<int> integerList = new List<int>()
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9,10
        };
        // Query syntax
        var QuerySyntax = from obj in integerList // data source
                          where obj > 5           // condition
                          select obj;             // selection
        foreach (var item in QuerySyntax)
        {
            Console.WriteLine(item);
        }

    }
    public static void ExampleOfMethodSytax()
    {
        List<int> integerList = new List<int>()
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9,10
        };
        // method syntax
        var MehtodSyntax = integerList.Where(obj => obj > 5).ToList();
        foreach (var item in MehtodSyntax)
        {
            Console.WriteLine(item);
        }
    }
    public static void Main(string[] args)
    {
        ExampleOfMethodSytax();

    }
}