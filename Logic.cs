using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeevollautomat
{
    class Logic
    {
        public void Idle()
        {
            Menu();
        }
        public void Menu()
        {
            DisplayReserve();
            Console.WriteLine("Was möchten Sie?");
            Console.WriteLine("1 - Latte\n2 - Capu\n3 - Espresso\n4 - Schwarz\n5 - Reinigung starten\n6 - Maschine ausschalten"); //alles (inkl auswahl) anzeigen. keine untermenüs
            string choice = Console.ReadLine(); //main
            int choiceAsInt;
            choiceAsInt = int.Parse(choice);

            switch (choiceAsInt)
            {
                case 1:
                    CheckReserve();
                    Sortiment(1);
                    Idle();
                    break;
                case 2:
                    CheckReserve();
                    Sortiment(2);
                    Idle();
                    break;
                case 3:
                    CheckReserve();
                    Sortiment(3);
                    Idle();
                    break;
                case 4:
                    CheckReserve();
                    Sortiment(4);
                    Idle();
                    break;
                case 5:
                    CheckReserve();
                    Reinigung();
                    Idle();
                    break;
                case 6:
                    Shutdown();
                    break;
                default:
                    break;
            }

        }

        public void Sortiment(int choiceAsInt)
        {
            //Console.WriteLine("Wählen Sie ihren Kaffe:");
            //Console.WriteLine("1 - Latte\n2 - Capu\n3 - Espresso\n4 - Schwarz");
            //string choice = Console.ReadLine();
            //int choiceAsInt;
            //choiceAsInt = int.Parse(choice);

            switch (choiceAsInt)
            {
                case 1:
                    Console.WriteLine("Latte wird zubereitet.");
                    Reserve(2, 8, 4);
                    break;
                case 2:
                    Console.WriteLine("Capu wird zubereitet.");
                    Reserve(2, 4, 4);
                    break;
                case 3:
                    Console.WriteLine("Espresso wird zubereitet.");
                    Reserve(4, 0, 3);
                    break;
                case 4:
                    Console.WriteLine("Schwarz wird zubereitet.");
                    Reserve(3, 0, 4);
                    break;
                default:
                    break;
            }
        }
        int coffee = 75; //75
        int milk = 20; //20
        int water = 90; //90
        public void Reserve(int c, int m, int w)
        {
            coffee -= c;
            milk -= m;
            water -= w;
        }
        public void DisplayReserve()
        {
            Console.WriteLine("Reserve: Coffee @ " + coffee + "%, Milk @ " + milk + "%, Water @ " + water + "%");
        }
        public void CheckReserve()
        {
            if (coffee < 2)
            {
                Console.WriteLine("Bitte erst Kaffee nachfüllen.");
                Idle();
            }
            if (milk < 8)
            {
                Console.WriteLine("Bitte erst Milch nachfüllen.");
                Idle();
            }
            if (water < 4)
            {
                Console.WriteLine("Bitte erst Wasser nachfüllen.");
                Idle();
            }
        }
        public void Reinigung()
        {
            Console.WriteLine("Reinigung wird gestartet.");

        }
        public void Shutdown()
        {
            Console.WriteLine("Maschine wird ausgeschalten.");

        }
    }
}
