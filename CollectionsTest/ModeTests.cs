using System.IO;
using Collections;
using NUnit.Framework;

namespace CollectionsTest
{
    [TestFixture]
    public class ModeTests
    {
        [Test]
        public void it_can_return_the_median_value_of_some_integers()
        {
            // Given: A collection with six integers
            var collection = new Collection<int>(1, 1, 4, 1, 3, 3); 
            
            // When: We fetch the mode value
            var mode = collection.Mode();
            
            // Then: We should get a collection with only the item '1'
            Assert.AreEqual(1, mode.Count);
            Assert.AreEqual(1, mode[0]);  
        }

        [Test]
        public void it_can_return_multiple_mode_values_if_needed()
        {
            // Given: A collection with two mode values
            var collection = new Collection<int>(2, 2, 2, 3, 3, 3, 4);
            
            // When: We fetch the mode value
            var mode = collection.Mode();
            
            // Then: We should get a collection with two items (2 & 3)
            Assert.AreEqual(2, mode.Count);
            Assert.Contains(2, mode);
            Assert.Contains(3, mode);
        }
    }
}