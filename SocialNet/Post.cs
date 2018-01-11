using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNet
{
    public class Post
    {
        public Post(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }

        public string Text { get; set; }
    }
}
