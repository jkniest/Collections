using System.Collections.Generic;
using Collections;
using NUnit.Framework;

namespace CollectionsTest
{
    [TestFixture]
    public class DiffTests
    {
        [Test]
        public void it_can_return_the_diff_of_two_collections()
        {
            // Given: A collection with three integers (10, 20, 30)
            var collection = new Collection<int>(10, 20, 30);
            
            // Given: Another collection with three integers (10, 30, 40)
            var other = new Collection<int>(10, 30, 40);
            
            // When: We fetch the diff
            var diff = collection.Diff(other);
            
            // Then: The output should contain 20
            Assert.AreEqual(1, diff.Count);
            Assert.Contains(20, diff);
        }

        [Test]
        public void it_can_diff_against_an_array()
        {
            // Given: A collection with three integers (10, 20, 30)
            var collection = new Collection<int>(10, 20, 30);
            
            // Given: An array with three integers (10, 30, 40)
            var other = new[] {10, 30, 40};
            
            // When: We fetch the diff
            var diff = collection.Diff(other);
            
            // Then: The output should contain 20
            Assert.AreEqual(1, diff.Count);
            Assert.Contains(20, diff);
        }
        
        [Test]
        public void it_can_diff_against_a_list()
        {
            // Given: A collection with three integers (10, 20, 30)
            var collection = new Collection<int>(10, 20, 30);
            
            // Given: An list with three integers (10, 30, 40)
            var other = new List<int> {10, 30, 40};
            
            // When: We fetch the diff
            var diff = collection.Diff(other);
            
            // Then: The output should contain 20
            Assert.AreEqual(1, diff.Count);
            Assert.Contains(20, diff);
        }
    }
}