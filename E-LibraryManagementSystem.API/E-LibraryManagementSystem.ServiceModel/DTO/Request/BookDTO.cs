﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LibraryManagementSystem.ServiceModel.DTO.Request
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public string? AuthorName { get; set; }
        public DateTime? Date { get; set; }
        public string? ImageUrl { get; set; }
        public int? UserId { get; set; }
       
    }
}
