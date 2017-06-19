using Collections;
using NUnit.Framework;

namespace CollectionsTest
{
    [TestFixture]
    public class EveryTest
    {
        [Test]
        public void it_can_return_true_if_every_items_passes_a_test()
        {
            // Given: A collection with three integers
            var collection = new Collection<int>(10, 20, 30);
            
            // When: We test if every item is greater than 5
            var isGreater = collection.Every(item => item >= 5);
            
            // Then: The result should be true
            Assert.IsTrue(isGreater);
        }
        
        [Test]
        public void it_can_return_false_if_one_or_more_items_does_not_pass_a_test()
        {
            // Given: A collection with three integers
            var collection = new Collection<int>(10, 20, 30);
            
            // When: We test if every item is greater than 15
            var isGreater = collection.Every(item => item >= 15);
            
            // Then: The result should be false
            Assert.IsFalse(isGreater);
        }
    }
}