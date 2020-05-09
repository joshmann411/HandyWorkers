using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Email { get; set; }
        [Required]
        public string Phone  { get; set; }
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
        //public List<int> BusinessPhotosId { get; set; }
        public List<BusinessPhotos> businessPhotos { get; set; }
        public List<Employee> businessEmployees { get; set; }
    }

    public class BusinessPhotos
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public int businessId { get; set; }
        [ForeignKey("businessId")]
        public Business business { get; set; }
    }

    public class Sector
    {
        public int Id { get; set; }
        public string SectorName { get; set; }
        public int OperatingYear { get; set; }
        public int OperatingMonth { get; set; }
        public double ChargesPerHour { get; set; }
        public int businessId { get; set; }
        [ForeignKey("businessId")]
        public Business business { get; set; }
    }
    
    public class Employee
    {
        public int Id { get; set; }
        [MaxLength(13, ErrorMessage = "Length cannot exceed 13 characters")]
        public string IdNumber { get; set; }
        
        [MaxLength(50, ErrorMessage = "Length cannot exceed 13 characters")]
        public string Firstname { get; set; }
        [MaxLength(50, ErrorMessage = "Length cannot exceed 13 characters")]
        public string Lastname { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid Email Format")]
        public string Email{ get; set; }
        public string CellNo{ get; set; }
        [MaxLength(7)]
        public string Gender { get; set; }
        public string DateOfBirth{ get; set; }
        public int businessId { get; set; }
        [ForeignKey("businessId")]
        public Business business { get; set; }
    }
}
