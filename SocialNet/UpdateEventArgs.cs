using System;

namespace SocialNet
{
    public class UpdatedEventArgs : EventArgs
    {
        public enum UpdateType
        {
            Undefined,
            NameChanged,
            BirthdayChanged,
            MaritalStatusChanged,
            FriendAdded,
            PictureAdded,
            PostAdded,
            Birthday,
            GenderChanged,
            SchoolChanged,
            UniversityChanged,
        }

        public UpdatedEventArgs() :
            base()
        {
            Date = DateTime.Now;
        }

        public UpdatedEventArgs(Person source, UpdateType type, string info) :
            this()
        {
            Source = source;
            Type = type;

            switch (Type)
            {
                case UpdateType.Undefined:
                    Info = "Неопределенное событие."; break;
                case UpdateType.NameChanged:
                    Info = $"Пользователь \"{info}\" изменил имя на \"{Source.Initials}\"."; break;
                case UpdateType.BirthdayChanged:
                    Info = $"Пользователь \"{Source.Initials}\" изменил день рождения на \"{info}\"."; break;
                case UpdateType.MaritalStatusChanged:
                    Info = $"Пользователь \"{Source.Initials}\" изменил семейное положение на \"{info}\"."; break;
                case UpdateType.FriendAdded:
                    Info = $"Пользователь \"{Source.Initials}\" добавил друга \"{info}\"."; break;
                case UpdateType.PictureAdded:
                    Info = $"Пользователь \"{Source.Initials}\" добавил изображение \"{info}\"."; break;
                case UpdateType.PostAdded:
                    Info = $"Пользователь \"{Source.Initials}\" добавил новость \"{info}\"."; break;
                case UpdateType.Birthday:
                    Info = $"У пользователя \"{Source.Initials}\" сегодня день рождения."; break;
                case UpdateType.GenderChanged:
                    Info = $"Пользователь \"{Source.Initials}\" поменял пол на {Source.Gender.Description()}."; break;
                case UpdateType.SchoolChanged:
                    Info = $"Пользователь \"{Source.Initials}\" изменил информацию о школе на {Source.School}."; break;
                case UpdateType.UniversityChanged:
                    Info = $"Пользователь \"{Source.Initials}\" изменил информацию об университете на {Source.University}."; break;
                default:
                    break;
            }
        }

        public override string ToString()
        {
            return Info;
        }

        public Person Source { get; internal set; }
        public UpdateType Type { get; internal set; }
        public DateTime Date { get; internal set; }
        public string Info { get; internal set; }
    }
}