namespace ScottsPizzaFactory.DataAccess.Models
{
    public class PizzaTopping
    {
        public PizzaTopping(string toppingName)
        {
            ToppingName = toppingName;
            CookingTime = toppingName.Replace(" ", "").Length * 100;
        }
        public string ToppingName { get; set; }
        public int CookingTime { get; set; }
    }
}
