namespace P11_CatLady
{
    public class StreetExtraordinaire : Cat
    {
        public int decibelsOfMeows;

        public StreetExtraordinaire(string name, int decibelsOfMeows)
            : base(name)
        {
            this.decibelsOfMeows = decibelsOfMeows;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", base.ToString(), this.decibelsOfMeows);
        }
    }
}