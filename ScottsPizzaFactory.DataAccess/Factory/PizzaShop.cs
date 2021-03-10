
namespace ScottsPizzaFactory.DataAccess.Factory
{
    public class PizzaShop
    {
        private readonly IPizzaFactory _factory;

        public PizzaShop(IPizzaFactory factory)
        {
            _factory = factory;
        }

        //public PizzaTopping OrderPizza(string incomingBase)
        //{
        //    var pizzaBase = _factory.CreatePizzaBase(incomingBase);
        //    if (pizzaBase != null)
        //    {
        //        Console.WriteLine($"Your {pizzaBase.Base} ");
        //    }
        //}

    }
}
