using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeevollautomat
{
    class Logic
    {
        public void ButtonAuswahl()
        {
            Console.WriteLine("Was möchten Sie tun?");
            Console.WriteLine("1 - Kaffe auswählen\n2 - Reinigung starten\n3 - Maschine ausschalten"); //alles (inkl auswahl) anzeigen. keine untermenüs
            string choice = Console.ReadLine(); //main
            int choiceAsInt;
            choiceAsInt = int.Parse(choice);

            switch (choiceAsInt)
            {
                case 1:
                    Auswahl();
                    break;
                case 2:
                    Console.WriteLine("Reinigung wird gestartet.");
                    Reinigung();
                    break;
                case 3:
                    Console.WriteLine("Mschine wird ausgeschalten.");
                    Shutdown();
                    break;
                case 4:
                    Console.WriteLine("Schwarz wird zubereitet.");
                    break;
                default:
                    break;
            }
        }

        public void Auswahl()
        {
            Console.WriteLine("Wählen Sie ihren Kaffe:");
            Console.WriteLine("1 - Latte\n2 - Capu\n3 - Espresso\n4 - Schwarz");
            string choice = Console.ReadLine();
            int choiceAsInt;
            choiceAsInt = int.Parse(choice);

            switch (choiceAsInt)
            {
                case 1:
                    Console.WriteLine("Latte wird zubereitet.");
                    break;
                case 2:
                    Console.WriteLine("Capu wird zubereitet.");
                    break;
                case 3:
                    Console.WriteLine("Espresso wird zubereitet.");
                    break;
                case 4:
                    Console.WriteLine("Schwarz wird zubereitet.");
                    break;
                default:
                    break;
            }
        }
        public void Reinigung()
        {

        }
        public void Shutdown()
        {

        }
    }
}
