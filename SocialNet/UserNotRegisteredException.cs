using System;
using System.Runtime.Serialization;

namespace SocialNet
{
    [Serializable]
    internal class UserNotRegisteredException : Exception
    {
        public UserNotRegisteredException()
        {
        }

        public UserNotRegisteredException(string message) : base(message)
        {
        }

        public UserNotRegisteredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserNotRegisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}