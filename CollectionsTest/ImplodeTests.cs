using Collections;
using NUnit.Framework;

namespace CollectionsTest
{
    [TestFixture]
    public class ImplodeTests
    {
        [Test]
        public void it_can_implode_multiple_items()
        {
            // Given: A collection with three integers
            var collection = new Collection<int>(10, 20, 30);

            // When: We implode the collection
            var result = collection.Implode(" - ");

            // Then: The result should be: "10 - 20 - 30"
            Assert.AreEqual("10 - 20 - 30", result);
        }

        [Test]
        public void it_can_implode_an_empty_collection()
        {
            // Given: A collection with zero items
            var collection = new Collection<int>();

            // When: We implode the collection
            var result = collection.Implode(" - ");

            // Then: The result should be an empty string
            Assert.AreEqual(string.Empty, result);
        }
    }
}
