using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Average());

            //Order numbers in ascending order and decsending order. Print each to console.
            IEnumerable<int> ascNumbers = numbers.OrderBy(num => num);
            foreach (var i in ascNumbers)
            {
                Console.WriteLine(i);
            }
            var dscNumbers = numbers.OrderByDescending(num => num);
            foreach (var i in dscNumbers)
            {
                Console.WriteLine(i);
            }

            //Print to the console only the numbers greater than 6
            var bigNumbers = numbers.Where(num => num > 6);
            foreach (var i in bigNumbers)
            {
                Console.WriteLine(i);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var firstFour = (from num in numbers
                            orderby num ascending
                            select num).Take(4);
            foreach(var i in firstFour)
            {
                Console.WriteLine(i);
            }
            var lastFour = numbers.OrderBy(num => num).TakeLast(4);
            foreach (var i in lastFour)
            {
                Console.WriteLine(i);
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers.SetValue(23, 4);
            var withAge = numbers.OrderByDescending(num => num);
            foreach(var i in withAge)
            {
                Console.WriteLine(i);
            }

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var ascFullNameCS = employees.Where(name => name.FirstName.StartsWith('C') || name.FirstName.StartsWith('S')).OrderBy(name => name.FullName);
            foreach(var n in ascFullNameCS)
            {
                Console.WriteLine(n.FullName);
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var byAge = employees.Where(age => age.Age > 26).OrderBy(age => age.Age).ThenBy(name => name.FirstName);
            foreach (var n in byAge)
            {
                Console.WriteLine(n.FullName);
                Console.WriteLine(n.Age);
            }

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine(employees.Where(item => item.YearsOfExperience <= 10 && item.Age > 35).Sum(employee => employee.YearsOfExperience));
            Console.WriteLine(employees.Where(item => item.YearsOfExperience <= 10 && item.Age > 35).Average(employee => employee.YearsOfExperience));

            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Wayne", "Gretzky", 55, 2)).ToList();
            foreach (var i in employees)
            {
                Console.WriteLine(i.FullName);
                Console.WriteLine(i.Age);
                Console.WriteLine(i.YearsOfExperience);
            }
            
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
