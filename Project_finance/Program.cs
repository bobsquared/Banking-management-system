using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finisar.SQLite;


namespace UserAndPass
{

    class User
    {
        string username;
        string password;
        //access private variables using the class functions normally, not needed to use 

        public string GetUsername()
        {
            return username;
        }

        public string GetPassword()
        {
            return password;
        }

        public void SetName()
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

        public void SetPassword()
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
    }


    class Program
    {
        static void Main(string[] args)
        {
            User one = new User();
            one.SetName();
            one.SetPassword();
            Console.WriteLine("Username Chosen: {0}", one.GetUsername());






            // [snip] - As C# is purely object-oriented the following lines must be put into a class:

            // We use these three SQLite objects:
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=BankSystem.db;Version=3;New=True;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = "CREATE TABLE User (username varchar(50) primary key, password varchar(50));";

            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();

            // Lets insert something into our new table:
            sqlite_cmd.CommandText = String.Format("INSERT INTO User VALUES ('{0}' , '{1}');", one.GetUsername(), one.GetPassword());

            // And execute this again ;D
            sqlite_cmd.ExecuteNonQuery();

            // ...and inserting another line:
            sqlite_cmd.CommandText = "INSERT INTO User VALUES ('Vincent', 'Banker');";

            // And execute this again ;D
            sqlite_cmd.ExecuteNonQuery();

            // But how do we read something out of our table ?
            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = "SELECT * FROM User";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                // Print out the content of the text field:
                System.Console.WriteLine("Username: {0}    -    Password: {1}", sqlite_datareader["username"], sqlite_datareader["password"]);
            }

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();


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

