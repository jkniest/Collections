namespace CollectionExamples.Helpers
{
    public class Person
    {
        public int Age { get; internal set; }
        
        public Person(int age)
        {
            Age = age;
        }

        public override string ToString()
        {
            return string.Format("Person({0})", Age);
        }
    }
}