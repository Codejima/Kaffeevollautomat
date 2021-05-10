using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kaffeevollautomat
{
    enum Recipes
    {
        Latte,
        Cappuccino,
        Espresso,
        Schwarz,
        Reinigung
    }
    class Logic
    {
  
        UI ui = new();
        //Enums enums = new();
        
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
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    CheckReserve(Recipes.Latte);
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    CheckReserve(Recipes.Cappuccino);
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    CheckReserve(Recipes.Espresso);
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    CheckReserve(Recipes.Schwarz);
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    CheckReserve(Recipes.Reinigung);
                    break;
                case ConsoleKey.NumPad6:
                case ConsoleKey.D6:
                    Shutdown();
                    break;
                default:
                    Console.WriteLine("Auswahltasten nur von 1 bis 6.");
                    Thread.Sleep(2500);
                    Console.Clear();
                    break;
            }
        }
        int coffee = 800; //800 g
        int milk = 100; //1000 ml
        int water = 2000; //2000 ml
        
        internal bool KeepRunning = true;

        
    //Recipes
    //Latte: 20g, 60ml, 140ml
    //Capu: 25g, 20ml, 180ml
    //Espresso: 30g, 0, 80ml
    //Schwarz: 20g, 0, 200ml
        

        public void CheckReserve(Recipes chosenRecipe)
        {
            int c;
            int m;
            int w;
            switch (chosenRecipe) //TODO: fix cariables
            {
                case Recipes.Latte:
                    c = 20; m = 60; w = 140;

                    if (IsDispensable(c, m, w))
                    {
                        Console.WriteLine("Latte macchiato wird zubereitet.");
                        ui.ProgressBar();
                        //Console.WriteLine("Latte macchiato ist fertig.");
                        ui.CoffeeAnimation();
                    }
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
                case Recipes.Cappuccino:
                    c = 25; m = 20; w = 180;

                    if (IsDispensable(c, m, w))
                    {
                        Console.WriteLine("Cappuccino wird zubereitet.");
                        ui.ProgressBar();
                        //Console.WriteLine("Cappuccino ist fertig.");
                        ui.CoffeeAnimation();
                    }
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
                case Recipes.Espresso:
                    c = 30; m = 0; w = 80;

                    if (IsDispensable(c, m, w))
                    {
                        Console.WriteLine("Espresso wird zubereitet.");
                        ui.ProgressBar();
                        //Console.WriteLine("Espresso ist fertig.");
                        ui.CoffeeAnimation();
                    }
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
                case Recipes.Schwarz:
                    c = 20; m = 0; w = 200;

                    if (IsDispensable(c, m, w))
                    {
                        Console.WriteLine("Kaffee Schwarz wird zubereitet.");
                        ui.ProgressBar();
                        //Console.WriteLine("Kaffee Schwarz ist fertig.");
                        ui.CoffeeAnimation();
                    }
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
                case Recipes.Reinigung:
                    c = 0; m = 0; w = 500;

                    if (IsDispensable(c, m, w))
                    {
                        Console.WriteLine("Reinigung wird gestartet.");
                        ui.ProgressBar();
                        Console.WriteLine("Reinigung abgeschlossen!");
                    }
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
                default:
                    break;
            }
        }

        private bool IsDispensable(int c, int m, int w)
        {
            bool dispensable = true;
            if (coffee < c)
            {
                dispensable = false;
                Console.WriteLine("Bitte erst Kaffee nachfüllen.");
            }
            if (milk < m)
            {
                dispensable = false;
                Console.WriteLine("Bitte erst Milch nachfüllen.");
            }
            if (water < w)
            {
                dispensable = false;
                Console.WriteLine("Bitte erst Wasser nachfüllen.");
            }
            if (dispensable)
            {
                coffee -= c;
                milk -= m;
                water -= w; 
            }
            return dispensable;
            
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
        //public void Reinigung()
        //{
        //    if (water >= 500)
        //    {
        //        Console.WriteLine("Reinigung wird gestartet.");
        //        ui.ProgressBar();
        //        Console.WriteLine("Reinigung abgeschlossen!");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Bitte erst Wasser nachfüllen.");
        //    }
        //    Thread.Sleep(3000);
        //    Console.Clear();
        //}
        public void Shutdown()
        {
            Console.WriteLine("Maschine wird ausgeschalten.");
            Thread.Sleep(3000);
            KeepRunning = false;
            //Environment.Exit(0);
        }
        
    }
}
