using System;
using System.Collections;
public class DataType
{
    public int Value { get; set; }
    public int indexNumber { get; set; }
}
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }
    public List<string>Technology = new List<string>();
    public Employee(int id, string name, int salary, List<string> technology)
    {
        Id = id;
        Name = name;
        Salary = salary;
        Technology = technology;
    }


}
public class Program
{
    public static void Main(string[] args)
    {
        List<int> integerList = new List<int>()
        {
            1,2, 3, 4,5, 6, 7, 8, 9, 10
        };
        // using where operator, print odd number with index
        List<DataType> oddNumbers = integerList.Select((num, index) => new DataType
        {
            Value = num,
            indexNumber = index
        }).Where(x => x.Value % 2 != 0).ToList();
        foreach (DataType x in oddNumbers)
        {
            Console.WriteLine("Index: " + x.indexNumber + " Value: " + x.Value);
        } 
        // shows the employees with salary greater than 10000 usng where
        List<Employee> employees = new List<Employee>()
        {
            new Employee(1,"Mahbub",10000,new List<string>{"C++,Java"}),
            new Employee(2,"Arju",20000, new List<string>{"C#,Java"}),
            new Employee(3,"Alice",30000,new List<string>{"C++,Phthon"}),
            new Employee(4,"Bob",50000, new List<string>{})
        };
        List<Employee>hightSalary = employees.Where(emp =>  emp.Salary > 10000).ToList();
        
        foreach (Employee emp in hightSalary)
        {
            Console.WriteLine($"Employees salary: {emp.Salary}");
        }
        // multiple condition
        var employeeWithMonthlySalary = employees.Where(emp => emp.Salary > 10000 && emp.Technology.Any()).Select(x => new
        {
            Name = x.Name,
            MonthlySalary = x.Salary/12
        }).ToList();

        foreach (var x in employeeWithMonthlySalary)
        {
            Console.WriteLine("Name: " + x.Name + " Monthly Salary: " + x.MonthlySalary);
        }
    }

}

