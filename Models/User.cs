using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemistry_app.Models
{
    public class User
    {
        public string Name { get; set; }  
        public string Email { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }

        public User(string name,
            string email,
            int age,
            string gender,
            string password) 
        { 
            Name = name;
            Email = email;
            Age = age;
            Gender = gender;
            Password = password;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
