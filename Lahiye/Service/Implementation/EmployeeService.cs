using Lahiye.DataBase;
using Lahiye.Models;
using Lahiye.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lahiye.Service.Implementation
{
    public class EmployeeService:IBankService<Employee>,IEmployeeService
    {
        public Bank_G<Employee> _employees;

        public EmployeeService()
        {
            _employees = new Bank_G<Employee>();
        }

        public void Create(Employee entity)
        {
            Employee employee = new Employee();
            _employees.Datas.Add(employee);
            Console.WriteLine("--- Create Employee ---");
            try
            {
                Console.Write("Please enter the Name: ");
                string name = Console.ReadLine();
                Console.Write("Please enter the Surname: ");
                string surname = Console.ReadLine();
                Console.Write("Please enter the Salary: ");
                decimal salary = decimal.Parse(Console.ReadLine());
                Console.Write("Please enter the Profession: ");
                string profession = Console.ReadLine();
                employee.Name = name;
                employee.Surname = surname;
                employee.Salary = salary;
                employee.Profession = profession;
                Console.WriteLine("You sing");
                Console.Clear();
            }
            catch (FormatException)
            {
                Console.WriteLine("incorrectly create a worker");                
            }
        
        }
        public void Delete(Employee employee1)
        {
            Employee employee = _employees.Datas.Find(x => x.Name.ToLower().Trim() == employee1.Name.ToLower().Trim());
            employee1.SoftDelete = true;
            GetAll();
        }
        public void Get()
        {
            Console.Write("Name: ");
            string entity = Console.ReadLine();
            Employee employee = _employees.Datas.Find(x => x.Name.Contains(entity.ToLower().Trim())
             || x.Surname.Contains(entity.ToLower().Trim()) || x.Profession.Contains(entity.ToLower().Trim()));
            Console.WriteLine(employee.Name + " " + employee.Surname+ " " +employee.Profession);
        }
        public void GetAll()
        {
            foreach (Employee employee in _employees.Datas.Where(d=>d.SoftDelete==false))
            {
                Console.WriteLine(employee.Name+ " " + employee.Surname+" "+employee.Profession);
            }
        }

        public void Update()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Employee employee = _employees.Datas.Find(u=>u.Name.ToLower().Trim()==name.ToLower().Trim());
            Console.Write("New salary: ");
            employee.Salary = decimal.Parse(Console.ReadLine());
            Console.Write("New Profession: ");
            employee.Profession = Console.ReadLine();
        }

        
    }
}
