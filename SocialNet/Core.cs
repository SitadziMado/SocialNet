using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SocialNet
{
    public class Core
    {
        public Core()
        {
            mPeople = new List<Person>();
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
                    Profile = v;
                    return v;
                }

            throw new UserNotRegisteredException();
        }

        public void LoadUsers(string path = "people.json")
        {
            Person[] newPeople;

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                    newPeople = (Person[])mJsonFormatter.ReadObject(fs);

                mPeople = new List<Person>(newPeople);

                foreach (var a in mPeople)
                    a.Restored();

                foreach (var a in mPeople)
                    foreach (var name in a.Names)
                        try
                        {
                            a.AddFriend(FindByName(name));
                        }
                        catch (AlreadyFriendsException) { }
                        catch (UserNotRegisteredException) { }
            }
            catch (UserNotRegisteredException)
            {
                mPeople.Clear();
            }
            catch (FileNotFoundException)
            {

            }
        }

        public void UnloadUsers(string path = "people.json")
        {
            foreach (var a in mPeople)
                a.Storing();

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                mJsonFormatter.WriteObject(fs, mPeople.ToArray());
        }

        public void MouseEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                if (sender is Person)
                    Current.RemoveFriend(sender as Person);
                else if (sender is Picture)
                    Current.RemovePicture(sender as Picture);
                else if (sender is Post)
                    Current.RemovePost(sender as Post);
                else
                    throw new ArgumentException("Неверный тип.");
            }
        }

        /// <summary>
        /// Найти пользователя по имени.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="UserNotRegisteredException"></exception>
        public Person FindByName(string name)
        {
            foreach (var a in mPeople)
                if (a.Initials == name)
                    return a;

            throw new UserNotRegisteredException();
        }

        private static DataContractJsonSerializer mJsonFormatter = 
            new DataContractJsonSerializer(typeof(Person[]));

        public Person Current { get; set; }
        public Person Profile { get; set; }
        public IEnumerable<string> Names { get { return from v in mPeople select v.Initials; } }
        public IEnumerable<string> Usernames { get { return from v in mPeople select v.Username; } }
        public IEnumerable<string> Passwords { get { return from v in mPeople select v.Password; } }

        private List<Person> mPeople;
    }
}
