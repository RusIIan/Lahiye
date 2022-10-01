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
                                Console.ReadKey();
                                goto Menu;
                                    break;
                            case 2:
                                
                                // branchService.Delete(name);
                                goto Menu;
                                break;
                            case 3:
                                Console.ReadKey();
                                branchService.TransferEmployee(branch);
                                Console.ReadKey();
                                goto Menu;
                                    break;
                            case 4:
                                branchService.TransferMoney();
                                Console.ReadKey();
                                goto Menu;
                                break;
                            case 5:
                                    branchService.TransferEmployee(branch);
                                goto Menu;
                                break;
                            case 6:
                                    branchService.GetProfit(branch);
                                    Console.WriteLine("******************************************************************************");
                                    foreach (Branch branch1 in branchService._Bank.Datas)
                                    {
                                        Console.WriteLine($"Name: {branch.Name} Budget: {branch.Budget}  Address: {branch.Address}");
                                    }
                                    Console.WriteLine("******************************************************************************");
                                    Console.ReadKey();
                                    goto Menu;
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
                                            Console.ReadKey();
                                            goto Menu;
                                            break;
                                        case 4:
                                            Console.WriteLine("******************************************************************************");
                                            foreach (Employee employee1 in employeeService._employees.Datas)
                                            {
                                                Console.WriteLine($"Name: {employee.Name} Surname: {employee.Surname}  Salary: {employee.Salary} Profession: {employee.Profession}");
                                            }
                                            Console.WriteLine("******************************************************************************");
                                            Console.ReadKey();
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
            Console.WriteLine("5: Created Branches");
            Console.WriteLine("6: Getprofit Branches");
        }
        public static void EmployeeMenu()
        {
            Console.WriteLine("1: Create Employee");
            Console.WriteLine("2: Delete Employee");
            Console.WriteLine("3: UpDate Employee");
            Console.WriteLine("4: Created Employee");
        }
    }
}
