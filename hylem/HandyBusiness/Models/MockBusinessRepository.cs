using HandyBusiness.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandyBusiness.Models
{
    public class MockBusinessRepository : IBusinessRepository
    {
        private List<Business> _BusinessList;

        public MockBusinessRepository()
        {
            List<BusinessEmails> businessEmails = new List<BusinessEmails>()
            {
                new BusinessEmails(){ Id = 1, BusinessEmail = "EmailForTest1@T.com"},
                new BusinessEmails(){ Id = 2, BusinessEmail = "EmailForTest2@T.com"},
                new BusinessEmails(){ Id = 3, BusinessEmail = "EmailForTest3@T.com"},
                new BusinessEmails(){ Id = 4, BusinessEmail = "EmailForTest4@T.com"},
                new BusinessEmails(){ Id = 5, BusinessEmail = "EmailForTest5@T.com"},
            };

            List<BusinessPhones> businessPhones = new List<BusinessPhones>()
            {
                new BusinessPhones(){ Id = 1, Phone = "0841111111"},
                new BusinessPhones(){ Id = 2, Phone = "0841111111"},
                new BusinessPhones(){ Id = 3, Phone = "0841111111"},
            };


            List<Sector> businessSectors = new List<Sector>()
            {
                new Sector(){ Id = 1, ChargesPerHour = 350.00, OperatingYear = 2, OperatingMonth = 4, SectorName = "Gardening"},
                new Sector(){ Id = 2, ChargesPerHour = 550.00, OperatingYear = 3, OperatingMonth = 7,SectorName = "Painting"},
            };

            //create a list of businesses that will show in the front end
            _BusinessList = new List<Business>()
            {
                //add static business - dummy data
                new Business()
                {
                    Id = 1,
                    Name = "Test 1 Gardening Services",
                    Emails = businessEmails,
                    Phones = businessPhones,
                    City = "Pretoria",
                    Country = "South Africa",
                    NoOfStaffs = 3,
                    Sectors = businessSectors,
                    PostalCode = "0084",
                    Province = "Gauteng",
                    AddressLine = "123 Bikini Street",
                    Likes = 10, 
                    Dislikes = 2
                },
                new Business()
                {
                    Id = 2,
                    Name = "Test 2 Gardening Services",
                    Emails = businessEmails,
                    Phones = businessPhones,
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
        public IEnumerable<Business> GetAllBusinesses()
        {
            return _BusinessList;
        }
        public Business AddBusiness(Business business)
        {
            throw new NotImplementedException();
        }
    }
}
