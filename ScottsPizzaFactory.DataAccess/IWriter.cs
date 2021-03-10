namespace ScottsPizzaFactory.DataAccess
{
    public interface IWriter
    {
        void Write(string data);
        void Close();
    }
}