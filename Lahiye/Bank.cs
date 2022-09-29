using Lahiye.Models;
using Lahiye.Service.Implementation;
using System;
using System.Collections.Generic;

namespace Lahiye
{
    public class Bank
    {

        static void Main(string[] args)
        {
            EmployeeService employeeService = new EmployeeService();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("                                              Welcome the Pasha Bank");

            Manager manager = new Manager();
            Console.Write("Login: ");
            string userlogin = Console.ReadLine();
            Console.Write("Password: ");
            int userkod = int.Parse(Console.ReadLine());
            if (manager.username == userlogin && manager.userpassword == userkod)
            {
                ManagerMenu();
                int command = int.Parse(Console.ReadLine());
                switch (command)
                {
                    case 1:
                        BranchMenu();
                        int bracnhmenu = int.Parse(Console.ReadLine());
                        switch (bracnhmenu)
                        {
                            case 1:
                                employeeService.Create(entity);
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.WriteLine();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Involid password ");
            }

            Console.ResetColor();
        }
        public static void Data()
        {
            string name = Console.ReadLine();
            string surname = Console.ReadLine();
            decimal salary = decimal.Parse(Console.ReadLine());
            string Profession = Console.ReadLine();
        }
        public static void ManagerMenu()
        {
            Console.WriteLine("1: Branch");
            Console.WriteLine("2: Employee");
        }
        public static void BranchMenu()
        {
            Console.WriteLine("1: Create Branch");
            Console.WriteLine("2: Delete Branch");
            Console.WriteLine("3: UpDate Branch");
            Console.WriteLine("4: Get Branch");
            Console.WriteLine("4: GetAll Branch");
        }
    }
}
