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
        private Bank_G<Branch> _Bank;

        public BranchService()
        {
            _Bank = new Bank_G<Branch>();
        }
        //We create List Employee
        public void Create(Branch branch)
        {
            _Bank.Datas.Add(branch);
            Console.Clear();
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
            Branch.AllBranch.Add(branch);
            Console.Clear();
            
        }
        public void Delete(string name)
        {
            Branch branch = _Bank.Datas.Find(d => d.Name.ToLower().Trim() == name.ToLower().Trim());
            branch.SoftDelete = false;
        }

        public void Get(string entity)
        {
            try
            {
                Branch branch = _Bank.Datas.Find(g => g.Name.Contains(entity.ToLower().Trim()));
            }
            catch (FormatException)
            {

                Console.WriteLine("Branch not found");
            }
        }

        public void GetAll()
        {
            foreach (Branch employee in _Bank.Datas.Where(d => d.SoftDelete == false))
            {
                Console.WriteLine(employee.Name);
            }
        }

        public void GetProfit(Branch entity)
        {

        }

        public void HireEmployee()
        {
            throw new NotImplementedException();
        }
        //we are transferring employees to branches here
        public void TransferEmployee(string name, string name1, Employee name2)
        {
            Employee employee = new Employee();
            Branch branch = new Branch();
            Branch branch1 = new Branch();
            branch = _Bank.Datas.Find(x =>x.Name ==employee.Name);
            branch1 = _Bank.Datas.Find(x => x.Name == employee.Name);
        }
        //we are transferring money to the employee
        public void TransferMoney()
        {
            Console.Clear();
            Console.WriteLine("---Trasfer Money---");
            Console.Write("Please enter your Name: ");
            string yourname = Console.ReadLine();
            Console.Write("Please enter the Name of the person you would like to tranfer funds to: ");
            string name = Console.ReadLine();
            Console.Write("Enter the amount of funds you would like to transfer: ");
            string amount = Console.ReadLine();
            Employee employee = new Employee();
            foreach (Branch Transfer in Branch.AllBranch)
            {
                if (employee.Name==name)
                {
                    Transfer.Budget -=employee.Salary;
                }
            }
            foreach (Branch Transfer in Branch.AllBranch)
            {
                if (Transfer.Name==employee.Name)
                {
                    employee.Salary+=Transfer.Budget;
                }
            }
        }
        //we are changing the current names, budget, address
        public void Update(string name,decimal budget,string address)
        {
            Branch branch = _Bank.Datas.Find(u=>u.Name.ToLower().Trim()==name.Trim().ToLower());
            branch.Budget = budget;
            branch.Address = address;
        }
    }
}
