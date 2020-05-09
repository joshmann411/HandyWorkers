using HandyBusiness.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandyBusiness.ViewModels
{
    #region sector
    interface ISector
    {
        public string SectorName { get; set; }
        public int OperatingYear { get; set; }
        public int OperatingMonth { get; set; }
        public double ChargesPerHour { get; set; }
    }

    public class SectorViewModel : ISector
    {
        public string SectorName { get; set; }
        public int OperatingYear { get; set; }
        public int OperatingMonth { get; set; }
        public double ChargesPerHour { get; set; }
    }
    #endregion


    #region Employee
    interface IEmployee
    {
        public string IdNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string CellNo { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
    }

    public class EmployeeViewModel : IEmployee
    {
        public string IdNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string CellNo { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
    }
    #endregion


    public class BusinessCreateViewModel 
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid Email Format")]
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Phone { get; set; }
        
        [Required]
        [Display(Name = "Number Of Staffs")]
        public int NoOfStaffs { get; set; }
        
        [Required]
        [Display(Name = "Province")]
        public string Province { get; set; }
        
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        
        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }
        
        [Required]
        [Display(Name = "Address Line")]
        public string AddressLine { get; set; }
        
        [Required]
        [MaxLength(6, ErrorMessage = "Poastal Code can not exceed 6 characters")]
        public string PostalCode { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public List<IFormFile> Photos { get; set; }
        
    }
}
