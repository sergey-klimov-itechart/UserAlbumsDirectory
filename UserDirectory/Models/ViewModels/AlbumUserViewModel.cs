namespace UserDirectory.Models.ViewModels
{
    public class AlbumUserViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AlbumTitle { get; set; }
        public string ThumbnailUrl { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
    }
}
