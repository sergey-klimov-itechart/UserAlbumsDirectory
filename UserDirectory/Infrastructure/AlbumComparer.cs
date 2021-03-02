using System.Collections.Generic;
using UserDirectory.Models;

namespace UserDirectory.Infrastructure
{
    public class AlbumComparer : IEqualityComparer<Album>
    {
        public bool Equals(Album album1, Album album2)
        {
            if (album1 == null || album2 == null)
            {
                return false;
            }

            return album1.Id == album2.Id;
        }

        public int GetHashCode(Album p)
        {
            return p.Id;
        }
    }
}
