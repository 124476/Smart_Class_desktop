using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models
{
    public class User
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public bool IsSuperUser { get; set; }
        public int MainUser { get; set; } = 1;
        public byte[] Photo
        {
            get
            {
                if (Image == null) return null;
                return Convert.FromBase64String(Image);
            }
        }
        public string SurnameI
        {
            get
            {
                return $"{FirstName} {LastName[0]}.";
            }
        }
        public string Role { get; set; }
    }
}
