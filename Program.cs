using System;

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
            
            //längere balken
            //falsche eingabe durch if abfangen IN PROGRESS
            //dictionary ()key(enum zb) value(c m w) store
            
            Console.WriteLine("(X_X)");
        }
    }
}
