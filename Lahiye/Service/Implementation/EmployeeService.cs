using Lahiye.DataBase;
using Lahiye.Models;
using Lahiye.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lahiye.Service.Implementation
{
    public class EmployeeService:IBankService,IEmployeeService
    {
        private Generic_Bank<Employee> employees;

        public EmployeeService()
        {
            employees = new Generic_Bank<Employee>();
        }
        public void Created(Employee entity)
        {
            employees.Datas.Add(entity);
        }
        public void Delete(string name)
        {
            Employee employee = employees.Datas.Find(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
            employee.SoftDelete = true;
            GetAll();
        }
        public void Get(string filter,int salary)
        {
            Employee employee= employees.Datas.Find(x => x.Name.Contains(filter.ToLower().Trim())
            || x.Surname.Contains(filter.ToLower().Trim())||x.Professin.Contains(filter.ToLower().Trim()));
            Console.WriteLine(employee.Name+ " "+ employee.Surname );
        }
        public void GetAll()
        {
            foreach (Employee employee in employees.Datas.Where(d=>d.SoftDelete==false))
            {
                Console.WriteLine(employee.Name+" "+ employee.Surname);
            }
        }
        public void GetProfit(int salary)
        {
            throw new NotImplementedException();
        }

        public void HireEmployee()
        {
            throw new NotImplementedException();
        }

        public void TransferEmployee()
        {
            throw new NotImplementedException();
        }

        public void TransferMoney()
        {
            throw new NotImplementedException();
        }
    }
}
