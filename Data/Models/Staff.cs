using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumCafé.Data.Models
{
    internal class Staff
    {
        public class StaffModel
        {
            // Attributes
            public string Name { get; set; }
            private string Password { get; set; }
            public string Role { get; set; }

            // Constructor
            public StaffModel(string name, string password, string role)
            {
                Name = name;
                Password = password;
                Role = role;
            }
        }
    }
}
