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
            Console.WriteLine("\nWas möchten Sie?");
            Console.WriteLine("1 - Latte\n2 - Capu\n3 - Espresso\n4 - Schwarz\n_________________________\n5 - Reinigung starten\n6 - Maschine ausschalten");
            string choice = Console.ReadLine(); //main //but why?
            int choiceAsInt;
            choiceAsInt = int.Parse(choice);
            Sortiment(choiceAsInt);
            Idle();
        }
        public void Sortiment(int choiceAsInt)
        {
            switch (choiceAsInt)
            {
                case 1:
                    CheckReserve(20,60,140);
                    break;
                case 2:
                    CheckReserve(25,20,180);
                    break;
                case 3:
                    CheckReserve(30,0,80);
                    break;
                case 4:
                    CheckReserve(20, 0, 200);
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
        int coffee = 1000;
        int milk = 1000;
        int water = 2000;
        public void Reserve(int c, int m, int w)
        {
            coffee -= c;
            milk -= m;
            water -= w;
            
            //Recipes
            //Latte: 20g, 60ml, 140ml
            //Capu: 25g, 20ml, 180ml
            //Espresso: 30g, 0, 80ml
            //Schwarz: 20g, 0, 200ml
        }
        public void CheckReserve(int c, int m, int w)
        {
            switch ((c, m, w))
            {
                case (20, 60, 140): //Latte
                    if (coffee >= 20 && milk >=60 && water >= 140)
                    {
                        Console.WriteLine("Latte wird zubereitet.");
                        Reserve(c, m, w);
                    }
                    else if (coffee < 20 && milk >=60 && water >= 140)
                    {
                        Console.WriteLine("Bitte erst Kaffee nachfüllen.");
                        Idle();
                    }
                    else if (coffee >= 20 && milk < 60 && water >= 140)
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
                case (25, 20, 180): //Capu
                    if (coffee >= 25 && milk >= 20 && water >= 180)
                    {
                        Console.WriteLine("Capu wird zubereitet.");
                        Reserve(c, m, w);
                    }
                    else if (coffee < 25 && milk >= 20 && water >= 180)
                    {
                        Console.WriteLine("Bitte erst Kaffee nachfüllen.");
                        Idle();
                    }
                    else if (coffee >= 25 && milk < 20 && water >= 180)
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
                case (30, 0, 80): //Espresso
                    if (coffee >= 30 && water >= 80)
                    {
                        Console.WriteLine("Espresso wird zubereitet.");
                        Reserve(c, m, w);
                    }
                    else if (coffee >= 30 && water < 80)
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
                case (20, 0, 200): //Schwarz
                    if (coffee >= 20 && water >= 200)
                    {
                        Console.WriteLine("Schwarz wird zubereitet.");
                        Reserve(c, m, w);
                    }
                    else if (coffee >= 20 && water < 200)
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
                    Console.WriteLine("\nReserve: Coffee @ " + coffee/10 + "%, Milk @ " + milk/10 + "%, Water @ " + water/20 + "%");
                    Console.WriteLine("Reserve: Coffee @ " + coffee + "g, Milk @ " + milk + "ml, Water @ " + water + "ml");

        }
        public void Reinigung()
        {
            if (water >= 500)
            {
                Console.WriteLine("Reinigung wird gestartet.");
                Idle(); 
            }
            else
            {
                Console.WriteLine("Bitte erst Wasser nachfüllen.");
                Idle();
            }
        }
        public void Shutdown()
        {
            Console.WriteLine("Maschine wird ausgeschalten.");
            return;
        }
    }
}
