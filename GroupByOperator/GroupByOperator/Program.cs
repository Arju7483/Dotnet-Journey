using System;
using System.Collections;
using System.Runtime.Serialization;
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public override bool Equals(object? obj)
    {
        return this.Id == ((Employee)obj)?.Id && this.Name == ((Employee)obj).Name;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(this.Id, this.Name);
    }

}
public class Program
{
    public static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee {Id = 1, Name = "Mahbub", Gender = "Male"},
            new Employee {Id = 2, Name = "Arju", Gender = "Male"},
            new Employee {Id = 3, Name = "Tama", Gender = "Female"},
            new Employee {Id = 4, Name = "Samia", Gender = "Female"},
            new Employee {Id = 5, Name = "Meem", Gender = "Female"},
        };
        // group the employees based on gender
        List<IGrouping<string,Employee>>selectedEmployee = employees.GroupBy(emp => emp.Gender).ToList();
        foreach(IGrouping<string,Employee>group in selectedEmployee)
        {
            Console.WriteLine(group.Key);
            foreach(Employee emp in group)
            {
                Console.WriteLine(emp.Id + " "+emp.Name); 
            }
        }
        // group by gender and orderby name
        var selectedEmployee2 = employees.GroupBy(emp => emp.Gender).Select(x => new
        {
            Key = x.Key,
            Employees = x.OrderBy(x => x.Name)
        }).ToList();
        Console.WriteLine("group by gender and orderby name:");
        foreach(var group in selectedEmployee2)
        {
            Console.WriteLine(group.Key); 
            foreach(Employee emp in group.Employees)
            {
                Console.WriteLine(emp.Id + " " +  emp.Name);
            }
        }

    }
}