using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public string EmployeeEmailId { get; set; }
    public int EmployeeAge { get; set; }
    public char EmployeeGender { get; set; }
    public int EmployerId { get; set; }
}

public class Employer
{
    public int EmployerId { get; set; }
    public string EmployeeDescription { get; set; }
}

public class Program
{
    public static void Main()
    {
        var employees = new List<Employee>
        {
            new Employee { EmployeeId = 1, EmployeeName = "Basant", EmployeeEmailId = "Basantgera29@gmail.com", EmployeeAge = 32, EmployeeGender = 'M', EmployerId = 1 },
            new Employee { EmployeeId = 2, EmployeeName = "Kyle", EmployeeEmailId = "Kyle29@gmail.com", EmployeeAge = 32, EmployeeGender = 'M', EmployerId = 2 },
            new Employee { EmployeeId = 3, EmployeeName = "Johnathan", EmployeeEmailId = "Johnathan29@gmail.com", EmployeeAge = 32, EmployeeGender = 'M', EmployerId = 2 },
            new Employee { EmployeeId = 4, EmployeeName = "Noah", EmployeeEmailId = "Noah29@gmail.com", EmployeeAge = 32, EmployeeGender = 'M', EmployerId = 3 },
            new Employee { EmployeeId = 5, EmployeeName = "Robert", EmployeeEmailId = "Robert29@gmail.com", EmployeeAge = 32, EmployeeGender = 'M', EmployerId = 3 },
            new Employee { EmployeeId = 6, EmployeeName = "Robert", EmployeeEmailId = "Robert29@gmail.com", EmployeeAge = 32, EmployeeGender = 'M', EmployerId = 3 }
        };

        var employers = new List<Employer>
        {
            new Employer { EmployerId = 1, EmployeeDescription = "ABM College" },
            new Employer { EmployerId = 2, EmployeeDescription = "Alberta University" },
            new Employer { EmployerId = 3, EmployeeDescription = "Calgary University" }
        };

        DisplayAlbertaUniversityEmployees(employees, employers);
        DisplayCalgaryUniversityEmployeeCount(employees, employers);
        DisplayDistinctCalgaryUniversityEmployees(employees, employers);
    }

    private static void DisplayAlbertaUniversityEmployees(List<Employee> employees, List<Employer> employers)
    {
        var albertaEmployees = employees
            .Where(e => e.EmployerId == employers.First(emp => emp.EmployeeDescription == "Alberta University").EmployerId)
            .OrderByDescending(e => e.EmployeeName)
            .Select(e => e.EmployeeName);

        Console.WriteLine("Alberta University Employees (Descending Order):");
        foreach (var name in albertaEmployees)
        {
            Console.WriteLine($"- {name}");
        }
        Console.WriteLine();
    }

    private static void DisplayCalgaryUniversityEmployeeCount(List<Employee> employees, List<Employer> employers)
    {
        var calgaryEmployeeCount = employees
            .Count(e => e.EmployerId == employers.First(emp => emp.EmployeeDescription == "Calgary University").EmployerId);

        Console.WriteLine($"Calgary University Employee Count: {calgaryEmployeeCount}\n");
    }

    private static void DisplayDistinctCalgaryUniversityEmployees(List<Employee> employees, List<Employer> employers)
    {
        var distinctCalgaryEmployees = employees
            .Where(e => e.EmployerId == employers.First(emp => emp.EmployeeDescription == "Calgary University").EmployerId)
            .GroupBy(e => e.EmployeeEmailId)
            .Select(g => g.First());

        Console.WriteLine("Distinct Employees of Calgary University:");
        foreach (var employee in distinctCalgaryEmployees)
        {
            Console.WriteLine($"- {employee.EmployeeName}");
        }
    }
}
