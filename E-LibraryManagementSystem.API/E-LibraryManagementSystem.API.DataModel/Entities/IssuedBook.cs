using System;
using System.Collections.Generic;

namespace E_LibraryManagementSystem.API.DataModel.Entities
{
    public partial class IssuedBook
    {
        public int IssueId { get; set; }
        public int? BookId { get; set; }
        public int? UserId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public virtual BookDetail? User { get; set; }
    }
}
