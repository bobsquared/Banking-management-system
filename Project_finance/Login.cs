using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_finance
{
    class Login
    {

        string username;
        string password;

        private string encryptCaesar(string pass)
        {
            int shift = 7;
            string encryption = "";

            for (int i = 0; i < pass.Length; i++)
            {

                int ascii = pass[i];

                if (pass[i] >= 65 && pass[i] <= 90)
                {
                    ascii = ((26 - (90 - pass[i] + 1) + shift) % 26) + 65;


                }
                else if (pass[i] >= 97 && pass[i] <= 122)
                {
                    ascii = ((26 - (122 - pass[i] + 1) + shift) % 26) + 97;


                }


                encryption = encryption + (char)ascii;
            }

            return encryption;
        }

        public void loginName()
        {

            while (username == null || username.Length > 50)
            {

                Console.WriteLine("Enter a username: ");
                username = Console.ReadLine();

                if (username.Length > 50)
                {
                    Console.WriteLine("Username is too long, please re-try. \n");

                }
            }
        }

        public void loginPassword()
        {
            while (password == null || password.Length > 50)
            {

                Console.WriteLine("Enter a password: ");
                password = Console.ReadLine();

                if (password.Length > 50)

                {
                    Console.WriteLine("Password is too long, please re-try. \n");

                }
            }
        }

        public string getUsername()
        {
            return username;
        }

        public string getEncrpytion()
        {
            return password;
        }

        public void setUsername(string user)
        {
            username = user;
        }

        public void setPassword(string pass)
        {
            password = encryptCaesar(pass);
        }

    }
}
