using System;
using System.Collections;
public class Student
{
    public string Name { get; set; }
    public int Roll {  get; set; }
    public List<string> ProgrammingLanguage { get; set; }
    public Student(string name, int roll, List<string> programmingLanguage)
    {
        Name = name;
        Roll = roll;
        ProgrammingLanguage = programmingLanguage;
    }


}
public class Program
{
    public static void Main(string[] args)
    {
        List<string> NameList = new List<string>
        {
            "Bangladesh", "Nepal", "Palestine", "Thailand"
        };
        // selectMany operator using method syntax -> from a list of string, it platten all character into a single list

        List<char> CharacterList = NameList.SelectMany(x => x).ToList();
        foreach (var character in CharacterList)
        {
            Console.Write(character + " ");
        }
        Console.WriteLine();
        // selectMany operator with complex type -> from a list of object, platten all the programming language into a list
        List<Student> StudentList = new List<Student>()
        {
            new Student("Mahbub",13, new List<string>{"c++", "c#", "Typescript"}),
            new Student("Arju",15, new List<string>{"c++", "c#", "python"}),
            new Student("Alice",16, new List<string>{"c++", "Java", "Golang"}),
        };
        List<string>LanguageList = StudentList.SelectMany(std => std.ProgrammingLanguage).Distinct().ToList();
        foreach(string language in LanguageList)
        {
            Console.WriteLine(language);
        }
        // cross product using selectMany
        var crossProduct = StudentList.SelectMany(std => std.ProgrammingLanguage, (student, program) => new
        {
            Name = student.Name,
            program = program
        }).ToList();
        Console.WriteLine("cross product");
        foreach (var student in crossProduct)
        {
            Console.WriteLine($"{student.Name} {student.program}");
        }
    }
}