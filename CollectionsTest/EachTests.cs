using Collections;
using NUnit.Framework;

namespace CollectionsTest
{
    [TestFixture]
    public class EachTests
    {
        [Test]
        public void it_can_iterate_through_each_item()
        {
            // Given: A collection with three persons
            var collection = new Collection<Person>(new Person(10), new Person(18), new Person(63));
            
            // When: We iterate through each item and double their age
            collection.Each(item =>
            {
                item.Age = item.Age * 2;
            }); 
            
            // Then: The ages should be 20, 36 and 126
            Assert.AreEqual(20, collection[0].Age);
            Assert.AreEqual(36, collection[1].Age);
            Assert.AreEqual(126, collection[2].Age);
        }
    }
}