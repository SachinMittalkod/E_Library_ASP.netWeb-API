using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace E_LibraryManagement.DataModel.entities
{
    public partial class BookDetail
    {
        [Required]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public DateTime? Date { get; set; }
        public string ImageUrl { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
