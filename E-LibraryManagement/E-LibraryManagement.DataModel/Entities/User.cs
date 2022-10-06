using System;
using System.Collections.Generic;

#nullable disable

namespace E_LibraryManagement.DataModel.entities
{
    public partial class User
    {
        //public user()
        //{
        //    bookdetails = new hashset<bookdetail>();
        //}

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int? MobileNo { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int RoleId { get; set; }

        public virtual ICollection<BookDetail> BookDetails { get; set; }

        public static implicit operator User(string v)
        {
            throw new NotImplementedException();
        }
    }
}
