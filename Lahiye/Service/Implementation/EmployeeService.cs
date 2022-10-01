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
            Console.Clear();
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
                Console.ReadKey();
                Console.Clear();
            }
            catch (FormatException)
            {
                Console.WriteLine("incorrectly create a worker");                
            }
        
        }
        public void Delete(string name)
        {
            Employee employee = _employees.Datas.Find(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
            employee.SoftDelete = true;
            GetAll();
        }
        public void Get(string entity)
        {
            Employee employee = _employees.Datas.Find(x => x.Name.Contains(entity.ToLower().Trim())
             || x.Surname.Contains(entity.ToLower().Trim()) || x.Profession.Contains(entity.ToLower().Trim()));
            Console.WriteLine(employee.Name + " " + employee.Surname+ " " +employee.Profession);
        }
        public void GetAll()
        {
            foreach (Employee employee in _employees.Datas.Where(d=>d.SoftDelete==false))
            {
                Console.WriteLine(employee.Name+ " " + employee.Surname);
            }
        }

        public void Update(string name,decimal salary, string profession)
        {
            Employee employee = _employees.Datas.Find(u=>u.Name.ToLower().Trim()==name.ToLower().Trim());
            employee.Salary = salary;
            employee.Profession = profession;
        }

        
    }
}
