using System;

namespace UserDirectory.Models
{
    public class PagingData
    {
        public int TotalPages {
            get
            {
                return (int) Math.Ceiling((decimal) TotalItems / Constants.DefaultPageSize);
            }
        }
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
    }
}
