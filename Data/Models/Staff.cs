using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumCafé.Data.Models
{
    internal class Staff
    {
        // Enum to represent default passwords
        enum DefaultPasswords
        {
            StaffPass123,
            AdminPass456,
        }
        // Enum to represent roles
        enum UserRole
        {
            Staff,
            Admin,
        }

        class StaffModel
        {
            // Attributes
            public string Name { get; set; }
            private string Password { get; set; }
            public string Role { get; private set; }

            // Constructor
            public StaffModel(string name, string password)
            {
                Name = name;
                SetPassword(password);
                SetRole();
            }

            // Method to set password and determine role
            private void SetPassword(string password)
            {
                // Set password from enum value
                if (Enum.TryParse(password, out DefaultPasswords _))
                {
                    Password = password;
                }
                else
                {
                    // Default role if password doesn't match either Staff or Admin
                    Console.WriteLine("Access Denied. Invalid password.");
                    Password = "";
                }
            }

            // Method to set role based on password
            private void SetRole()
            {
                // Set role from enum value
                if (Password == DefaultPasswords.StaffPass123.ToString())
                {
                    Role = UserRole.Staff.ToString();
                }
                else if (Password == DefaultPasswords.AdminPass456.ToString())
                {
                    Role = UserRole.Admin.ToString();
                }
                else
                {
                    // No role is set if password doesn't match either Staff or Admin
                    Console.WriteLine("No Role is Detected. Invalid password.");
                }
            }
        }
       
 
    }
}
