using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackerRank_C_Sharp_Basic
{
    public class EmployeesManagementSolution
    {
        public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            var output = employees.GroupBy(b => b.Company).Select(s => new { s.Key, avg = Math.Round(s.Average(a=>a.Age))
                //Sum(sc => sc.Age) / s.Count() 
            }).ToDictionary(d => d.Key, d => d.avg);
            return output;
        }

        public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {

            var output = employees.GroupBy(b => b.Company).Select(s => new { s.Key, cnt = s.Count() }).ToDictionary(d => d.Key, d => d.cnt);
            return output;
        }

        public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            var output = employees.GroupBy(b => b.Company).Select(s => new { s.Key, old = s.MaxBy(m => m.Age) }).ToDictionary(d => d.Key, d => d.old);
            return output;
        }

        public static void Main()
        {
            int countOfEmployees = int.Parse(Console.ReadLine());

            var employees = new List<Employee>();

            for (int i = 0; i < countOfEmployees; i++)
            {
                string str = Console.ReadLine();
                string[] strArr = str.Split(' ');
                employees.Add(new Employee
                {
                    FirstName = strArr[0],
                    LastName = strArr[1],
                    Company = strArr[2],
                    Age = int.Parse(strArr[3])
                });
            }

            employees = employees.OrderBy(o => o.Company).ToList();

            foreach (var emp in AverageAgeForEachCompany(employees))
            {
                Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in CountOfEmployeesForEachCompany(employees))
            {
                Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in OldestAgeForEachCompany(employees))
            {
                Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
            }
        }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }
}