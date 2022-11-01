using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LibraryManagementSystem.ServiceModel.DTO.Request
{
    public class IssuedBookDataDTO
    {
        //public int IssuedId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime? IssuedDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
