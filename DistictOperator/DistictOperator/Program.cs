using System;
using System.Collections;
using System.Runtime.Serialization;
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public override bool Equals(object? obj)
    {
        return this.Id == ((Employee)obj)?.Id && this.Name == ((Employee)obj).Name;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(this.Id, this.Name);
    }

}
//custom comparator interface
public class EmployeeComparator : IEqualityComparer<Employee>
{
    public bool Equals(Employee x, Employee y)
    {
        if(object.ReferenceEquals(x,y)) return true;
        if(x == null || y == null) return false;
        return x.Id == y.Id && x.Name == y.Name;
    }
    public int GetHashCode(Employee obj)  
    {
        if(obj == null) return 0;
        return HashCode.Combine(obj.Id, obj.Name);
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee {Id = 1, Name = "Arju"},
            new Employee {Id = 2, Name = "Mahbub"},
            new Employee {Id = 3, Name = "Arju"},
            new Employee {Id = 2, Name = "Mahbub"}
        }; 
        // list all distinct name
        List<string>distinctName = employees.Select(e => e.Name).Distinct().ToList();
        Console.WriteLine("Distinct Name:");
        foreach(string name in distinctName)
        {
            Console.WriteLine(name);
        }
        // list all distinct employee by Id
        List<Employee>selectedEmployee = employees.Select(e => e).DistinctBy(e => e.Id).ToList();
        Console.WriteLine("Distinct Employees by Id:");
        foreach (Employee e in selectedEmployee)
        {
            Console.WriteLine(e.Id + " " + e.Name);
        }
        // list all distinct employee by all property
        List<Employee>distinctEmployee = employees.Select(e => e).Distinct(new EmployeeComparator()).ToList();
        Console.WriteLine("Distinct Employees by all properties:");
        foreach(Employee emp in distinctEmployee)
        {
            Console.WriteLine(emp.Id + " " + emp.Name);
        }

        // list all distinct employee by all property using override(alternative way)
        List<Employee> distinctEmployee2 = employees.Select(e => e).Distinct().ToList();
        Console.WriteLine("Distinct Employees by all properties (alternative way):");
        foreach (Employee emp in distinctEmployee2)
        {
            Console.WriteLine(emp.Id + " " + emp.Name);
        }
    }
}