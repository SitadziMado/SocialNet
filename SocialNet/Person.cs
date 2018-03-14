using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace SocialNet
{
    [DataContract]
    public class Person
    {
        public delegate void UpdatedHandler(UpdatedEventArgs uea);

        public enum GenderType
        {
            [Description("Не указано")]
            Undefined,

            [Description("Мужчина")]
            Male,

            [Description("Женщина")]
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
            Updated = (UpdatedEventArgs uae) => { };

            mUsername = String.Empty;
            mPassword = String.Empty;
            mFriends = new List<Person>();
            mPosts = new List<Post>();
            mPictures = new List<Picture>();
            mUpdates = new Journal();

            Initials = "";
            Birthday = DateTime.Now;
            Gender = GenderType.Undefined;
            MaritalStatus = MaritalStatusType.Undefined;
            School = "";
            University = "";

            mNames = new HashSet<string>();
        }

        public Person(string username, string password) :
            this()
        {
            mUsername = username;
            mPassword = password;
        }

        public void Restored()
        {
            mFriends = new List<Person>();
            mUpdates = new Journal();
        }

        public void Storing()
        {
            mNames = new HashSet<string>();

            foreach (var v in mFriends)
            {
                mNames.Add(v.Initials);
            }
        }

        public static MaritalStatusType IndexToMaritalStatus(int index)
        {
            if (index >= 0 && index < mMaritalStatusMap.Count)
                return mMaritalStatusMap[index];

            throw new ArgumentOutOfRangeException();
        }

        public static int MaritalStatusToIndex(MaritalStatusType ms)
            => mMaritalStatusMap.IndexOf(ms);

        public static GenderType IndexToGender(int index)
        {
            if (index >= 0 && index < mGenderMap.Count)
                return mGenderMap[index];

            throw new ArgumentOutOfRangeException();
        }

        public static int GenderToIndex(GenderType ms)
            => mGenderMap.IndexOf(ms);


        public bool MatchCredentials(string username, string password)
            => mUsername == username && mPassword == password;

        public void AddFriend(Person friend)
        {
            if (friend != this && !mFriends.Contains(friend))
            {
                mFriends.Add(friend);
                mNames.Add(friend.Initials);
                friend.mFriends.Add(this);
                friend.mNames.Add(friend.Initials);

                Updated += friend.mUpdates.OnUpdate;
                friend.Updated += mUpdates.OnUpdate;

                Updated(new UpdatedEventArgs(this, UpdatedEventArgs.UpdateType.FriendAdded, friend.Initials));
            }
            else
            {
                throw new AlreadyFriendsException();
            }
        }

        public void RemoveFriend(Person friend)
        {
            if (friend != this && mFriends.Contains(friend))
            {
                mFriends.Remove(friend);
                mNames.Remove(friend.Initials);
                friend.mFriends.Remove(this);
                friend.mNames.Remove(friend.Initials);

                Updated -= friend.mUpdates.OnUpdate;
                friend.Updated -= mUpdates.OnUpdate;
            }
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

        public override string ToString()
        {
            return Initials;
        }

        public IEnumerable<Person> Friends { get => mFriends.AsEnumerable(); }
        public IEnumerable<Post> Posts { get => mPosts.AsEnumerable(); }
        public IEnumerable<Picture> Pictures { get => mPictures.AsEnumerable(); }
        public IEnumerable<UpdatedEventArgs> Updates { get => mUpdates.GetUpdates(); }
        public IEnumerable<string> Names { get { return mNames.AsEnumerable(); } }
        public string Username { get { return mUsername; } }
        public string Password { get { return mPassword; } }
    
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

        public string School
        {
            get
            {
                return mSchool;
            }
            set
            {
                mSchool = value;
                Updated(new UpdatedEventArgs(this, UpdatedEventArgs.UpdateType.SchoolChanged, value));
            }
        }

        public string University
        {
            get
            {
                return mUniversity;
            }
            set
            {
                mUniversity = value;
                Updated(new UpdatedEventArgs(this, UpdatedEventArgs.UpdateType.UniversityChanged, value));
            }
        }

        public GenderType Gender
        {
            get
            {
                return mGender;
            }
            set
            {
                mGender = value;
                Updated(new UpdatedEventArgs(this, UpdatedEventArgs.UpdateType.GenderChanged, value.Description()));
            }
        }
    
        [DataMember] private string mInitials = String.Empty;
        [DataMember] private DateTime mBirthday = DateTime.Now;
        [DataMember] private MaritalStatusType mMaritalStatus;
        [DataMember] private string mSchool;
        [DataMember] private string mUniversity;
        [DataMember] private GenderType mGender;
        [DataMember] private string mUsername;
        [DataMember] private string mPassword;
        [DataMember] private List<Post> mPosts;
        [DataMember] private List<Picture> mPictures;

        [DataMember] private HashSet<string> mNames;

        private List<Person> mFriends;
        private Journal mUpdates;

        private static List<MaritalStatusType> mMaritalStatusMap
            = new List<MaritalStatusType>
        {
            MaritalStatusType.Undefined,
            MaritalStatusType.Single,
            MaritalStatusType.Married,
        };

        private static List<GenderType> mGenderMap
            = new List<GenderType>
        {
            GenderType.Undefined,
            GenderType.Male,
            GenderType.Female,
        };
    }
}
