using Collections;
using NUnit.Framework;

namespace CollectionsTest
{
    [TestFixture]
    public class DumpTests
    {
        [Test]
        public void it_returns_the_correct_string()
        {
            // Given: A collection with three integers
            var collection = new Collection<int>(10, 20, 30);
            
            // When: We get the string version of the collection
            var str = collection.ToString(); 
            
            // Then: The result should be: Collection<int> (3) [10, 20, 30]
            Assert.AreEqual("Collection<System.Int32> (3) [10, 20, 30]", str);
        }

        [Test]
        public void it_returns_the_collection_itself()
        {
            // Given: A collection with two integers
            var collection = new Collection<int>(10, 20);
            
            // When: We dump the collection
            var returned = collection.Dump();
            
            // Then: The returned collection should be the same
            Assert.AreEqual(collection, returned); 
        }
    }
}