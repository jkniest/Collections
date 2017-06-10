using System;
using Collections;
using NUnit.Framework;

namespace CollectionsTest
{
    [TestFixture]
    public class MedianTests
    {
        [Test]
        public void it_can_return_the_median_of_a_float_collection()
        {
            // Given: A collection with three floats
            var collection = new Collection<float>(1.6f, 2.5f, 10f);
               
            // When: We fetch the median value 
            var median = collection.Median();
            
            // Then: The result should be 2.5
            Assert.AreEqual(2.5f, median);
            
            // Given: A new float value is added
            collection.Add(3.4f);
            
            // When: We fetch the new median value
            median = collection.Median();
            
            // Then: The result should be 6.25
            Assert.AreEqual(6.25f, median);
        }
        
        [Test]
        public void it_can_return_the_median_of_a_int_collection()
        {
            // Given: A collection with three integers
            var collection = new Collection<int>(10, 20, 30);
            
            // When: We fetch the median value 
            var median = collection.Median();
            
            // Then: The result should be 20
            Assert.AreEqual(20, median);
            
            // Given: A new integer is added
            collection.Add(33);
            
            // When: We fetch the new median value
            median = collection.Median();
            
            // Then: The result should be 25
            Assert.AreEqual(25, median);
        }
        
        [Test]
        public void it_can_return_the_median_of_a_double_collection()
        {
            // Given: A collection with three doubles
            var collection = new Collection<double>(1.6, 2.5, 10);
            
            // When: We fetch the median value 
            var median = collection.Median();

            // Then: The result should be 2.5
            Assert.AreEqual(2.5, median);
            
            // Given: A new double is added
            collection.Add(3.4);
            
            // When: We fetch the new median value
            median = collection.Median();
            
            // Then: The result should be 6.25
            Assert.AreEqual(6.25, median);
        }
        
        [Test]
        public void it_can_return_the_median_of_a_long_collection()
        {
            // Given: A collection with three long values
            var collection = new Collection<long>(10, 20, 30);
            
            // When: We fetch the median value 
            var median = collection.Median();
            
            // Then: The result should be 20
            Assert.AreEqual(20, median);
            
            // Given: A new long value is added
            collection.Add(40);
            
            // When: We fetch the new median value
            median = collection.Median();
            
            // Then: The result should be 25
            Assert.AreEqual(25, median);
        }

        [Test]
        public void it_can_return_the_median_value_based_on_an_integer_callback()
        {
            // Given: We have a collection with three persons
            var collection = new Collection<Person>(new Person(10), new Person(20), new Person(30));
            
            // When: We fetch the median age
            var median = collection.Median(person => person.Age);
            
            // Then: The value should be 20
            Assert.AreEqual(20, median);
            
            // Given: Another person is added
            collection.Add(new Person(40));
            
            // When: We fetch the new median age
            median = collection.Median(person => person.Age);
            
            // Then: The value should be 25
            Assert.AreEqual(25, median);
        }
        
        [Test]
        public void it_can_return_the_median_value_based_on_a_float_callback()
        {
            // Given: We have a collection with three persons
            var collection = new Collection<Person>(new Person(10, 1.45f), new Person(45, 1.96f), new Person(36, 1.84f));
            
            // When: We fetch the median height
            var median = collection.Median(person => person.Height);
            
            // Then: The value should be 1.96
            Assert.AreEqual(1.96f, median);
            
            // Given: Another person is added
            collection.Add(new Person(30, 1.55f));
            
            // When: We fetch the new median height
            median = collection.Median(person => person.Height);
            
            // Then: The value should be 1.9
            Assert.IsTrue(Math.Abs(median - 1.9f) <= 0.0005f);
        }
        
        [Test]
         public void it_can_return_the_median_value_based_on_a_double_callback()
         {
             // Given: We have a collection with three streets
             var collection = new Collection<Street>(new Street(105.4), new Street(50.5), new Street(84.4));
             
             // When: We fetch the median length
             var median = collection.Median(street => street.Length);
             
             // Then: The value should be 50.5
             Assert.AreEqual(50.5, median);
             
             // Given: Another street is added
             collection.Add(new Street(3.4));
             
             // When: We fetch the new median length
             median = collection.Median(street => street.Length);
             
             // Then: The value should be 67.45
             Assert.AreEqual(67.45, median);
         }
        
        [Test]
        public void it_can_return_the_median_value_based_on_a_long_callback()
        {
            // Given: We have a collection with three countries
            var collection = new Collection<Country>(new Country(1000000000), new Country(3100000000), new Country(5000000));
            
            // When: We fetch the median population 
            var median = collection.Median(country => country.Population);
            
            // Then: The value should be 310.000.000
            Assert.AreEqual(3100000000, median);
            
            // 3.100.000.000
            //     5.000.000
            
            // Given: A new country is added
            collection.Add(new Country(212000000));
            
            // When: We fetch the new median population
            median = collection.Median(country => country.Population);
            
            // Then: The value should be 1.552.500.000
            Assert.AreEqual(1552500000, median);
        }
    }
}