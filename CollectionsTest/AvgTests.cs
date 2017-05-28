using System;
using System.Linq;
using Collections;
using NUnit.Framework;

namespace CollectionsTest
{
    [TestFixture]
    public class AvgTests
    {
        [Test]
        public void it_can_return_the_average_of_a_float_collection()
        {
            // Given: A collection with three floats
            var collection = new Collection<float>(1.6f, 2.5f, 10f);
            
            // When: We fetch the average value (using avg and average)
            var avg = collection.Avg();
            var average = collection.Average();
            
            // Then: The result should be 4.7
            Assert.IsTrue(avg - 4.7f < 0.0005f);
            Assert.IsTrue(average - 4.7f < 0.0005f);
        }
        
        [Test]
        public void it_can_return_the_average_of_a_int_collection()
        {
            // Given: A collection with three integers
            var collection = new Collection<int>(10, 20, 30);
            
            // When: We fetch the average value (using avg and average)
            var avg = collection.Avg();
            var average = collection.Average();
            
            // Then: The result should be 20
            Assert.AreEqual(20, avg);
            Assert.AreEqual(20, average);
        }
        
        [Test]
        public void it_can_return_the_average_of_a_double_collection()
        {
            // Given: A collection with three doubles
            var collection = new Collection<double>(1.6, 2.5, 10);
            
            // When: We fetch the average value (using avg and average)
            var avg = collection.Avg();
            var average = collection.Average();
            
            // Then: The result should be 4.7
            Assert.IsTrue(avg - 4.7 < 0.0005f);
            Assert.IsTrue(average - 4.7 < 0.0005f);
        }
        
        [Test]
        public void it_can_return_the_average_of_a_long_collection()
        {
            // Given: A collection with three long values
            var collection = new Collection<long>(10, 20, 30);
            
            // When: We fetch the average value (using avg and average)
            var avg = collection.Avg();
            var average = collection.Average();
            
            // Then: The result should be 20
            Assert.AreEqual(20, avg);
            Assert.AreEqual(20, average);
        }

        [Test]
        public void it_can_return_the_average_value_based_on_a_callback()
        {
            // Given: We have a collection with three persons
            var collection = new Collection<Person>(new Person(10), new Person(45), new Person(36));
            
            // When: We fetch the average age (using avg and average)
            var avg = collection.Avg(person => person.Age);
            var average = collection.Average(person => person.Age);
            
            // Then: The average age should be 30
            Assert.AreEqual(30, avg);
            Assert.AreEqual(30, average);
        }
    }
}