using Collections;
using NUnit.Framework;

namespace CollectionsTest
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void it_can_take_an_array_of_items()
        {
            // Given: An array with 3 integers
            var data = new[] {10, 20, 30};
            
            // When: We create a new collection based on the array..
            var collection = new Collection<int>(data);
            
            // Then: The collection should have these items
            Assert.AreEqual(10, collection[0]);
            Assert.AreEqual(20, collection[1]);
            Assert.AreEqual(30, collection[2]);
        }
        
        [Test]
        public void it_can_take_multiple_parameters()
        {
            // When: We create a new collection with three integers
            var collection = new Collection<int>(10, 20, 30);

            // Then: The collection should have these items
            Assert.AreEqual(10, collection[0]);
            Assert.AreEqual(20, collection[1]);
            Assert.AreEqual(30, collection[2]);
        }
    }
}