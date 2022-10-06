using System;
using System.Collections.Generic;

namespace E_Library.DataModels.Entities
{
    public partial class BookDetail
    {
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public string? AuthorName { get; set; }
        public DateTime? Date { get; set; }
        public string? ImageUrl { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
