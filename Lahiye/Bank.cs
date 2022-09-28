using Lahiye.Models;
using Lahiye.Service.Implementation;
using System;
using System.Collections.Generic;

namespace Lahiye
{
    public  class Bank
    {

        static void Main(string[] args)
        {

            Console.WriteLine("                                              Welcome the Pasha Bank");
           
            Manager manager = new Manager();
            string userlogin = Console.ReadLine();
            int userkod = int.Parse(Console.ReadLine());
            if (manager.username==userlogin&&manager.userpassword==userkod)
            {
                int command = int.Parse(Console.ReadLine());
                switch (command)
                {
                    
                }
            }
            else
            {
                Console.WriteLine("Involid password ");
            }



        }
    }
}
