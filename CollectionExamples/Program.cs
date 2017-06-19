using System;
using CollectionExamples.Helpers;
using Collections;

namespace CollectionExamples
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TestReduce();
            TestAll();
            TestAvg();
            TestMedian();
            TestMode();
            TestDiff();
            TestEach();
            TestEvery();

            Console.ReadKey(true);
        }

        private static void TestReduce()
        {
            // Create a new collection with three integer values (10, 20, 30)
            var collection = new Collection<int>(10, 20, 30);
            
            // Reduce this collection to a single integer value (sum)
            var result = collection.Reduce((value, item) => value + item, 0);
            
            // Print the result to the console
            Console.WriteLine("Reduce result: " + result);
        }
        
        private static void TestAll()
        {
            // Create a new collection with three integer values (10, 20, 30)
            var collection = new Collection<int>(10, 20, 30);
            
            // Request all items
            var result = collection.All();
            
            // Print the first item to the console
            Console.WriteLine("All result: " + result[0]);
        }

        private static void TestAvg()
        {
            // Create a new collection with three persons (the first argument is their age)
            var collection = new Collection<Person>(new Person(10), new Person(45), new Person(36));
            
            // Calculate the average age
            var result = collection.Avg(person => person.Age);
            
            // Print the result to the console
            Console.WriteLine("Avg result: " + result);
        }

        private static void TestMedian()
        {
            // Create a new collection with three persons (the first argument is their age)
            var collection = new Collection<Person>(new Person(10), new Person(45), new Person(36));
            
            // Calculate the median age
            var result = collection.Median(person => person.Age);
            
            // Print the result to the console
            Console.WriteLine("Median result: " + result);
        }

        private static void TestMode()
        {
            // Create a new collection with six integers
            var collection = new Collection<int>(1, 1, 4, 1, 3, 3);
            
            // Calculate the mode value
            var result = collection.Mode();
            
            // Print rhe result to the console
            Console.WriteLine("Mode result: " + result);
        }

        private static void TestDiff()
        {
            // Create a new collection with three integers
            var collection = new Collection<int>(10, 20, 30);
            
            // Create another collection with three integers
            var other = new Collection<int>(10, 30, 40);
            
            // Calculate the diff collection
            var result = collection.Diff(other);
            
            // Print the result to the console
            Console.WriteLine("Diff result: " + result);
        }

        private static void TestEach()
        {
            // Create a new collection with three persons (the first argument is their age)
            var collection = new Collection<Person>(new Person(10), new Person(45), new Person(36));
            
            // Iterate through each item and double their age
            var result = collection.Each(person => person.Age = person.Age * 2);
            
            // Print the result to the console
            Console.WriteLine("Each result: " + result); 
        }

        private static void TestEvery()
        {
            // Create a new collection with three integers
            var collection = new Collection<int>(10, 20, 30);
            
            // Test if every item is greater than 8
            var result = collection.Every(item => item > 8);
            
            // Print the result to the console
            Console.WriteLine("Every result: " + result);
        }
    }
}
