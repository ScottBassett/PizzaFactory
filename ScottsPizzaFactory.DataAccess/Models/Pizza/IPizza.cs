using ScottsPizzaFactory.DataAccess.Models.Bases;
using ScottsPizzaFactory.DataAccess.Models.Toppings;

namespace ScottsPizzaFactory.DataAccess.Models.Pizza
{
    public interface IPizza
    {
        string PizzaName { get; set; }
        double PizzaCookingTimeInMilliseconds { get; set; }
        PizzaBase PizzaBase { get; set; }
        PizzaTopping PizzaTopping { get; set; }
        double TotalCookingTime { get; }
    }
}