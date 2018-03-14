using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SocialNet
{
    [DataContract]
    public class Picture
    {
        public Picture(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }

        [DataMember]
        public string Text { get; set; }
    }
}
