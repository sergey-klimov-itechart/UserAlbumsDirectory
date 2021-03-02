using System.Collections.Generic;

namespace UserDirectory.Models.ViewModels
{
    public class AlbumsViewModel
    {
        public IEnumerable<AlbumUserViewModel> AlbumsUserViewModel { set; get; }
        public PagingData PagingData { set; get; }
    }
}
