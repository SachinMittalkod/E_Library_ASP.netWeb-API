using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LibraryManagementSystem.ServiceModel.DTO.Request
{
    public class UserRequestDTO
    {
        public int? RequestId { get; set; }
        public int? UserId { get; set; }
        public DateTime? Date { get; set; }
        public int? BookId { get; set; }
    }
}
