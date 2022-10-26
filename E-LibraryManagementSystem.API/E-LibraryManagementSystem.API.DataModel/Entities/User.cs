using System;
using System.Collections.Generic;

namespace E_LibraryManagementSystem.API.DataModel.Entities
{
    public partial class User
    {
        public User()
        {
            IssuedBooks = new HashSet<IssuedBook>();
            RequestedBooks = new HashSet<RequestedBook>();
        }

        public string? Name { get; set; }
        public string? Password { get; set; }
        public int? MobileNo { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<IssuedBook> IssuedBooks { get; set; }
        public virtual ICollection<RequestedBook> RequestedBooks { get; set; }
    }
}
