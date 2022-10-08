using Lahiye.Models;
using Lahiye.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lahiye
{
    public class Bank
    {

        static void Main(string[] args)
        {
            EmployeeService employeeService = new EmployeeService();
            BranchService branchService = new BranchService(employeeService);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                              Welcome the Pasha Bank");
                            //Models 
            Manager manager = new Manager();

            //Login manager and Menu 
            while (true)
            {
                try
                {
                    Console.Write("Login: ");
                    string userlogin = Console.ReadLine();
                    Console.Write("Password: ");
                    int userkod = int.Parse(Console.ReadLine());
                     Console.Clear();
                    if (manager.Username == userlogin && manager.Userpassword == userkod)
                    {
                        Console.Clear();
                    Menu: ManagerMenu();
                        int command = int.Parse(Console.ReadLine());
                        Console.Clear();

                        switch (command)
                        {
                            case 1:
                                Console.Clear();
                                BranchMenu();
                                int bracnhmenu = int.Parse(Console.ReadLine());
                                switch (bracnhmenu)
                                {
                                    case 1:
                                        Console.Clear();
                                        branchService.Create();
                                        Console.Clear();
                                        goto Menu;
                                        break;
                                    case 2:
                                        Console.Clear();
                                        branchService.Delete();
                                        Console.Clear();
                                        goto Menu;
                                        break;
                                    case 3:
                                        Console.Clear();
                                        branchService.TransferMoney();
                                        Console.Clear();
                                        goto Menu;
                                        break;
                                    case 4:
                                        Console.Clear();
                                        branchService.TransferEmployee();
                                        Console.Clear();
                                        goto Menu;
                                        
                                    case 5:
                                        Console.Clear();
                                        branchService.HireEmployee();
                                        Console.ReadKey();
                                        Console.Clear();
                                        goto Menu;
                                        
                                    case 6:
                                        Console.Clear();
                                        branchService.GetProfit();
                                        Console.Clear();
                                        goto Menu;
                                    case 7:
                                        Console.Clear();
                                        branchService.Get();
                                        Console.Clear();
                                        goto Menu;
                                    case 8:
                                        Console.Clear();
                                        branchService.GetAllToConsole();
                                        Console.Clear();
                                        goto Menu;
                                    case 9:
                                        Console.Clear();
                                        branchService.Update();
                                        Console.Clear();
                                        goto Menu;
                                        break;
                                    default:
                                        Console.WriteLine("No such feature");
                                        break;
                                }
                                break;
                            case 2:
                                Console.Clear();
                                EmployeeMenu();
                                int employemenu = int.Parse(Console.ReadLine());
                                switch (employemenu)
                                {
                                    case 1:
                                        Console.Clear();
                                        employeeService.Create();
                                        Console.WriteLine("******************************************************************************");
                                        foreach (Employee employee1 in employeeService._employees.Datas)
                                        {
                                            Console.WriteLine($"Name: {employee1.Name} Surname: {employee1.Surname}  Salary: {employee1.Salary} Profession: {employee1.Profession}");
                                        }
                                        Console.WriteLine("******************************************************************************");
                                        Console.ReadKey();
                                        goto Menu;
                                        break;
                                    case 2:
                                        employeeService.Delete();
                                        Console.ReadKey();
                                        goto Menu;
                                        break;
                                    case 3:
                                        employeeService.Update();
                                        goto Menu;
                                        break;
                                    case 4:
                                        employeeService.Get();
                                        Console.ReadKey();
                                        goto Menu;
                                        break;
                                    case 5:
                                        employeeService.GetAll();
                                        goto Menu;
                                        break;
                                    case 6:
                                        Console.WriteLine("******************************************************************************");
                                        foreach (Employee employee1 in employeeService._employees.Datas)
                                        {
                                            Console.WriteLine($"Name: {employee1.Name} Surname: {employee1.Surname}  Salary: {employee1.Salary} Profession: {employee1.Profession}");
                                        }
                                        Console.WriteLine("******************************************************************************");
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
                }
                catch (FormatException)
                {
                    Console.WriteLine("Involid password ");
                }
            }
            Console.ResetColor(); 
        }
        public static void ManagerMenu()
        {
            Console.WriteLine("                                                         Pasha Bank");
            Console.WriteLine("           Manager Menu");
            Console.WriteLine("1: Branch");
            Console.WriteLine("2: Employee");
        }
        public static void BranchMenu()
        {
            Console.WriteLine("                                                         Pasha Bank");
            Console.WriteLine("                Branch Menu");
            Console.WriteLine("1: Create Branch");
            Console.WriteLine("2: Delete Branch");
            Console.WriteLine("3: Transfer Money Branch");
            Console.WriteLine("4: Transfer Employee Branch");
            Console.WriteLine("5: Hire Employee Branch");
            Console.WriteLine("6: Getprofit Branches");
            Console.WriteLine("7: Get Branches");
            Console.WriteLine("8: GetAll Branches");
            Console.WriteLine("9: Update Branches");
        }
        public static void EmployeeMenu()
        {
            Console.WriteLine("                                                         Pasha Bank");
            Console.WriteLine("               Employee Menu");
            Console.WriteLine("1: Create Employee");
            Console.WriteLine("2: Delete Employee");
            Console.WriteLine("3: UpDate Employee");
            Console.WriteLine("4: Get Employee");
            Console.WriteLine("5: GetAll Employee");
            Console.WriteLine("6: Created Employee");
        }
    
    }
}
