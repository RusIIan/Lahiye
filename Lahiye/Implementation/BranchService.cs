using Lahiye.DataBase;
using Lahiye.Models;
using Lahiye.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lahiye.Service.Implementation
{
    public class BranchService : IBankService<Branch>, IBranchService
    {
        private EmployeeService employeeService;
        public Bank_G<Branch> _Bank;

        public BranchService(EmployeeService _employeeService)
        {
            _Bank = new Bank_G<Branch>();
            employeeService = _employeeService;
        }
        //We create List Employee
        public void Create(Branch entity )
        {
            Branch branch = new Branch();
                _Bank.Datas.Add(branch);
            try
            {
                Console.WriteLine("--- Create Branch ---");
                Console.Write("Please enter the Name: ");
                string name = Console.ReadLine();
                Console.Write("Please enter the Budget: ");
                decimal budger = decimal.Parse(Console.ReadLine());
                Console.Write("Please enter the Address: ");
                string address = Console.ReadLine();
                branch.Name = name;
                branch.Budget = budger;
                branch.Address = address;
                branch.Employees = new List<Employee>();
            }
            catch (Exception)
            {
                Console.WriteLine("You are not creating a worker correctly");
            }
            
            
        }
        //silmek Filiali silir
        public void Delete()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Branch branch = _Bank.Datas.Find(d => d.Name.ToLower().Trim() == name.ToLower().Trim());
            branch.SoftDelete = true;
        }
              //Filiali adla Tapir
        public void Get()
        {
            try
            {
                Console.Write("Name: ");
                string entity = Console.ReadLine();
                Branch branch = _Bank.Datas.Find(g => g.Name.Contains(entity.Trim())
                ||g.Budget.ToString().Contains(entity.Trim())||g.Address.Contains(entity.Trim()));
                Console.WriteLine($"Name: {branch.Name}  Budget: {branch.Budget}  Address: {branch.Address}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Branch not found");
            }
        }
          //butun branchi teqdim edir
        public void GetAllToConsole()
        {
            foreach (Branch branch in _Bank.Datas.Where(d => d.SoftDelete == false))
            {
                Console.WriteLine(branch.Name + " " + branch.Budget + " " + branch.Address);
            }
        }             


        public void GetProfit()
        {
            Branch branch = new Branch();
            Console.Write("Calculate profit and loss:");
            Console.Write("Input Selling Price: ");
            decimal getprofil = 0;
            decimal sellprice = decimal.Parse(Console.ReadLine());
            branch.Employees.ForEach(c=>sellprice+=c.Salary);
            getprofil = branch.Budget - sellprice;
            Console.WriteLine($"Profit of the {branch.Name}  branch in {getprofil}");
            
        }
        public void HireEmployee(string branchName,string employeeName)
        {
            try
            {
            Branch branch = _Bank.Datas.Where(m => m.Name == branchName).FirstOrDefault();
            Employee employee = employeeService._employees.Datas.Where(e => e.Name == employeeName).FirstOrDefault();
            branch.Employees.Add(employee);
            foreach (var item in branch.Employees)
                {
                    Console.Write("Name Employee: "+item.Name);
                }
            }
            catch (Exception)
            {
            Console.WriteLine("Not found Emploee: ");
            }
           
        }
        //we are transferring employees to branches here               
        public void TransferEmployee(string BranName,string EmpName)
        {
            Branch branch = _Bank.Datas.Where(t=>t.Name==BranName).FirstOrDefault();
            Employee employee = employeeService._employees.Datas.Where(t=>t.Name==EmpName).FirstOrDefault();
            if (branch.Budget > employee.Salary)
            {
                branch.Employees.Remove(employee);
                branch.Employees.Add(employee);
                branch.Budget -= employee.Salary;
                Console.WriteLine($"Employee {employee.Name} {employee.Surname} successfully transtfer from {branch.Address}");
            }
        }
        //we are transferring money to the employee
        public void TransferMoney()
        {
            Branch branch = new Branch();
            Console.WriteLine("---Trasfer Money---");
            Console.Write("Please enter your Name: ");
            string yourname = Console.ReadLine();
            Console.Write("Please enter the Name of the person you would like to tranfer funds to: ");
            string name = Console.ReadLine();
            Console.Write("Enter the amount of funds you would like to transfer: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            foreach (Branch Transfer in _Bank.Datas)
            {
                if (Transfer.Name==yourname)
                {
                    Transfer.Budget -= amount;
                }
            }
            foreach (Branch Transfer in _Bank.Datas)
            {
                if (Transfer.Name==name)
                {
                    Transfer.Budget += amount;
                    break;
                }
            }
        }
        //we are changing the current names, budget, address
        public void Update()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Branch branch = _Bank.Datas.Find(u=>u.Name.ToLower().Trim()==name.Trim().ToLower());
            Console.Write("New budget: ");
            branch.Budget = decimal.Parse(Console.ReadLine());
            Console.Write("New Address: ");
            branch.Address = Console.ReadLine();
        }

       /* public List<Branch> GetAll()
        {
            
        }*/
    }
}
