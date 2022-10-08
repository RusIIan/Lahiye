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
        public  Bank_G<Employee> _employees;

        public EmployeeService()
        {
            _employees = new Bank_G<Employee>();
        }

        public void Create()
        {
            Employee employee = new Employee();
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
                Console.Clear();
            _employees.Datas.Add(employee);
            }
            catch (FormatException)
            {
                Console.WriteLine("incorrectly create a worker");                
            }
        
        }
        public void Delete()
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Employee employee = _employees.Datas.Find(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
            employee.SoftDelete = true;
        
        }
        public void Get()
        {
           
                Console.Write("Name: ");
                string entity = Console.ReadLine();
                Employee employee = _employees.Datas.Find(x => x.Name.Contains(entity.Trim())
                 || x.Surname.Contains(entity.Trim()) || x.Profession.Contains(entity.Trim()));
                    if (employee.SoftDelete==true)
                    {
                        Console.WriteLine("Employee not found");
                    }
                    else if (employee.SoftDelete==true)
                    {
                        Console.WriteLine($"Name: {employee.Name}  Surname: {employee.Surname}  Profession: {employee.Profession}  Salary:{employee.Salary}");
                    }


        }
        public List<Employee> GetAll()
        {
            foreach (Employee employee in _employees.Datas.Where(d => d.SoftDelete == false))
            {
                Console.WriteLine(employee.Name + " " + employee.Surname + " " + employee.Profession + " " + employee.Salary);
            }
            return _employees.Datas;
            
        }

        public void GetAllToConsole()
        {
            throw new NotImplementedException();
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
