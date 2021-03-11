using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using ScottsPizzaFactory.DataAccess;
using ScottsPizzaFactory.DataAccess.Factory;
using ScottsPizzaFactory.DataAccess.Models;
using Xunit;

namespace ScottsPizzaFactory.Tests
{
    public class PizzaFactoryTests
    {
        private readonly PizzaFactory _pizzaFactory;
        private readonly Mock<ILogger<PizzaFactory>> _mockLogger = new Mock<ILogger<PizzaFactory>>();
        private readonly Mock<IConfiguration> _mockConfig = new Mock<IConfiguration>();
        private readonly Mock<ITimer> _mockTimer = new Mock<ITimer>();
        private readonly Mock<IWriter> _mockWriter = new Mock<IWriter>();

        public PizzaFactoryTests()
        {
            _pizzaFactory = new PizzaFactory(_mockLogger.Object, _mockConfig.Object, _mockTimer.Object, _mockWriter.Object);
        }

        //[Theory]
        //[ClassData(typeof(PizzaTestData))]
        //public void Should_not_cook_and_log_if_invalid(bool expected, string message)
        //{
        //    // Arrange
        //    _mockLogger.Setup(m => m.LogInformation(It.IsAny<string>()));
        //    //Act
        //    var result = _pizzaFactory.Run();
        //    // Assert
        //    Assert.Equal(expected, result);
        //    _mockLogger.Verify(m => m.LogInformation(message));
        //}

        //[Fact]
        //public void Should_cook_and_log_a_valid_pizza()
        //{
        //    // Arrange
        //    var baseCookingTime = 10;
        //    var pizza = new Pizza(new PizzaBase("Base", 2), new PizzaTopping("Topping"));
        //    //_mockConfig.SetupGet(m => m.BaseCookingTime).Returns(baseCookingTime);
        //    _mockLogger.Setup(m => m.LogInformation(It.IsAny<string>()));
        //    _mockTimer.Setup(m => m.Delay(It.IsAny<int>()));
        //    //Act
        //    bool result = _pizzaFactory.Run();
        //    // Assert
        //    Assert.True(result);
        //    Assert.True(pizza.Cooked);
        //    var duration = (int)(pizza.PizzaBase.Multiplier * baseCookingTime) +
        //                   (pizza.PizzaTopping.CookingTime * 100);
        //    _mockLogger.Verify(m => m.LogInformation($"Cooking {pizza.GetDescription()} for {duration}ms"));
        //    _mockLogger.Verify(m => m.LogInformation($"Cooked {pizza.GetDescription()}"));
        //    _mockTimer.Verify(m => m.Delay(duration));
        //}
    }

    class PizzaTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var cookedPizza = new Pizza(new PizzaBase("any", 1), new PizzaTopping("any")) { Cooked = true };
            yield return new object[] { new Pizza(null, new PizzaTopping("any")), false, "Can't cook pizza there was no base" };
            yield return new object[] { new Pizza(new PizzaBase("any", 1), null), false, "Can't cook any there was no topping" };
            yield return new object[] { cookedPizza, false, $"Can't cook {cookedPizza.GetDescription()} again" };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
