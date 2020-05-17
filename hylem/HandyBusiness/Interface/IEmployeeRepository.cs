using HandyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandyBusiness.Interface
{
    public interface IEmployeeRepository
    {
        //=============================
        // FSB - For Specified Business
        //=============================

        //get all employees for a specific business
        List<Employee> GetAllEmployeeFSB(int? businessId);

        //Get a specific employee for a particular business
        Employee GetEmployeeFSBById(int? businessId, int? employeeId);

        //Add an employee for a particular business
        Employee AddEmployeeFSP(Employee employee);

        //Add mulitple employees for a particular business
        List<Employee> AddMultipleBusiness(List<Employee> employees);

        //Remove Employee for a specific business
        void RemoveEmployeeFSB(int? businessId, int? employeeId);

        Employee UpdateEmployeeFSB(Employee employeeChanges);
    }
}
