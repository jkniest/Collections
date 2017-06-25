using Collections;
using NUnit.Framework;

namespace CollectionsTest
{
    [TestFixture]
    public class FirstTests
    {
        [Test]
        public void it_can_return_the_first_item_of_a_collection()
        {
            // Given: A collection with three integers
            var collection = new Collection<int>(10, 20, 30);

            // When: We fetch the first item
            var item = collection.First();

            // Then: The result should be 10
            Assert.AreEqual(10, item);
        }

        [Test]
        public void it_can_return_the_first_item_that_passes_a_callable()
        {
            // Given: A collection with three integers
            var collection = new Collection<int>(10, 20, 30);

            // When: We fetch the first item that is greater than 15
            var item = collection.First(number => number >= 15);

            // Then: The result should be 20
            Assert.AreEqual(20, item);
        }
    }
}
