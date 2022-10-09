using System;
using System.Collections.Generic;

namespace E_Library.DataModels.entities
{
    public partial class User
    {
        public User()
        {
            BookDetails = new HashSet<BookDetail>();
            UserRequests = new HashSet<UserRequest>();
        }

        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public int? MobileNo { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public int RoleId { get; set; }

        public virtual ICollection<BookDetail> BookDetails { get; set; }
        public virtual ICollection<UserRequest> UserRequests { get; set; }
    }
}
