using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LibraryManagementSystem.ServiceModel.DTO.Response
{
    public class RespRequestedBookDTO
    {
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string ImageUrl { get; set; }
        public string BookName { get; set; }
        public  DateTime? IssueDate { get; set; }
        public  DateTime? ReturnDate { get; set; }

        public DateTime? RequestDate { get; set; }
    }
}
