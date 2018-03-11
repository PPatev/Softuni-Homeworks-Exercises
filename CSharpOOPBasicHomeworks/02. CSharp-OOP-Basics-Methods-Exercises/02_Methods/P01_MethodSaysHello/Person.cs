namespace P01_MethodSaysHello
{
    public class Person
    {
        public string name;

        public Person(string name)
        {
            this.name = name;
        }

        public string SayHello()
        {
            return string.Format("{0} says \"Hello\"!", this.name);
        }
    }
}