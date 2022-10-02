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
                                        Console.ReadKey();
                                        goto Menu;
                                        break;
                                    case 2:
                                        branchService.Delete(branch);
                                        Console.ReadKey();
                                        goto Menu;
                                        break;
                                    case 3:
                                        branchService.TransferMoney();
                                        Console.ReadKey();
                                        goto Menu;
                                        break;
                                    case 4:
                                        branchService.TransferEmployee(branch);
                                        Console.ReadKey();
                                        goto Menu;
                                        break;
                                    case 5:
                                        branchService.HireEmployee(branch);
                                        Console.ReadKey();
                                        goto Menu;
                                        break;
                                    case 6:
                                        branchService.GetProfit(branch);
                                        Console.ReadKey();
                                        goto Menu;
                                    case 7:
                                        branchService.Get();
                                        Console.ReadKey();
                                        goto Menu;
                                    case 8:
                                        branchService.GetAll();
                                        Console.ReadKey();
                                        goto Menu;
                                    case 9:
                                        branchService.Update();
                                        Console.ReadKey();
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
                                        employeeService.Create(employee);
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
                                        employeeService.Delete(employee);
                                        Console.ReadKey();
                                        goto Menu;
                                        break;
                                    case 3:
                                        employeeService.Update();
                                        goto Menu;
                                        break;
                                    case 4:
                                        Console.WriteLine("******************************************************************************");
                                        foreach (Employee employee1 in employeeService._employees.Datas)
                                        {
                                            Console.WriteLine($"Name: {employee1.Name} Surname: {employee1.Surname}  Salary: {employee1.Salary} Profession: {employee1.Profession}");
                                        }
                                        Console.WriteLine("******************************************************************************");
                                        Console.ReadKey();
                                        goto Menu;
                                        break;
                                    case 5:
                                        employeeService.Get();
                                        goto Menu;
                                    case 6:
                                        employeeService.GetAll();
                                        goto Menu;
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
            Console.WriteLine("1: Branch");
            Console.WriteLine("2: Employee");
        }
        public static void BranchMenu()
        {
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
            Console.WriteLine("1: Create Employee");
            Console.WriteLine("2: Delete Employee");
            Console.WriteLine("3: UpDate Employee");
            Console.WriteLine("4: Created Employee");
            Console.WriteLine("5: GetAll Employee");
        }
    }
}
