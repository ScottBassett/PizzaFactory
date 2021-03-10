namespace ScottsPizzaFactory.DataAccess
{
    public class Timer : ITimer
    {
        public void Delay(int durationInMilliseconds)
        {
            System.Threading.Thread.Sleep(durationInMilliseconds);
        }
    }
}
