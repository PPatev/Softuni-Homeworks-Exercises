namespace P11_CatLady
{
    public class Siamese : Cat
    {
        public int earSize;

        public Siamese(string name, int earSize)
            : base(name)
        {
            this.earSize = earSize;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", base.ToString(), this.earSize);
        }
    }
}