namespace ScottsPizzaFactory.DataAccess.Models
{
    public interface IPizza
    {
        //string PizzaName { get; set; }
        //double PizzaCookingTimeInMilliseconds { get; set; }
        //PizzaBase PizzaBase { get; set; }
        //PizzaTopping PizzaTopping { get; set; }
        //double TotalCookingTime { get; }

        PizzaBase PizzaBase { get; set; }
        PizzaTopping PizzaTopping { get; set; }
        bool Cooked { get; set; }
        string GetDescription();
    }
}