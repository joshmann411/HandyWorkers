using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandyBusiness.Models
{
    public class Business
    {
        public int Id  { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<BusinessEmails> Emails { get; set; }
        [Required]
        public List<BusinessPhones> Phones  { get; set; }
        //Pending development
        //At a later stage: 
        //  each employee should have access to their individual front-end
        //  they should be able to add-images, comment on their current working condition(s), 
        //  rate their boss/manager, get-likes and/or dislikes
        [Required]
        public int NoOfStaffs { get; set; }
        [Required]
        public string Province { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string AddressLine { get; set; }
        [Required]
        public string PostalCode { get; set; }
        public List<Sector> Sectors { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }

    public class BusinessEmails
    {
        public int Id { get; set; }
        public string BusinessEmail { get; set; }
    }

    public class BusinessPhones
    { 
        public int Id { get; set; }
        public string Phone { get; set; }
    }

    public class Sector
    {
        public int Id { get; set; }
        public string SectorName { get; set; }
        public int OperatingYear { get; set; }
        public int OperatingMonth { get; set; }
        public double ChargesPerHour { get; set; }
        
    }
}
