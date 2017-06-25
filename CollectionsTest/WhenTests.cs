using Collections;
using NUnit.Framework;

namespace CollectionsTest
{
    [TestFixture]
    public class WhenTests
    {
        [Test]
        public void it_runs_a_callable_if_the_first_argument_is_true()
        {
            // Given: A collection with three integers
            var collection = new Collection<int>(10, 20, 30);
            
            // When: We run the 'when' method with the first parameters `true`
            var result = collection.When(true, col =>
            {
                col.Add(40);
                return col;
            });
            
            // Then: The result should have four items
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(40, result[3]);
        }
        
        [Test]
        public void it_skips_a_callable_if_the_first_argument_is_false()
        {
            // Given: A collection with three integers
            var collection = new Collection<int>(10, 20, 30);
            
            // When: We run the 'when' method with the first parameter `false`
            var result = collection.When(false, col =>
            {
                col.Add(40);
                return col;
            });
            
            // Then: The result should have three items
            Assert.AreEqual(3, result.Count);
        }
    }
}
