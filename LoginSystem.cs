using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class LoginSystem : ILogin
    {
        //Finns det en anledning till varför vi inte använder loggedInUser som returnerat värde i andra metoder här? /N
        public User Login()
        {
            User loggedInCustomer = null;
            int loginAttempts = 0;
            int maxLoginAttempts = 3; // Assuming a maximum of 3 login attempts

            while (loginAttempts < maxLoginAttempts && loggedInCustomer == null)
            {
                Console.WriteLine("Username:");
                string enteredName = Console.ReadLine();
                // Validate if the entered username exists in CustomerUsers dictionary
                if (DataManager.userList.ContainsKey(enteredName))
                {
                    Console.WriteLine("Password:");
                    string enteredPassword = Validator.GetValidString();
                    // Perform password validation here
                    if (ValidateCustomerPassword(enteredName, enteredPassword)) // Example password validation
                    {
                        Console.Clear();
                        Console.WriteLine("Welcome, " + enteredName + "!");
                        // Further actions after successful login can be added here
                        loggedInCustomer = DataManager.userList[enteredName];
                    }
                    else
                    {
                        loginAttempts++;
                        Console.WriteLine($"Incorrect password. You have {maxLoginAttempts - loginAttempts} attempts remaining.");
                    }
                }
                else
                {
                    Console.WriteLine("Username not found.");
                }
            }

            if (loggedInCustomer == null)
            {
                Console.WriteLine("Maximum login attempts reached. Please contact support.");
            }

            return loggedInCustomer;

        }

        // Method to validate admin password
        private bool ValidateCustomerPassword(string enteredName, string enteredPassword)
        {
            // Check if the userID exists in the dictionary
            if (DataManager.userList.ContainsKey(enteredName))
            {
                // Retrieve the stored password corresponding to the userID
                User storedUser = DataManager.userList[enteredName];
                return enteredPassword == storedUser.PassWord;
            }
            else
            {
                // UserID not found, handle the case (throw an exception, return false, etc.)
                // For example:
                throw new ArgumentException("User ID not found.");

            }

        }
    }
}
