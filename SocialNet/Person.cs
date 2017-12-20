using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace SocialNet
{
    [Serializable]
    public class Person
    {
        public delegate void UpdatedHandler(UpdatedEventArgs uea);

        public enum GenderType
        {
            Undefined,
            Male,
            Female,
        }

        public enum MaritalStatusType
        {
            [Description("Не указано")]
            Undefined,

            [Description("Не женат/не замужем")]
            Single,

            [Description("Женат/замужем")]
            Married,
        }

        public event UpdatedHandler Updated;

        public Person()
        {
            mUsername = String.Empty;
            mPassword = String.Empty;
            mFriends  = new List<Person>();
            mPosts    = new List<Post>();
            mPictures = new List<Picture>();
            mUpdates = new Journal();

            Initials = "";
            Birthday = DateTime.Now;
            Gender = GenderType.Undefined;
            MaritalStatus = MaritalStatusType.Undefined;
            School = "";
            University = "";
        }

        public Person(string username, string password) :
            this()
        {
            mUsername = username;
            mPassword = password;
        }

        public bool MatchCredentials(string username, string password) 
            => mUsername == username && mPassword == password; 

        public void AddFriend(Person friend)
        {
            mFriends.Add(friend);
            friend.Updated += mUpdates.OnUpdate;
        }

        public void RemoveFriend(Person friend)
        {
            mFriends.Remove(friend);
            friend.Updated -= mUpdates.OnUpdate;
        }

        public void AddPost(Post post)
        {
            mPosts.Add(post);
            Updated(new UpdatedEventArgs(this, UpdatedEventArgs.UpdateType.PostAdded, post.Text));
        }

        public void RemovePost(Post post)
        {
            mPosts.Remove(post);
        }

        public void AddPicture(Picture picture)
        {
            mPictures.Add(picture);
            Updated(new UpdatedEventArgs(this, UpdatedEventArgs.UpdateType.PictureAdded, picture.Text));
        }

        public void RemovePicture(Picture picture)
        {
            mPictures.Remove(picture);
        }

        public IEnumerable<UpdatedEventArgs> GetUpdates()
        {
            return mUpdates.GetUpdates();
        }

        [OnSerialized]
        private void OnSerialized(StreamingContext context)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Person> Friends { get => mFriends.AsEnumerable(); }
        IEnumerable<Post> Posts { get => mPosts.AsEnumerable(); }
        IEnumerable<Picture> Pictures { get => mPictures.AsEnumerable(); }
        IEnumerable<int> Updates { get => throw new NotImplementedException(); }

        public string Initials
        {
            get
            {
                return mInitials;
            }
            set
            {
                var last = mInitials;
                mInitials = value;
                Updated(new UpdatedEventArgs(this, UpdatedEventArgs.UpdateType.NameChanged, last));
            }
        }

        public DateTime Birthday
        {
            get
            {
                return mBirthday;
            }
            set
            {
                mBirthday = value;
                Updated(new UpdatedEventArgs(this, UpdatedEventArgs.UpdateType.BirthdayChanged, mBirthday.ToShortDateString()));
            }
        }

        public MaritalStatusType MaritalStatus
        {
            get
            {
                return mMaritalStatus;
            }
            set
            {
                mMaritalStatus = value;
                Updated(new UpdatedEventArgs(this, UpdatedEventArgs.UpdateType.MaritalStatusChanged, value.Description()));
            }
        }

        public string School { get; set; }
        public string University { get; set; }
        public GenderType Gender { get; internal set; }

        private string mInitials;
        private DateTime mBirthday;
        private MaritalStatusType mMaritalStatus;

        private string mUsername;
        private string mPassword;
        private List<Person> mFriends;
        private List<Post> mPosts;
        private List<Picture> mPictures;

        [NonSerialized]
        private Journal mUpdates;
    }
}
