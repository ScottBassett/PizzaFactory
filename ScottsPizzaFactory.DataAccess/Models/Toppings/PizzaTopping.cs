namespace ScottsPizzaFactory.DataAccess.Models.Toppings
{
    public abstract class PizzaTopping
    {
        public string ToppingName { get; set; }
        public int CookingTime => ToppingName.Length * 100;
    }



    //public class PizzaTopping
    //{
    //    public PizzaTopping(string toppingName)
    //    {
    //        ToppingName = toppingName;
    //        CookingTime = toppingName.Replace(" ", "").Length;
    //    }

    //    public string ToppingName { get; set; }
    //    public int CookingTime { get; set; }
    //}
}
