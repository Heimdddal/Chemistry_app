﻿using Chemistry_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Chemistry_app.Controllers
{
    public static class UserJsonController
    {
        public static void WriteToJson(List<User> users, string filename)
        {
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filename, json);
        }

        public static List<User> ReadFromJson(string filename)
        {
            string json = File.ReadAllText(filename);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            return users;
        }

        public static void CreateJsonFile(string filename)
        {
            var users = new List<User>();
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filename, json);
        }
    }
}
