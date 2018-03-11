namespace P11_CatLady
{
    public abstract class Cat
    {
        public string name;

        public Cat(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.GetType().Name, this.name);
        }
    }
}