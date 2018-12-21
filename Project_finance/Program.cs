using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_finance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            bool end = false;
            while (!end)
            {

                Console.WriteLine("Type anything to terminate program: ");
                int c = Console.Read();
                end = true;
            }
        }
    }
}
