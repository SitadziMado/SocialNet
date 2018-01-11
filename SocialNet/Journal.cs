using System.Collections.Generic;
using System.Linq;

namespace SocialNet
{
    public class Journal
    {
        public Journal()
        {
            mUpdates = new List<UpdatedEventArgs>();
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