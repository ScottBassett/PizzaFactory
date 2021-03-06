namespace ScottsPizzaFactory.DataAccess.Models
{
    public class PizzaBase
    {
        public PizzaBase(string baseName, double multiplier)
        {
            BaseName = baseName;
            Multiplier = multiplier;
        }

        public string BaseName { get; set; }
        public double Multiplier { get; set; }

        public int BaseTimeInMilliseconds = 3000;

        public double CookingTime => BaseTimeInMilliseconds * Multiplier;
    }
}
