using System;

namespace Kaffeevollautomat
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new();
            while (true)
            {
                logic.Menu();
            }
            //fix idle/menu stack FIXED
            //readkey IMPLEMENTED
            //längere balken
            //blinking cursor off FIXED
            //clearscreen nach zubereitung IMPLEMENTED
            //falsche eingabe durch if abfangen IN PROGRESS
            //ascii art (logo) DONE
            Console.WriteLine("");
        }
    }
}
