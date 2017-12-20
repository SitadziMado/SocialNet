using System.Collections.Generic;
using System.Linq;

namespace SocialNet
{
    internal class Journal
    {
        public Journal()
        {

        }

        public void OnUpdate(UpdatedEventArgs uea)
        {
            mUpdates.Add(uea);
        }

        public IEnumerable<UpdatedEventArgs> GetUpdates()
            => mUpdates.AsEnumerable();

        private List<UpdatedEventArgs> mUpdates;
    }
}