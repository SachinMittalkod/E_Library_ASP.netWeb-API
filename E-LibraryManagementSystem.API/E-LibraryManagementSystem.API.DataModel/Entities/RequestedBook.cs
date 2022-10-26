using System;
using System.Collections.Generic;

namespace E_LibraryManagementSystem.API.DataModel.Entities
{
    public partial class RequestedBook
    {
        public int RequestId { get; set; }
        public int? BookId { get; set; }
        public int? UserId { get; set; }
        public DateTime? RequestDate { get; set; }

        public virtual BookDetail? Book { get; set; }
        public virtual User? User { get; set; }
    }
}
