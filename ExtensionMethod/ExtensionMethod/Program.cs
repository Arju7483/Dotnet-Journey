using System;
using System.Runtime.CompilerServices;
//Extension Method on Built-in Type 
public static class StringExtension
{
    public static int wordCount(this string str)
    {
        int cnt = 0;
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == ' ') cnt++;
        }
        return cnt + 1;
    }
}
//Extension Method on User-defined Class
public class Student
{
    public  string Name;
    public  int Age;
    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
public static class StudentExtension
{
    public static void PrintResult(this Student stu)
    {
        System.Console.WriteLine(stu.Name);
        System.Console.WriteLine(stu.Age);
    }
}

public class Program
{
    public static void applyStringExtension()
    {
        string s = "Hello world";
        System.Console.WriteLine(s.wordCount());
    }
    public static void applyStudentExtension()
    {
        Student s = new Student("Muhammad", 43);
        s.PrintResult();
    }
    public static void Main(string[] args) {
        applyStudentExtension();
    }
}
