using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UserAndPass
{

    class User
    {
        string username;
        string password;


        public string GetUsername()
        {
            return username;
        }

        public void SetName()
        {
            Console.WriteLine("Enter a username: ");
            username = Console.ReadLine();
        }

        public void SetPassword()
        {
            Console.WriteLine("Select a password: ");
            password = Console.ReadLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            User one = new User();
            one.SetName();
            one.SetPassword();
            Console.WriteLine("Username Chosen: {0}", one.GetUsername());


            bool end = false;
            while (!end)
            {

                Console.WriteLine("\nType anything to terminate program: ");
                int c = Console.Read();
                end = true;
            }
        }
    }
}
