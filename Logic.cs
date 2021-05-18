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
        public const string fileCoffee = "coffee.lel";

        UI ui = new();
        Data data = new();
        public bool fileNotFound = false;
        internal bool KeepRunning = true;

        public Logic()
        {
            fileNotFound = data.LoadData();
        }

        public void Menu()
        {
            Console.CursorVisible = false;
            ui.Logo();
            if (fileNotFound)
            {
                ContainerData containerdata = new();
                Console.WriteLine("FileCoffee not found. Loading with preset values.");
                containerdata.coffee = 800;
            }
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
                    CheckReserve(RecipeType.Latte);
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    CheckReserve(RecipeType.Cappuccino);
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    CheckReserve(RecipeType.Espresso);
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    CheckReserve(RecipeType.Schwarz);
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    CheckReserve(RecipeType.Reinigung);
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
        public void CheckReserve(RecipeType chosenRecipe)
        {
            short c;
            short m;
            short w;
            switch (chosenRecipe)
            {
                case RecipeType.Latte:
                    c = 20; m = 60; w = 140;

                    if (IsDispensable(c, m, w))
                    {
                        Console.WriteLine("Latte macchiato wird zubereitet.");
                        ui.ProgressBar();
                        ui.CoffeeAnimation();
                    }
                    break;
                case RecipeType.Cappuccino:
                    c = 25; m = 20; w = 180;

                    if (IsDispensable(c, m, w))
                    {
                        Console.WriteLine("Cappuccino wird zubereitet.");
                        ui.ProgressBar();
                        ui.CoffeeAnimation();
                    }
                    break;
                case RecipeType.Espresso:
                    c = 30; m = 0; w = 80;

                    if (IsDispensable(c, m, w))
                    {
                        Console.WriteLine("Espresso wird zubereitet.");
                        ui.ProgressBar();
                        ui.CoffeeAnimation();
                    }
                    break;
                case RecipeType.Schwarz:
                    c = 20; m = 0; w = 200;

                    if (IsDispensable(c, m, w))
                    {
                        Console.WriteLine("Kaffee Schwarz wird zubereitet.");
                        ui.ProgressBar();
                        ui.CoffeeAnimation();
                    }
                    break;
                case RecipeType.Reinigung:
                    c = 0; m = 0; w = 500;

                    if (IsDispensable(c, m, w))
                    {
                        Console.WriteLine("Reinigung wird gestartet.");
                        ui.ProgressBar();
                        Console.WriteLine("Reinigung abgeschlossen!");
                    }
                    break;
                default:
                    break;
            }
            Thread.Sleep(3000);
            Console.Clear();
        }

        private bool IsDispensable(short c, short m, short w)
        {
            
            bool dispensable = true;
            if (data.containerdata.coffee < c)
            {
                dispensable = false;
                Console.WriteLine("Bitte erst Kaffee nachfüllen.");
            }
            if (data.containerdata.milk < m)
            {
                dispensable = false;
                Console.WriteLine("Bitte erst Milch nachfüllen.");
            }
            if (data.containerdata.water < w)
            {
                dispensable = false;
                Console.WriteLine("Bitte erst Wasser nachfüllen.");
            }
            if (dispensable)
            {
                data.containerdata.coffee -= c;
                data.containerdata.milk -= m;
                data.containerdata.water -= w;
                data.SaveData();
            }
            return dispensable;
            
        }

        public void DisplayReserve()
        {

            if (data.containerdata.coffee < 160)
            {
                Console.Write("\nCoffee\t");
                Console.ForegroundColor = ConsoleColor.Red;
                UI.WriteProgressBar(data.containerdata.coffee / 8);
                Console.ResetColor();
                Console.Write(" | " + data.containerdata.coffee + " g");
            }
            else
            {
                Console.Write("\nCoffee\t");
                Console.ForegroundColor = ConsoleColor.Green;
                UI.WriteProgressBar(data.containerdata.coffee / 8);
                Console.ResetColor();
                Console.Write(" | " + data.containerdata.coffee + " g");
            }
            if (data.containerdata.milk < 200)
            {
                Console.Write("\nMilk\t");
                Console.ForegroundColor = ConsoleColor.Red;
                UI.WriteProgressBar(data.containerdata.milk / 10);
                Console.ResetColor();
                Console.Write(" | " + data.containerdata.milk + " ml");
            }
            else
            {
                Console.Write("\nMilk\t");
                Console.ForegroundColor = ConsoleColor.Green;
                UI.WriteProgressBar(data.containerdata.milk / 10);
                Console.ResetColor();
                Console.Write(" | " + data.containerdata.milk + " ml");
            }
            if (data.containerdata.water < 200)
            {
                Console.Write("\nWater\t");
                Console.ForegroundColor = ConsoleColor.Red;
                UI.WriteProgressBar(data.containerdata.water / 20);
                Console.ResetColor();
                Console.Write(" | " + data.containerdata.water + " ml");
            }
            else
            {
                Console.Write("\nWater\t");
                Console.ForegroundColor = ConsoleColor.Green;
                UI.WriteProgressBar(data.containerdata.water / 20);
                Console.ResetColor();
                Console.Write(" | " + data.containerdata.water + " ml\n");
            }
        }
        public void Shutdown()
        {
            Console.WriteLine("Maschine wird ausgeschalten.");
            Thread.Sleep(3000);
            KeepRunning = false;
            data.SaveData();
            //Environment.Exit(0);
        }
    }
}
