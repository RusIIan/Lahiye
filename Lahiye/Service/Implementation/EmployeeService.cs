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
        private Bank_G<Employee> _employees;

        public EmployeeService()
        {
            _employees = new Bank_G<Employee>();
        }

        public void Create(Employee entity)
        {
            _employees.Datas.Add(entity);
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
             || x.Surname.Contains(entity.ToLower().Trim()) || x.Professin.Contains(entity.ToLower().Trim()));
            Console.WriteLine(employee.Name + " " + employee.Surname);
        }
        public void GetAll()
        {
            foreach (Employee employee in _employees.Datas.Where(d=>d.SoftDelete==false))
            {
                Console.WriteLine(employee.Name+ " " + employee.Surname);
            }
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
