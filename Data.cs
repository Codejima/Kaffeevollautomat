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
        public int Number;
        public string Text;

        int coffee = 800; //800 g
        int milk = 100; //1000 ml
        int water = 2000; //2000 ml

        public static void WriteReserve(int c, int m, int w)
        {
            XmlSerializer xml = new(typeof(Data));
            using (StreamWriter writer = new("log.xml"))
            {
                xml.Serialize(writer, data);
            }
            coffee -= c;
            milk -= m;
            water -= w;
        }



        public const string FileName = "Data.xml";
        public void Load()
        {
            if (File.Exists(FileName))
            {
                XmlSerializer xml = new(typeof(Data));
                using (StreamReader reader = new(FileName))
                {
                    Data temp = (Data)xml.Deserialize(reader);

                } 
            }
            else
            {
                DataList.Add(new Data {ContentType = Reserves.coffee, Current = 123 });
            }
        }
        public void Save()
        {
            using (StreamReader reader = new(FileName))
            {

            }
        }
    }
}
