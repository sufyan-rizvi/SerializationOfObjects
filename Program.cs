using System.Configuration;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Threading.Channels;
using SerializationDemo.Models;

namespace SerializationDemo
{
    internal class Program
    {
        const int MAX_PERSON = 5;
        static string path = ConfigurationManager.AppSettings["filePath"]!.ToString();

        static List<Person> people = new List<Person>();


        static void Main(string[] args)
        {
            if (File.Exists(path))
            {
                Deserialize();
            }
            else {
                MakePerson();
                Serialization();
            
            }
            

        }

        static void Serialization()
        {
            //For serialization, convert the object to Json String and then WRITE to file

            string toJson = JsonSerializer.Serialize(people).ToString();
            File.AppendAllText(path, Environment.NewLine + toJson);



        }

        static void Deserialize()
        {
            //To Deserialize, Read the text first and then Deserialize it.
            
            string readText = File.ReadAllText(path);
            people = JsonSerializer.Deserialize<List<Person>>(readText);

            people.ForEach(person => Console.WriteLine(person));
            
        }

        static void MakePerson()
        {
            for (int id = 0; people.Count < (MAX_PERSON); id++)
            {
                Console.WriteLine("Enter Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Email: ");
                string email = Console.ReadLine();

                people.Add(new Person { Id = id, Name = name, Email = email });

            }
        }
    }
}
