using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finisar.SQLite;


namespace Project_finance
{

    class User
    {
        string username;
        string password;
        string birthdate;
        int userID;
        float salary;
        string namePerson;

        //access private variables using the class functions normally, not needed to use 

        public string encryptCaesar()
        {
            int shift = 7;
            string encryption = "";

            for (int i = 0; i < password.Length; i++)
            {

                int ascii = password[i];

                if (password[i] >= 65 && password[i] <= 90)
                {
                    ascii = ((26 - (90 - password[i] + 1) + shift) % 26) + 65;
 

                }
                else if (password[i] >= 97 && password[i] <= 122)
                {
                    ascii = ((26 - (122 - password[i] + 1) + shift) % 26) + 97;


                }


                encryption = encryption + (char)ascii;
            }

            return encryption;
        }

        public string GetUsername()
        {
            return username;
        }

        public string GetPassword()
        {
            return password;
        }

        public string getNameOfPerson()
        {
            return namePerson;
        }

        public void SetNamePerson(string name)
        {
            namePerson = name;
        }

        public void setUsername(string name)
        {
            username = name;
        }

        public void SetPassword(string pass)
        {
            password = pass;
        }

        public void setUserID(int ID)
        {
            userID = ID;
        }

        public void SetSalary(float amount)
        {
            salary = amount;
        }

        public int getUserID()
        {
            return userID;
        }
        public float getSalary()
        {
            return salary;
        }

        public void setBirthdate(string age)
        {
            birthdate = age;
        }

        public string getBirthdate()
        {
            return birthdate;
        }

        public void printUserInfo()
        {
            Console.WriteLine(" \nInformation of Person: \nBirthdate: {0} \nName: {1} \nSalary: {2} \nID: {3} \nUsername: {4}\n", birthdate, namePerson, salary, userID, username);
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

    }


    class Program
    {
        static void Main(string[] args)
        {

            Chequing acc1 = new Chequing();
            acc1.SetTransactionDate("ass");
            Console.WriteLine("Account Name Chosen: {0}", acc1.getTransactionDate());

            User one = new User();
            one.loginName();
            one.loginPassword();
            Console.WriteLine("Username Chosen: {0}", one.GetUsername());
            string encryption = one.encryptCaesar();




            // [snip] - As C# is purely object-oriented the following lines must be put into a class:

            // We use these three SQLite objects:
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=BankSystem.db;Version=3;New=False;Compress=True;");


            // open the connection:
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            /*
            //CREATE TABLES HERE

            // create a new SQL command:
            

            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = "CREATE TABLE Accounts (Type varchar(50), Balance float, Interest float, id int primary key);";

            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();

            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = "CREATE TABLE User (username varchar(50), name varchar(50), id int primary key, birthdate date, salary int, foreign key (id) references Accounts(id));";

            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();

            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = "CREATE TABLE Login (username varchar(50) primary key, password varchar(50));";

            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();

            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = "CREATE TABLE Transactions (Date date, Amount float, id int primary key, name varchar(50), tnumber int, foreign key (id) references Accounts(id));";

            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // Lets insert something into our new table:
            sqlite_cmd.CommandText = String.Format("INSERT INTO Login VALUES ('{0}' , '{1}');", one.GetUsername(), encryption);

            // And execute this again ;D
            sqlite_cmd.ExecuteNonQuery();


            //TABLES CREATION END HERE
            */

            //INSERT VALUES




            // But how do we read something out of our table ?
            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = "SELECT * FROM User";

            User[] users = new User[3];
            
            int i = 0;

    

            // User userTitle[3] = new User[];

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                User user1 = new User();

                user1.setUsername(sqlite_datareader["username"].ToString());
                user1.SetNamePerson(sqlite_datareader["name"].ToString());
                user1.setBirthdate(sqlite_datareader["birthdate"].ToString());
                user1.SetSalary(float.Parse(sqlite_datareader["salary"].ToString()));
                user1.setUserID(int.Parse(sqlite_datareader["id"].ToString()));

                users[i] = user1;
                users[i].printUserInfo();


                // user1.

                // Print out the content of the text field:<<<<<<< HEAD

                //  System.Console.WriteLine("Username: {0}    -    Password: {1}", sqlite_datareader["username"], sqlite_datareader["password"]);

                //("Username: {0}    -    Password: {1}", sqlite_datareader["username"], sqlite_datareader["Name"]);

                i++;
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

