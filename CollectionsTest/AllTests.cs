using Collections;
using NUnit.Framework;

namespace CollectionsTest
{
    [TestFixture]
    public class AllTests
    {
        [Test]
        public void it_can_return_all_items_as_an_array()
        {
            // Given: A collection with three integers
            var collection = new Collection<int>(10, 20, 30);
            
            // When: We requets all items
            var items = collection.All();
            
            // Then: We should get an array with the three items
            Assert.AreEqual(10, items[0]);
            Assert.AreEqual(20, items[1]);
            Assert.AreEqual(30, items[2]);
        }
    }
}