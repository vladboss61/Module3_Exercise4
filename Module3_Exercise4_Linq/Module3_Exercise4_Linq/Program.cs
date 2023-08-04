using System;
using System.Collections.Generic;
using System.Linq;

namespace Module3_Exercise4_Linq;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    public static void LinqMethods1()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Example 1: Where
        var evenNumbers = numbers.Where(n => n % 2 == 0);
        Console.WriteLine("Even numbers:");
        foreach (var num in evenNumbers)
        {
            Console.WriteLine(num);
        }

        // Example 2: Select
        var squaredNumbers = numbers.Select(n => n * n);
        Console.WriteLine("\nSquared numbers:");
        foreach (var num in squaredNumbers)
        {
            Console.WriteLine(num);
        }

        // Example 3: OrderBy
        var orderedNumbers = numbers.OrderBy(n => n);
        Console.WriteLine("\nOrdered numbers:");
        foreach (var num in orderedNumbers)
        {
            Console.WriteLine(num);
        }

        // Example 4: Average
        double average = numbers.Average();
        Console.WriteLine("\nAverage: " + average);

        // Example 5: Sum
        int sum = numbers.Sum();
        Console.WriteLine("\nSum: " + sum);

        // Example 6: First
        int firstElement = numbers.First();
        Console.WriteLine("\nFirst element: " + firstElement);

        // Example 7: Last
        int lastElement = numbers.Last();
        Console.WriteLine("\nLast element: " + lastElement);

        // Example 8: Any
        bool anyEven = numbers.Any(n => n % 2 == 0);
        Console.WriteLine("\nAny even numbers? " + anyEven);

        // Example 9: All
        bool allPositive = numbers.All(n => n > 0);
        Console.WriteLine("\nAre all numbers positive? " + allPositive);

        // Example 10: Count
        int count = numbers.Count();
        Console.WriteLine("\nCount: " + count);
    }

    public static void LinqMethods2()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Example 1: Take
        var firstThreeNumbers = numbers.Take(3);
        Console.WriteLine("First three numbers:");
        foreach (var num in firstThreeNumbers)
        {
            Console.WriteLine(num);
        }

        // Example 2: TakeWhile
        var numbersLessThanFive = numbers.TakeWhile(n => n < 5);
        Console.WriteLine("\nNumbers less than five:");
        foreach (var num in numbersLessThanFive)
        {
            Console.WriteLine(num);
        }

        // Example 3: GroupBy
        var groupedNumbers = numbers.GroupBy(n => n % 2 == 0);
        Console.WriteLine("\nGrouped numbers:");
        foreach (IGrouping<bool, int> group in groupedNumbers)
        {
            Console.WriteLine(group.Key ? "Even Numbers:" : "Odd Numbers:");
            foreach (var num in group)
            {
                Console.WriteLine(num);
            }
        }

        // Example 4: Skip
        var numbersAfterFive = numbers.Skip(5);
        Console.WriteLine("\nNumbers after five:");
        foreach (var num in numbersAfterFive)
        {
            Console.WriteLine(num);
        }
    }

    public static void LinqMethod3()
    {
        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Alice", Age = 22, Grade = "A" },
            new Student { Id = 2, Name = "Bob", Age = 20, Grade = "B" },
            new Student { Id = 3, Name = "Charlie", Age = 21, Grade = "A" },
            new Student { Id = 4, Name = "David", Age = 23, Grade = "C" },
            new Student { Id = 5, Name = "Eve", Age = 22, Grade = "B" },
        };

        Console.WriteLine("Students:");
        foreach (var student in students)
        {
            Console.WriteLine($"-1- ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
        }
        
        Console.WriteLine("================");

        var sortedStudents = students
            .OrderBy(s => s.Grade)
            .ToArray(); // Primary sort by Grade


        Console.WriteLine("Sorted with Then students:");
        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"-2- ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
        }

        Console.WriteLine("================");

        // Example: OrderBy and ThenBy
        var sortedThenStudents = students
            .OrderBy(s => s.Grade)         // Primary sort by Grade
            .ThenByDescending(s => s.Age)
            .ToArray(); // Secondary sort by Age in descending order

        Console.WriteLine("Sorted with Then students:");
        foreach (var student in sortedThenStudents)
        {
            Console.WriteLine($"-3- ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
        }

        /*
         *  Sorted students:
            ID: 3, Name: Charlie, Age: 21, Grade: A
            ID: 1, Name: Alice, Age: 22, Grade: A
            ID: 5, Name: Eve, Age: 22, Grade: B
            ID: 2, Name: Bob, Age: 20, Grade: B
            ID: 4, Name: David, Age: 23, Grade: C
         */
    }
}
