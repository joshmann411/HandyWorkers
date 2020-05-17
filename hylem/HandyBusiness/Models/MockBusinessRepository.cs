using HandyBusiness.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandyBusiness.Models
{
    public class MockBusinessRepository : IBusinessRepository, IEmployeeRepository
    {
        //Injecting list of employee for specific business
        private List<Employee> _employeesFSB;
        //Injecting list of businesses for specific business
        private List<Business> _BusinessList;

        public MockBusinessRepository()
        {
            //initialize business sectors obeject
            List<Sector> businessSectors = new List<Sector>()
            {
                new Sector(){ Id = 1, ChargesPerHour = 350.00, OperatingYear = 2, OperatingMonth = 4, SectorName = "Gardening"},
                new Sector(){ Id = 2, ChargesPerHour = 550.00, OperatingYear = 3, OperatingMonth = 7,SectorName = "Painting"},
            };

            //initialize list of employees for a specific business
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

            //initialize list of businesses that will show in the front end
            _BusinessList = new List<Business>()
            {
                //add static business - dummy data
                new Business()
                {
                    Id = 1,
                    Name = "Test 1 Gardening Services",
                    Email = "Email_1@e.com",
                    Phone = "00000000000",
                    City = "Pretoria",
                    Country = "South Africa",
                    NoOfStaffs = 3,
                    Sectors = businessSectors,
                    PostalCode = "0084",
                    Province = "Gauteng",
                    AddressLine = "123 Bikini Street",
                    Likes = 10, 
                    Dislikes = 2, 
                    businessEmployees = _employeesFSB
                },
                new Business()
                {
                    Id = 2,
                    Name = "Test 2 Gardening Services",
                    Email = "Email_2@e.com",
                    Phone = "11111111111",
                    City = "Midrand",
                    Country = "South Africa",
                    NoOfStaffs = 6,
                    Sectors = businessSectors,
                    PostalCode = "0111",
                    Province = "Gauteng",
                    AddressLine = "123 Enigma Street",
                    Likes = 8, 
                    Dislikes = 3
                }
            };
        }

        public Business GetBusiness(int id)
        {
            return _BusinessList.FirstOrDefault(e => e.Id == id);
        }

        //public IEnumerable<Business> GetAllBusinesses()
        //{
        //    return _BusinessList;
        //}

        public List<Business> GetAllBusinesses()
        {
            return _BusinessList;
        }

        public Business AddBusiness(Business business)
        {
            business.Id = _BusinessList.Max(e => e.Id) + 1;
            _BusinessList.Add(business);
            return business;
        }

        public Business UpdateBusiness(Business businessChanges)
        {
            Business business = _BusinessList.FirstOrDefault(e => e.Id == businessChanges.Likes);

            if (business != null)
            {
                //make business object = changes made... possible - test to confirm ?
                business = businessChanges;
            }

            return business;
        }

        public Business DeleteBusiness(int id)
        {
            Business business = _BusinessList.FirstOrDefault(e => e.Id == id);

            if(business != null)
            {
                //perform magic: never delete actual info without keeping data pls
                _BusinessList.Remove(business);
            }

            return business;
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
