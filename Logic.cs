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
            Console.WriteLine("1 - Latte\n2 - Capu\n3 - Espresso\n4 - Schwarz\n5 - Reinigung starten\n6 - Maschine ausschalten");
            string choice = Console.ReadLine(); //main
            int choiceAsInt;
            choiceAsInt = int.Parse(choice);
            //CheckReserve();
            Sortiment(choiceAsInt);
            Idle();
        }
        public void Sortiment(int choiceAsInt)
        {
            switch (choiceAsInt)
            {
                case 1:
                    CheckReserve(2,8,4);
                    break;
                case 2:
                    CheckReserve(2,4,4);
                    break;
                case 3:
                    CheckReserve(4,0,3);
                    break;
                case 4:
                    CheckReserve(3, 0, 4);
                    break;
                case 5:
                    Reinigung();
                    break;
                case 6:
                    Shutdown();
                    break;
                default:
                    break;
            }
        }
        int coffee = 1; //75
        int milk = 1; //20
        int water = 90; //90
        public void Reserve(int c, int m, int w)
        {
            coffee -= c;
            milk -= m;
            water -= w;
            
            //Recipes
            //Latte: 2, 8, 4
            //Capu: 2, 4, 4
            //Espresso: 4, 0, 3
            //Schwarz: 3, 0, 4
        }
        public void CheckReserve(int c, int m, int w)
        {
            switch ((c, m, w))
            {
                case (2, 8, 4):
                    if (coffee >= 2 && milk >=8 && water >= 4)
                    {
                        Console.WriteLine("Latte wird zubereitet.");
                        Reserve(c, m, w);
                    }
                    else if (coffee < 2 && milk >=8 && water >= 4)
                    {
                        Console.WriteLine("Bitte erst Kaffee nachfüllen.");
                        Idle();
                    }
                    else if (coffee >= 2 && milk < 8 && water >= 4)
                    {
                        Console.WriteLine("Bitte erst Milch nachfüllen.");
                        Idle();
                    }
                    else
                    {
                        Console.WriteLine("Bitte erst Wasser nachfüllen.");
                        Idle();
                    }
                    break;
                case (2, 4, 4):
                    if (coffee >= 2 && milk >= 4 && water >= 4)
                    {
                        Console.WriteLine("Capu wird zubereitet.");
                        Reserve(c, m, w);
                    }
                    else if (coffee < 2 && milk >= 4 && water >= 4)
                    {
                        Console.WriteLine("Bitte erst Kaffee nachfüllen.");
                        Idle();
                    }
                    else if (coffee >= 2 && milk < 4 && water >= 4)
                    {
                        Console.WriteLine("Bitte erst Milch nachfüllen.");
                        Idle();
                    }
                    else
                    {
                        Console.WriteLine("Bitte erst Wasser nachfüllen.");
                        Idle();
                    }
                    break;
                case (4, 0, 3):
                    if (coffee >= 3 && water >= 4)
                    {
                        Console.WriteLine("Schwarz wird zubereitet.");
                        Reserve(c, m, w);
                    }
                    else if (coffee >= 3 && water < 3)
                    {
                        Console.WriteLine("Bitte erst Wasser nachfüllen.");
                        Idle();
                    }
                    else
                    {
                        Console.WriteLine("Bitte erst Kaffee nachfüllen.");
                        Idle();
                    }
                    break;
                    ;
                case (3, 0, 4):
                    if (coffee >= 3 && water >= 4)
                    {
                        Console.WriteLine("Schwarz wird zubereitet.");
                        Reserve(c, m, w);
                    }
                    else if (coffee >= 3 && water < 4)
                    {
                        Console.WriteLine("Bitte erst Wasser nachfüllen.");
                        Idle();
                    }
                    else
                    {
                        Console.WriteLine("Bitte erst Kaffee nachfüllen.");
                        Idle();
                    }
                    break;

                default:
                    break;
            }
        }
        public void DisplayReserve()
                {
                    Console.WriteLine("Reserve: Coffee @ " + coffee + "%, Milk @ " + milk + "%, Water @ " + water + "%");
                }
        public void Reinigung()
        {
            Console.WriteLine("Reinigung wird gestartet.");
            Idle();
        }
        public void Shutdown()
        {
            Console.WriteLine("Maschine wird ausgeschalten.");
        }
    }
}
