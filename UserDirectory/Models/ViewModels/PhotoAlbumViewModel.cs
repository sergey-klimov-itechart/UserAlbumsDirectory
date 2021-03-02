using System.Collections.Generic;

namespace UserDirectory.Models.ViewModels
{
    public class PhotoAlbumViewModel
    {
        public IEnumerable<PhotoViewModel> Photos { get; set; }
        public string AlbumTitle { get; set; }
        public string ReturnUrl { get; set; }
    }
}
