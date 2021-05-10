using System;
using System.IO;
using System.Xml.Serialization;

namespace Kaffeevollautomat
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new();
            Data data = new();
            data.Number = 69;
            data.Text = "Hello World";

            XmlSerializer xml = new(typeof(Data));
            using (StreamWriter writer = new ("log.xml"))
            {
                xml.Serialize(writer, data);
            }

            do
            {
                logic.Menu();
            } while (logic.KeepRunning);
            
            //TODO: longer bars
            //TODO: function1 - write reserve/containercontent into data
            //TODO: function2 - read reser/containercontent from data
            Console.WriteLine("(X_X)");
        }
    }
}
