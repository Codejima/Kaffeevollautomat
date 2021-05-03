using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kaffeevollautomat
{
    class Logic
    {
        UI ui = new();
        
        public void Menu()
        {
            Console.CursorVisible = false;
            ui.Logo();
            DisplayReserve();
            
            Console.WriteLine("\nWas möchten Sie?");
            Console.WriteLine("1 - Latte macchiato\n2 - Cappuccino\n3 - Espresso\n4 - Schwarz\n_________________________\n5 - Reinigung starten\n6 - Maschine ausschalten\n");
            
            Sortiment(Console.ReadKey(true).Key);
        }
        public void Sortiment(ConsoleKey choice)
        {
            switch (choice)
            {
                case ConsoleKey.D1:
                    CheckReserve(20,60,140);
                    break;
                case ConsoleKey.D2:
                    CheckReserve(25,20,180);
                    break;
                case ConsoleKey.D3:
                    CheckReserve(30,0,80);
                    break;
                case ConsoleKey.D4:
                    CheckReserve(20, 0, 200);
                    break;
                case ConsoleKey.D5:
                    Reinigung();
                    break;
                case ConsoleKey.D6:
                    Shutdown();
                    break;
                default:
                    Console.WriteLine("falsche taste boy");
                    //TODO: add twirl
                    break;
            }
        }
        int coffee = 800; //800 g
        int milk = 100; //1000 ml
        int water = 2000; //2000 ml
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
                        Console.WriteLine("Latte macchiato wird zubereitet.");
                        Reserve(c, m, w);
                        ui.ProgressBar();
                        Console.WriteLine("Latte macchiato ist fertig. Smacznego!");
                        Thread.Sleep(5000);
                        Console.Clear();
                    }
                    else if (coffee < 20 && milk >=60 && water >= 140)
                    {
                        Console.WriteLine("Bitte erst Kaffee nachfüllen.");
                        Thread.Sleep(5000);
                        Console.Clear();
                        return;
                    }
                    else if (coffee >= 20 && milk < 60 && water >= 140)
                    {
                        Console.WriteLine("Bitte erst Milch nachfüllen.");
                        Thread.Sleep(5000);
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Bitte erst Wasser nachfüllen.");
                        Thread.Sleep(5000);
                        Console.Clear();
                        return;
                    }
                    break;
                case (25, 20, 180): //Capu
                    if (coffee >= 25 && milk >= 20 && water >= 180)
                    {
                        Console.WriteLine("Cappuccino wird zubereitet.");
                        Reserve(c, m, w);
                        ui.ProgressBar();
                        Console.WriteLine("Cappuccino ist fertig. Smacznego!");
                        Thread.Sleep(5000);
                        Console.Clear();
                    }
                    else if (coffee < 25 && milk >= 20 && water >= 180)
                    {
                        Console.WriteLine("Bitte erst Kaffee nachfüllen.");
                        Thread.Sleep(5000);
                        Console.Clear();
                        return;
                    }
                    else if (coffee >= 25 && milk < 20 && water >= 180)
                    {
                        Console.WriteLine("Bitte erst Milch nachfüllen.");
                        Thread.Sleep(5000);
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Bitte erst Wasser nachfüllen.");
                        Thread.Sleep(5000);
                        Console.Clear();
                        return;
                    }
                    break;
                case (30, 0, 80): //Espresso
                    if (coffee >= 30 && water >= 80)
                    {
                        Console.WriteLine("Espresso wird zubereitet.");
                        Reserve(c, m, w);
                        ui.ProgressBar();
                        Console.WriteLine("Espresso ist fertig. Smacznego!");
                        Thread.Sleep(5000);
                        Console.Clear();
                    }
                    else if (coffee >= 30 && water < 80)
                    {
                        Console.WriteLine("Bitte erst Wasser nachfüllen.");
                        Thread.Sleep(5000);
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Bitte erst Kaffee nachfüllen.");
                        Thread.Sleep(5000);
                        Console.Clear();
                        return;
                    }
                    break;
                    ;
                case (20, 0, 200): //Schwarz
                    if (coffee >= 20 && water >= 200)
                    {
                        Console.WriteLine("Kaffee Schwarz wird zubereitet.");
                        Reserve(c, m, w);
                        ui.ProgressBar();
                        Console.WriteLine("Kaffee Schwarz ist fertig. Smacznego!");
                        Thread.Sleep(5000);
                        Console.Clear();
                    }
                    else if (coffee >= 20 && water < 200)
                    {
                        Console.WriteLine("Bitte erst Wasser nachfüllen.");
                        Thread.Sleep(5000);
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Bitte erst Kaffee nachfüllen.");
                        Thread.Sleep(5000);
                        Console.Clear();
                        return;
                    }
                    break;
                default:
                    break;
            }
        }
        public void DisplayReserve()
        {
            if (coffee < 160)
            {
                Console.Write("\nCoffee\t");
                Console.ForegroundColor = ConsoleColor.Red;
                UI.WriteProgressBar(coffee / 8);
                Console.ResetColor();
                Console.Write(" | " + coffee + " g");
            }
            else
            {
                Console.Write("\nCoffee\t");
                Console.ForegroundColor = ConsoleColor.Green;
                UI.WriteProgressBar(coffee / 8);
                Console.ResetColor();
                Console.Write(" | " + coffee + " g");
            }
            if (milk < 200)
            {
                Console.Write("\nMilk\t");
                Console.ForegroundColor = ConsoleColor.Red;
                UI.WriteProgressBar(milk / 10);
                Console.ResetColor();
                Console.Write(" | " + milk + " ml");
            }
            else
            {
                Console.Write("\nMilk\t");
                Console.ForegroundColor = ConsoleColor.Green;
                UI.WriteProgressBar(milk / 10);
                Console.ResetColor();
                Console.Write(" | " + milk + " ml");
            }
            if (water < 200)
            {
                Console.Write("\nWater\t");
                Console.ForegroundColor = ConsoleColor.Red;
                UI.WriteProgressBar(water / 20);
                Console.ResetColor();
                Console.Write(" | " + water + " ml");
            }
            else
            {
                Console.Write("\nWater\t");
                Console.ForegroundColor = ConsoleColor.Green;
                UI.WriteProgressBar(water / 20);
                Console.ResetColor();
                Console.Write(" | " + water + " ml\n");
            }
        }
        public void Reinigung()
        {
            if (water >= 500)
            {
                Console.WriteLine("Reinigung wird gestartet.");
                ui.ProgressBar();
                Console.WriteLine("Reinigung abgeschlossen!");
                Thread.Sleep(5000);
                Console.Clear();
                return; 
            }
            else
            {
                Console.WriteLine("Bitte erst Wasser nachfüllen.");
                Thread.Sleep(5000);
                Console.Clear();
                return;
            }
        }
        public bool Shutdown()
        {
            Console.WriteLine("Maschine wird ausgeschalten.");
            Thread.Sleep(3000);
            return false;
            //Environment.Exit(0);
        }
    }
}
