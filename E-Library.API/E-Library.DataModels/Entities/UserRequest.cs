using System;
using System.Collections.Generic;

namespace E_Library.DataModels.Entities
{
    public partial class UserRequest
    {
        public int? RequestId { get; set; }
        public int? UserId { get; set; }
        public DateTime? Date { get; set; }
        public int? BookId { get; set; }

        public virtual BookDetail? Book { get; set; }
        public virtual User? User { get; set; }
    }
}
