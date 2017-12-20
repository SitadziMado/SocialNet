using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SocialNet
{
    public class Core
    {
        public Core()
        {

        }

        public void Register(Person info)
        {
            mPeople.Add(info);
        }

        public Person Login(string username, string password)
        {
            foreach (var v in mPeople)
                if (v.MatchCredentials(username, password))
                {
                    Current = v;
                    return v;
                }

            throw new UserNotRegisteredException();
        }

        public void LoadUsers(string path = "users.xml")
        {
            var xmlSerializer = new XmlSerializer(typeof(Person));

            LinkedList<Person> people = new LinkedList<Person>();

            try
            {
                using (var fs = new FileStream("users.xml", FileMode.Open))
                    while (xmlSerializer.Deserialize(fs) is Person person)
                        people.AddLast(person);
            }
            catch (InvalidOperationException)
            {
            }
            catch (FileNotFoundException)
            {
            }

            mPeople = people.ToList();
        }

        public void UnloadUsers(string path = "users.xml")
        {
            var xmlSerializer = new XmlSerializer(typeof(Person));

            using (var fs = new FileStream("users.xml", FileMode.OpenOrCreate))
                foreach (var v in mPeople)
                    xmlSerializer.Serialize(fs, v);
        }

        private Person Current { get; set; }

        private List<Person> mPeople;
    }
}
