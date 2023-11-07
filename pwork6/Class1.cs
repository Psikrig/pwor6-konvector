using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace pwork6
{
    internal class model
    {
        public static string[] filet;
        public string Shtuka;
        public string number;
        public string url;
    }

    internal class Class1
    {
        private static void menu(string result1, string ext)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.F1)
            {
                Console.WriteLine("введите путь для сохранения");
                string pathf = Console.ReadLine();
                string ext1 = Path.GetExtension(pathf);
                if (ext1 == ".txt")
                {
                    File.WriteAllText(pathf, result1);
                }
                model f = new model();
                f.Shtuka = model.filet[0];
                f.number = model.filet[1];
                f.url = model.filet[2];
                List<model> l1 = new List<model>();
                l1.Add(f);
                if (ext1 == ".json")
                {
                    if (ext == ".txt")
                    {
                        string json = JsonConvert.SerializeObject(model.filet);
                        File.WriteAllText(pathf, json);
                    }
                }
                if (ext1 == ".xml")
                {

                }
            }
        }

        public static void txt(string path, string ext)
        {
            model.filet = File.ReadAllLines(path);
            string result1 = File.ReadAllText(path);
            foreach (string line in model.filet)
            {
                Console.WriteLine(line);
            }
            menu(result1, ext);
        }
        public static Class1 sht;
        
        public static void json(string path, string ext)
        {
            string filet1 = File.ReadAllText(path);
            List<Class1> result = JsonConvert.DeserializeObject<List<Class1>>(filet1);
            Console.WriteLine(result);
            string result1 = Convert.ToString(result);
            menu(result1, ext);
        }

        public static void xml(string path, string ext)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Class1));
            using (FileStream filet1 = new FileStream(path, FileMode.Open))
            {
                Class1.sht = xml.Deserialize(filet1) as Class1;
            }
            Console.WriteLine(Class1.sht);
            string result1 = Convert.ToString(Class1.sht);
            menu(result1, ext);
        }
    }
}
