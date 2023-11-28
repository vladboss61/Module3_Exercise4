using System;
using System.Collections.Generic;
using System.Linq;

namespace Module3_Exercise4_Linq;

public static class NewStringMethods
{
    public static string Capitalize(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }
        
        char[] chars = str.ToCharArray();
        chars[0] = char.ToUpper(chars[0]);
        return new string(chars);
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        LinqMethods1();
    }

    public static void LinqMethods1()
    {
        List<int> numbers = new List<int> { 5, 3, 1, 4, 6, 7, 8, 9, 10 };

        // Example 1: Where
        IEnumerable<string> evenNumbers = numbers
                            .Where(n => n % 2 == 0)
                            .Select(x => $"x = {x}");

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
        int[] array = numbers.ToArray();
        Array.Sort(array);

        // Example 3: OrderBy
        IEnumerable<int> orderedNumbers = numbers.OrderByDescending(n => n);
        Console.WriteLine("\n numbers:");

        foreach (var num in numbers)
        {
            Console.WriteLine(num);
        }

        Console.WriteLine("\nOrdered numbers:");

        foreach (var num in orderedNumbers)
        {
            Console.WriteLine(num);
        }

        // Example 4: Average
        double average = numbers.Select(x => x * 10).Average();
        Console.WriteLine("\nAverage: " + average);

        // Example 5: Sum
        int sum = numbers.Sum();
        Console.WriteLine("\nSum: " + sum);

        // Example 6: First
        int firstElement = numbers.First( x => x > 7);
        Console.WriteLine("\nFirst element: " + firstElement);

        // Example 7: Last
        int lastElement = numbers.Last(x => x % 2 == 1);
        Console.WriteLine("\nLast element: " + lastElement);

        // Example 8: Any
        bool anyEven = numbers.Any();
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
        IEnumerable<int> firstThreeNumbers = numbers.Take(3);
        Console.WriteLine("First three numbers:");
        foreach (var num in firstThreeNumbers)
        {
            Console.WriteLine(num);
        }

        // Example 2: TakeWhile
        IEnumerable<int> numbersLessThanFive = numbers.TakeWhile(n => n < 5);
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
            .OrderBy(s => s.Grade) // Primary sort by Grade
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

    public static void LinqMethod4()
    {
        List<object> mixedList = new List<object>
        {
            1, 2, 3.14, "Hello", 5, "World"
        };

        // Example 1: Aggregate
        int sum = mixedList.OfType<int>()
            .Aggregate((accumulate, number) => accumulate + number);

        // 10 20 31 41 51 61
        // 10 + 20 = 30 // 1
        // 30 + 31 = 61 // 2
        // 61 + 41 = 102 // 3
        // 102 + 51 = 153 // 4
        // 153 + 61 = 214 // 5

        Console.WriteLine("Sum of integers: " + sum);

        //// Example 2: Cast
        //List<int> intList = mixedList.Cast<int>().ToList();
        //Console.WriteLine("\nCasted integer list:");
        //foreach (var num in intList)
        //{
        //    Console.WriteLine(num);
        //}

        // Example 3: Reverse
        var reversedList = mixedList.AsEnumerable().Reverse();
        Console.WriteLine("\nReversed list:");
        foreach (var item in reversedList)
        {
            Console.WriteLine(item);
        }

        // Example 4: OfType
        var stringList = mixedList.OfType<string>();
        Console.WriteLine("\nString elements:");
        foreach (var str in stringList)
        {
            Console.WriteLine(str);
        }

        List<int> numbers1 = new List<int> { 1, 2, 3 };
        List<int> numbers2 = new List<int> { 4, 5, 6 };

        // Example 5: Concat
        var combinedList = numbers1.Concat(numbers2);
        Console.WriteLine("\nConcatenated list:");
        foreach (var num in combinedList)
        {
            Console.WriteLine(num);
        }

        // Example 6: Zip
        var zippedList = numbers1.Zip(numbers2, (num1, num2) => num1 + num2);
        // 1 4 = 5
        // 2 5 = 7
        // 3 6 = 9

        Console.WriteLine("\nZipped list:");
        foreach (var num in zippedList)
        {
            Console.WriteLine(num);
        }
    }

    public static void LinqMethod5()
    {
        // Example 1: Empty
        var emptyList = Enumerable.Empty<int>();
        Console.WriteLine("Empty List:");
        foreach (var item in emptyList)
        {
            Console.WriteLine(item); // No output since the list is empty
        }

        // Example 2: Range
        var rangeList = Enumerable.Range(7, 10);
        Console.WriteLine("\nRange List:");
        foreach (var num in rangeList)
        {
            Console.WriteLine(num);
        }

        // Example 3: Repeat
        var repeatList = Enumerable.Repeat("Hello", 3);
        Console.WriteLine("\nRepeat List:");
        foreach (var str in repeatList)
        {
            Console.WriteLine(str);
        }

        List<int> numbers = new List<int> { 1, 2, 3 };

        // Example 4: Append
        IEnumerable<int> appendedList = numbers.Append(4);
        Console.WriteLine("\nAppended List:");
        foreach (var num in appendedList)
        {
            Console.WriteLine(num);
        }
    }

    public static void LinqLazy()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        // Example 1: Lazy Evaluation
        List<int> query = numbers.Where(n =>
        {
            return n % 2 == 0;
        }).ToList();

        numbers.Add(30);

        Console.WriteLine("Query created, but not executed yet.");

        // Now, let's enumerate the results
        foreach (var num in query)
        {
            Console.WriteLine("Result: " + num);
        }

        Console.WriteLine("1 -- Query executed and enumerated.");

        numbers.Add(99);

        foreach (var num in query)
        {
            Console.WriteLine("Result: " + num);
        }

        Console.WriteLine("2 -- Query executed and enumerated.");
    }

    public static void LinqSets()
    {
        List<int> numbers1 = new List<int> { 1, 2, 3, 4, 5, 5, 5 };
        List<int> numbers2 = new List<int> { 4, 5, 6, 7, 7, 8, 8 };

        // Example 1: Except
        var exceptResult = numbers2.Except(numbers1);
        Console.WriteLine("Elements in numbers1 but not in numbers2:");
        foreach (var num in exceptResult)
        {
            Console.WriteLine(num);
        }

        // Example 2: Intersect
        var intersectResult = numbers1.Intersect(numbers2);
        Console.WriteLine("\nCommon elements in numbers1 and numbers2:");
        foreach (var num in intersectResult)
        {
            Console.WriteLine(num);
        }

        // Example 3: Union
        var unionResult = numbers1.Union(numbers2);
        Console.WriteLine("\nUnion of numbers1 and numbers2 (without duplicates):");
        foreach (var num in unionResult)
        {
            Console.WriteLine(num);
        }
        List<int> numbers3 = new List<int> { 3, 3, 44, 44, 5, 6, 7, 7, 8, 8 };
        Console.WriteLine("Unique numbers:");
        var distinctNumbers = numbers3.Distinct();
        foreach (var item in distinctNumbers)
        {
            Console.WriteLine(item);
        }
    }

    public static void LinqJoin()
    {
        List<Person> people = new List<Person>
        {
            new Person { Id = 1, Name = "Alice" },
            new Person { Id = 2, Name = "Bob" },
            new Person { Id = 3, Name = "Charlie" },
            new Person { Id = 3, Name = "Den" }
        };

        List<Grade> grades = new List<Grade>
        {
            new Grade { Id = 1, GradeLetter = "A" },
            new Grade { Id = 2, GradeLetter = "B" },
            new Grade { Id = 3, GradeLetter = "A+" },
            new Grade { Id = 5, GradeLetter = "C" }
        };

        // Example 4: Join
        var joinedResult = people.Join(grades,
            person => person.Id,
            grade => grade.Id,
            (person, grade) => new
            {
                person.Name,
                grade.GradeLetter
            });

        Console.WriteLine("\nJoined result:");
        foreach (var result in joinedResult)
        {
            Console.WriteLine($"Name: {result.Name}, Grade: {result.GradeLetter}");
        }

        // Example 5: Join Typed
        IEnumerable<GradePerson> joinedTypedResult = people.Join(grades,
            person => person.Id,
            grade => grade.Id,
            (person, grade) => new GradePerson
            {
                Name = person.Name,
                GradeLetter = grade.GradeLetter
            });

        Console.WriteLine("\nJoined Typed result:");
        foreach (var result in joinedTypedResult)
        {
            Console.WriteLine($"Name: {result.Name}, Grade: {result.GradeLetter}");
        }
    }
}
