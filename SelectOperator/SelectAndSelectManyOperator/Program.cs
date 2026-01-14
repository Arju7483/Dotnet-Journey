using System;
using System.Collections;
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }
    public Employee(int id, string name, int salary)
    {
        Id = id;   
        Name = name;
        Salary = salary;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        List<Employee> Employees = new List<Employee>
        {
            new Employee(1,"Mahbub",10000),
            new Employee(2,"Arju",20000),
            new Employee(3,"Alice",30000),
            new Employee(4,"Bob",40000)
        };
        // select operator using Query Syntax
        List<int> selectedEmployees = (from emp in Employees select emp.Id).ToList();
        foreach(int emp in selectedEmployees)
        {
            Console.WriteLine(emp);
        }

        // select operator using Method Syntax -> one property
        List<int>selectedEmployee2 = Employees.Select(emp => emp.Id).ToList();
        foreach(int emp in selectedEmployee2)
        {
            Console.WriteLine(emp);
        }

        // select operator using Method Syntax -> all property
        List<Employee> selectedEmployee3 = Employees.Select(emp => emp).ToList();
        foreach (Employee emp in selectedEmployee3)
        {
            Console.WriteLine(emp.Id);
        }

        // select operator using Method syntax -> multiple properties

        var selectedEmployee4 = Employees.Select(emp => new
        {
            Id = emp.Id,
            Name = emp.Name,
        }).ToList();
        foreach(var emp in selectedEmployee4)
        {
            Console.WriteLine(emp.Id + " " + emp.Name);
        }
        // select with index value
        var selectedEmployee5 = Employees.Select((emp, index) => new
        {
            EmpId = emp.Id,
            EmpIndex = index,
            Name = emp.Name,
        }).ToList();
        // also with where
        var selectedEmployee6 = Employees.Where(emp => emp.Id % 2 == 0).Select((e,index) => new
        {
            EmpId = e.Id,
            EmpIndex = index,
            Name = e.Name,
        }).ToList();
        foreach(var emp in selectedEmployee6)
        {
            Console.WriteLine("Index: " + emp.EmpIndex + " Id: " + emp.EmpId);
        }
    }
}
