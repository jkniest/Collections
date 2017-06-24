using Collections;
using NUnit.Framework;

namespace CollectionsTest
{
    [TestFixture]
    public class FilterTests
    {
        [Test]
        public void it_can_fitler_a_given_collection()
        {
            // Given: A collection with three integers
            var collection = new Collection<int>(10, 20, 30);

            // When: We filter the collection for every item that is greater than 15
            var filtered = collection.Filter(item => item >= 15);
            
            // Then: The filteres collection should contain two items (20 & 30)
            Assert.AreEqual(2, filtered.Count);
            Assert.AreEqual(20, filtered[0]);
            Assert.AreEqual(30, filtered[1]);
        }
    }
}
