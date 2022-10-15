using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LibraryManagementSystem.ServiceModel.DTO.Request
{
    public class IssuedBookDTO
    {
        public int IssuedId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string UserName { get; set; }
        public string BookName { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
