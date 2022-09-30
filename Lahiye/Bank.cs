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
            BranchService branchService = new BranchService();
            Console.ForegroundColor = ConsoleColor.DarkBlue;


            Console.WriteLine("                                              Welcome the Pasha Bank");


                            //Models 
            Branch branch = new Branch();
            Employee employee = new Employee();
            Manager manager = new Manager();


            //Login manager and Menu 
            
            Console.Write("Login: ");
            string userlogin = Console.ReadLine();
            Console.Write("Password: ");
            int userkod = int.Parse(Console.ReadLine());
           Menu: if (manager.Username == userlogin && manager.Userpassword == userkod)
            {
                Console.Clear();
                ManagerMenu();
                
                int command = int.Parse(Console.ReadLine());
                switch (command)
                {
                    case 1:
                        Console.Clear();
                        BranchMenu();
                        int bracnhmenu = int.Parse(Console.ReadLine());
                        switch (bracnhmenu)
                        {
                            case 1:
                                branchService.Create(branch);
                                goto Menu;
                                break;
                            case 2:
                                
                                // branchService.Delete(name);
                                goto Menu;
                                break;
                            case 3:

                                goto Menu;
                                break;
                            case 4:
                                branchService.TransferMoney();
                                Console.WriteLine("******************************************************************************");
                                foreach (Branch item in Branch.AllBranch)
                                {
                                    Console.WriteLine($"Name: {branch.Name} Budget: {branch.Budget}  Address: {branch.Address}");
                                }
                                Console.WriteLine("******************************************************************************");
                                goto Menu;
                                break;
                            case 5:

                                goto Menu;
                                break;
                            case 6:
                                Console.WriteLine("******************************************************************************");
                                foreach (Branch item in Branch.AllBranch)
                                {
                                    Console.WriteLine($"Name: {branch.Name} Budget: {branch.Budget}  Address: {branch.Address}");
                                }
                                Console.WriteLine("******************************************************************************");
                                break;
                            default:
                                Console.WriteLine("No such feature");
                                break;
                        }
                        break;
                    case 2:
                        EmployeeMenu();
                        int employemenu = int.Parse(Console.ReadLine());
                        switch (employemenu)
                        {
                            case 1:
                                employeeService.Create(employee);
                                goto Menu;
                                break;
                            case 2:

                                goto Menu;
                                break;
                            case 3:

                                goto Menu;
                                break;
                            default:
                                Console.WriteLine("No such feature");
                                break;
                        }

                        break;
                    default:
                        Console.WriteLine("No such feature");
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
            Console.WriteLine("4: Transfer Money Branch");
            Console.WriteLine("5: Transfer Employee Branch");
            Console.WriteLine("6: Created Branches");
        }
        public static void EmployeeMenu()
        {
            Console.WriteLine("1: Create Employee");
            Console.WriteLine("2: Delete Employee");
            Console.WriteLine("3: UpDate Employee");
        }
    }
}
