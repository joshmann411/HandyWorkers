using HandyBusiness.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandyBusiness.Models
{
    public class MockEmployeeFSBs : IEmployeeRepository
    {
        private List<Employee> _employeesFSB;

        public MockEmployeeFSBs()
        {
            _employeesFSB = new List<Employee>()
            {
                new Employee()
                {
                    businessId = 1,
                    Firstname = "firstname1",
                    Lastname = "Lastname2",
                    Email = "emp1@emp1.com",
                    Gender = Gender.Male,
                    IdNumber = "1231231231234",
                    CellNo = "08123423445",
                    DateOfBirth = new DateTime(1990, 05, 21),
                    PhotoPath = string.Empty
                },
                new Employee()
                {
                    businessId = 1,
                    Firstname = "firstname2",
                    Lastname = "Lastname2",
                    Email = "emp2@emp2.com",
                    Gender = Gender.Female,
                    IdNumber = "3213214563364",
                    CellNo = "06135648263",
                    DateOfBirth = new DateTime(1999, 09, 24),
                    PhotoPath = string.Empty
                }
            }; 
        }

        public Employee AddEmployeeFSP(Employee employee)
        {
            _employeesFSB.Add(employee);

            return employee;
        }

        public List<Employee> AddMultipleBusiness(List<Employee> employees)
        {
            _employeesFSB.AddRange(employees);

            return employees;
        }

        public List<Employee> GetAllEmployeeFSB(int? businessId)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeFSBById(int? businessId, int? employeeId)
        {
            throw new NotImplementedException();
        }

        public void RemoveEmployeeFSB(int? businessId, int? employeeId)
        {
            throw new NotImplementedException();
        }

        public Employee UpdateEmployeeFSB(Employee employeeChanges)
        {
            throw new NotImplementedException();
        }
    }
}
