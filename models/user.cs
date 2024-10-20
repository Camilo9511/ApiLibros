using System.Collections.Generic;

namespace BookCollectionAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Book>? Books { get; set; }


        public User()
        {
            Books = new List<Book>(); 
        }
    }
}