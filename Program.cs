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

            do
            {
                logic.Menu();
            } while (logic.KeepRunning);

            Console.WriteLine("(X_X)");
        }
    }
}