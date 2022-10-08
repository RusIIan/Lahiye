using Lahiye.DataBase;
using Lahiye.Models;
using Lahiye.Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Lahiye.Service.Implementation
{
    public class BranchService : IBankService<Branch>, IBranchService
    {
        public EmployeeService employeeService;
        private  Bank_G<Branch> _Bank;

        public BranchService(EmployeeService _employeeService)
        {
            _Bank = new Bank_G<Branch>();
            employeeService = _employeeService;
        }
        //We create List Employee
        public void Create()
        {
            Branch branch = new Branch();
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
            _Bank.Datas.Add(branch);
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
            
                Console.Write("Name: ");
                string entity = Console.ReadLine();
                Branch branch = _Bank.Datas.Find(g => g.Name.Contains(entity.Trim())
                ||g.Budget.ToString().Contains(entity.Trim())||g.Address.Contains(entity.Trim()));
                Console.WriteLine($"Name: {branch.Name}  Budget: {branch.Budget}  Address: {branch.Address}");
            
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
            try
            {
                Console.WriteLine("Enter branchName: ");
                string branchName = Console.ReadLine();
                Branch branch = _Bank.Datas.Find(g => g.Name == branchName);
                decimal num = 0;
                foreach (var employee in employeeService._employees.Datas)
                {
                    num += employee.Salary;
                }
                decimal profit = branch.Budget - num;
                Console.WriteLine("Remaining budget: " + profit);
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrectly spelled branches or employees");
            }
          
            
        }
        public void HireEmployee()
        {
            try
            {
            Console.WriteLine("Branch Name: ");
            string branchName = Console.ReadLine();
            Console.WriteLine("Employee Name: ");
            string employeeName = Console.ReadLine();
            Branch branch = _Bank.Datas.Where(m => m.Name == branchName).FirstOrDefault();
            Employee employee = employeeService._employees.Datas.Where(e => e.Name == employeeName).FirstOrDefault();
            branch.Employees.Add(employee);
            employee.branch = branch;
            foreach (var item in branch.Employees)
                {
                    Console.Write("Employee added to branch: " + item.Name);
                }
            }
            catch (Exception)
            {
            Console.WriteLine("Not found Emploee: ");
            }
           
        }
        //we are transferring employees to branches here               
        public void TransferEmployee()
        {
            Console.WriteLine("From Branch Name: ");
            string branName = Console.ReadLine();
            Console.WriteLine("To Branch Name: ");
            string bran1Name = Console.ReadLine();
            Console.WriteLine("Employee Name: ");
            string EmpName = Console.ReadLine();
            Branch frombranch = _Bank.Datas.Where(t=>t.Name== branName).FirstOrDefault();
            Employee employee = frombranch.Employees.Find(t => t.Name.Trim().ToLower() == EmpName.Trim().ToLower());
            Branch tobranch = _Bank.Datas.Where(t=>t.Name== bran1Name).FirstOrDefault();

            if (frombranch.Budget>employee.Salary)
             {
                frombranch.Employees.Remove(employee);
                tobranch.Employees.Add(employee);
                tobranch.Budget -= employee.Salary;
                 Console.WriteLine($"Employee {employee.Name} {employee.Surname} successfully transtfer from {tobranch.Address}");
             }
        }
        //we are transferring money to the employee
        public void TransferMoney()
        {
            try
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
            catch (FormatException)
            {
                Console.WriteLine("Incorect Name or Numbers");
            }
        }
        //we are changing the current names, budget, address
        public void Update()
        {
            try
            {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Branch branch = _Bank.Datas.Find(u=>u.Name.ToLower().Trim()==name.Trim().ToLower());
            Console.Write("New budget: ");
            branch.Budget = decimal.Parse(Console.ReadLine());
            Console.Write("New Address: ");
            branch.Address = Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect Update");
            }
        }
    }
}
