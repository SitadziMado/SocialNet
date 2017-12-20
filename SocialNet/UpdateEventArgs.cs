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
                    Source.Initials = $"Пользователь \"{info}\" изменил имя на \"{Source.Initials}\"."; break;
                case UpdateType.BirthdayChanged:
                    Source.Initials = $"Пользователь \"{Source.Initials}\" изменил день рождения на \"{info}\"."; break;
                case UpdateType.MaritalStatusChanged:
                    Source.Initials = $"Пользователь \"{Source.Initials}\" изменил семейное положение на \"{info}\"."; break;
                case UpdateType.FriendAdded:
                    Source.Initials = $"Пользователь \"{Source.Initials}\" добавил друга \"{info}\"."; break;
                case UpdateType.PictureAdded:
                    Source.Initials = $"Пользователь \"{Source.Initials}\" добавил изображение \"{info}\"."; break;
                case UpdateType.PostAdded:
                    Source.Initials = $"Пользователь \"{Source.Initials}\" добавил новость \"{info}\"."; break;
                case UpdateType.Birthday:
                    Source.Initials = $"У пользователя \"{Source.Initials}\" сегодня день рождения."; break;
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