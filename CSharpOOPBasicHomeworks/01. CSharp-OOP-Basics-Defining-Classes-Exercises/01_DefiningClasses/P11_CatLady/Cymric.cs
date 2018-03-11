namespace P11_CatLady
{
    public class Cymric : Cat
    {
        public double furLength;

        public Cymric(string name, double furLength)
            : base(name)
        {
            this.furLength = furLength;
        }

        public override string ToString()
        {
            return string.Format("{0} {1:F2}", base.ToString(), this.furLength);
        }
    }
}