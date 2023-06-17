using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace Chemistry_app.Models
{
    public class User
    {
        public string Name { get; set; }  
        public string Email { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public bool isGuest { get; set; }

        public User() {
            Name = "Гость";
            Email = "guest@gmail.com";
            Age = 0;
            Gender = null;
            Password = null;
            isGuest = true;
        }   
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
            isGuest = false;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
