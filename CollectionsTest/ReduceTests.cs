using Collections;
using NUnit.Framework;

namespace CollectionsTest
{
    [TestFixture]
    public class ReduceTests
    {
        [Test]
        public void it_can_reduce_a_collection_to_another_data_type()
        {
            // Given: A collection with four integers
            var collection = new Collection<int>(10, 20, 30);
            
            // When: The reduce method is used to sum all integers
            var result = collection.Reduce((current, item) => current + item, 0);
            
            // Then: The result should be 60
            Assert.AreEqual(60, result);
        }
    }
}