using BusinessLayer.Interfaces;
using RepoLayer.Entity;
using RepoLayer.Interfaces;
using RepoLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class EmployeeBL : IEmployeeBL<Employee>
    {
        private IEmployeeRL<Employee> employeeRL;
        public EmployeeBL(IEmployeeRL<Employee> employeeRL)
        {
            this.employeeRL = employeeRL;
        }

        public bool Add(Employee entity)
        {
            return this.employeeRL.Add(entity);
        }

        public void Delete(Employee entity)
        {
            this.employeeRL.Delete(entity);
        }

        public Employee Get(long id)
        {
            return this.employeeRL.Get(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return this.employeeRL.GetAll();
        }

        public bool Update(Employee dbEntity, Employee entity)
        {
            return this.employeeRL.Update(dbEntity, entity);
        }
    }
}
