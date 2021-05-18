using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Kaffeevollautomat
{
    public class Data
    {
        public const string fileRecipes = "recipes.lel";
        public const string fileCoffee = "coffee.lel";
        public ContainerData containerdata = new();
        List<Recipes> RecipeList = new();
        
        public void SaveRecipes()
        {
            using (BinaryWriter writer = new(File.OpenWrite(fileRecipes)))
            {
                writer.Write((byte)RecipeList.Count);
                foreach (var item in RecipeList)
                {
                    writer.Write((byte)item.recipeName);
                    writer.Write((byte)item.coffee);
                    writer.Write((byte)item.milk);
                    writer.Write((byte)item.water);
                }
            }
        }
        public void LoadRecipes()
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileRecipes, FileMode.Open)))
                {
                    byte RecipeNumber = reader.ReadByte();
                    for (int i = 0; i < RecipeNumber; i++)
                    {
                        Recipes recipes = new();
                        recipes.recipeName = (RecipeType)reader.ReadByte();
                        recipes.coffee = reader.ReadByte();
                        recipes.milk = reader.ReadByte();
                        recipes.water = reader.ReadByte();
                        RecipeList.Add(recipes);
                    }
                }
            }
            catch (Exception e) when (e is FileNotFoundException || e is DirectoryNotFoundException)
            {
                Recipes recipes = new();
                recipes.recipeName = RecipeType.Latte;
                recipes.coffee = 20;
                recipes.milk = 60;
                recipes.water = 140;
                RecipeList.Add(recipes);
                recipes = new();
                recipes.recipeName = RecipeType.Cappuccino;
                recipes.coffee = 25;
                recipes.milk = 20;
                recipes.water = 180;
                RecipeList.Add(recipes);
                recipes = new();
                recipes.recipeName = RecipeType.Espresso;
                recipes.coffee = 30;
                recipes.milk = 0;
                recipes.water = 80;
                RecipeList.Add(recipes);
                recipes = new();
                recipes.recipeName = RecipeType.Schwarz;
                recipes.coffee = 20;
                recipes.milk = 0;
                recipes.water = 200;
                RecipeList.Add(recipes);
                recipes = new();
                recipes.recipeName = RecipeType.Reinigung;
                recipes.coffee = 0;
                recipes.milk = 0;
                recipes.water = 500;
                RecipeList.Add(recipes);
            }
        }
        public void SaveData()
        {
            try
            {
                using (BinaryWriter writer = new(File.OpenWrite(fileCoffee)))
                {
                    writer.Write('L');
                    writer.Write('E');
                    writer.Write('L');
                    writer.Write(containerdata.coffee);
                    writer.Write(containerdata.milk);
                    writer.Write(containerdata.water);
                }
            }
            catch (Exception e) when (e is DirectoryNotFoundException || e is AccessViolationException)
            {
                Console.WriteLine("Speichern nicht erfolgreich. "+e.Message);
            }
        }
        public bool LoadData()
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileCoffee, FileMode.Open)))
                {
                    byte[] magicNumber = reader.ReadBytes(3);

                    containerdata.coffee = reader.ReadInt16();
                    containerdata.milk = reader.ReadInt16();
                    containerdata.water = reader.ReadInt16();
                }
            }
            catch (FileNotFoundException)
            {
                containerdata.coffee = 800;
                containerdata.milk = 1000;
                containerdata.water = 2000;
                return true;
            }
            return false;
        }
    }
}

