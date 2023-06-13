using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemistry_app.Models
{
    internal class User
    {
        private string Name { get; }  
        private string Email { get; }
        private int Age { get; }
        private string Gender { get; }
        private string Password { get; }


        User() {
        }

        User(string name,
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
    }
}
