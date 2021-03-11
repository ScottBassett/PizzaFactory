using System.IO;

namespace ScottsPizzaFactory.DataAccess
{
    public class Writer : IWriter
    {
        private readonly StreamWriter _streamWriter;
        private readonly string fileName = "C:\\Temp\\PizzaList.txt";

        public Writer()
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            FileStream fileStream = new FileStream(fileName, FileMode.Create);
            _streamWriter = new StreamWriter(fileStream);
        }
        public void Write(string data) => _streamWriter.WriteLine(data);
        public void Close()
        {
            _streamWriter.Close();
        }
    }
}
