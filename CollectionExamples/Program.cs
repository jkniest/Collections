﻿using System;
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
            TestFilter();
            TestWhen();
            TestFirst();
            TestImplode();

            Console.ReadKey(true);
        }

        private static void TestReduce()
        {
            // Create a new collection (3 integers: 10, 20, 30)
            var collection = new Collection<int>(10, 20, 30);

            // Reduce this collection to a single integer value (basically sum)
            var result = collection.Reduce((value, item) => value + item, 0);

            // Print the result to the console
            Console.WriteLine("Reduce result: " + result);
        }

        private static void TestAll()
        {
            // Create a new collection (3 integers: 10, 20, 30)
            var collection = new Collection<int>(10, 20, 30);

            // Get all items (as an array)
            var result = collection.All();

            // Print the first item to the console
            Console.WriteLine("All result: " + result[0]);
        }

        private static void TestAvg()
        {
            // Create a new collection (3 persons)
            var collection = new Collection<Person>(new Person(10), new Person(45), new Person(36));

            // Calculate the average age
            var result = collection.Avg(person => person.Age);

            // Print the result to the console
            Console.WriteLine("Avg result: " + result);
        }

        private static void TestMedian()
        {
            // Create a new collection (3 persons)
            var collection = new Collection<Person>(new Person(10), new Person(45), new Person(36));

            // Calculate the median age
            var result = collection.Median(person => person.Age);

            // Print the result to the console
            Console.WriteLine("Median result: " + result);
        }

        private static void TestMode()
        {
            // Create a new collection (6 integers)
            var collection = new Collection<int>(1, 1, 4, 1, 3, 3);

            // Calculate the mode value
            var result = collection.Mode();

            // Print rhe result to the console
            Console.WriteLine("Mode result: " + result);
        }

        private static void TestDiff()
        {
            // Create a new collection (3 integers)
            var collection = new Collection<int>(10, 20, 30);

            // Create another collection (3 integers)
            var other = new Collection<int>(10, 30, 40);

            // Calculate the diff collection
            var result = collection.Diff(other);

            // Print the result to the console
            Console.WriteLine("Diff result: " + result);
        }

        private static void TestEach()
        {
            // Create a new collection (3 persons)
            var collection = new Collection<Person>(new Person(10), new Person(45), new Person(36));

            // Iterate through each item and double their age
            var result = collection.Each(person => person.Age = person.Age * 2);

            // Print the result to the console
            Console.WriteLine("Each result: " + result);
        }

        private static void TestEvery()
        {
            // Create a new collection (3 integers)
            var collection = new Collection<int>(10, 20, 30);

            // Test if every item is greater than 8
            var result = collection.Every(item => item > 8);

            // Print the result to the console
            Console.WriteLine("Every result: " + result);
        }

        private static void TestFilter()
        {
            // Create a new collection (3 integers)
            var collection = new Collection<int>(10, 20, 30);

            // Filter by every item that is greater than 15
            var result = collection.Filter(item => item > 15);

            // Print the result to the console
            Console.WriteLine("Filter result: " + result);
        }

        private static void TestWhen()
        {
            // Create a new collection (3 integers)
            var collection = new Collection<int>(10, 20, 30);

            // Add another item to the collection if the first argument is true
            var result = collection.When(true, col =>
            {
                col.Add(40);
                return col;
            });

            // Print the result to the console
            Console.WriteLine("When result: " + result);
        }
        
        private static void TestFirst()
        {
            // Create a new collection (3 integers)
            var collection = new Collection<int>(10, 20, 30);

            // Fetch the first item
            var result = collection.First();

            // Print the result to the console
            Console.WriteLine("First result: " + result);
        }
        
        private static void TestImplode()
        {
            // Create a new collection (3 integers)
            var collection = new Collection<int>(10, 20, 30);

            // Implode all items
            var result = collection.Implode();

            // Print the result to the console
            Console.WriteLine("Implode result: " + result);
        }
    }
}
